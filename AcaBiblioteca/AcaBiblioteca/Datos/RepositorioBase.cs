using System.Data;
using AcaBiblioteca.Excepciones;
using Microsoft.Data.SqlClient;

namespace AcaBiblioteca.Datos
{
    /// <summary>
    /// Base de los repositorios: centraliza la conexión, la ejecución de
    /// consultas parametrizadas, las transacciones y la traducción de los
    /// errores de integridad de SQL Server a mensajes comprensibles.
    /// </summary>
    public abstract class RepositorioBase
    {
        private readonly Conexion _conexion = new Conexion();

        protected SqlConnection NuevaConexion() => _conexion.ObtenerConexion();

        protected static SqlParameter Param(string nombre, object? valor)
            => new SqlParameter(nombre, valor ?? DBNull.Value);

        protected static SqlParameter ParamFecha(string nombre, DateTime? fecha)
        {
            var parametro = new SqlParameter(nombre, SqlDbType.Date);
            parametro.Value = fecha.HasValue ? fecha.Value.Date : DBNull.Value;
            return parametro;
        }

        // ---------- Consultas simples (una conexión por operación) ----------

        protected DataTable Consultar(string sql, params SqlParameter[] parametros)
        {
            return Proteger(() =>
            {
                using SqlConnection cn = NuevaConexion();
                using SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddRange(parametros);
                using SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            });
        }

        protected int Ejecutar(string sql, params SqlParameter[] parametros)
        {
            return Proteger(() =>
            {
                using SqlConnection cn = NuevaConexion();
                cn.Open();
                using SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddRange(parametros);
                return cmd.ExecuteNonQuery();
            });
        }

        protected object? Escalar(string sql, params SqlParameter[] parametros)
        {
            return Proteger(() =>
            {
                using SqlConnection cn = NuevaConexion();
                cn.Open();
                using SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddRange(parametros);
                return cmd.ExecuteScalar();
            });
        }

        protected bool Existe(string sql, params SqlParameter[] parametros)
        {
            object? resultado = Escalar(sql, parametros);
            return resultado != null && resultado != DBNull.Value
                   && Convert.ToInt32(resultado) > 0;
        }

        // ---------- Operaciones dentro de una transacción ----------

        protected T EnTransaccion<T>(Func<SqlConnection, SqlTransaction, T> accion)
        {
            return Proteger(() =>
            {
                using SqlConnection cn = NuevaConexion();
                cn.Open();
                using SqlTransaction tx = cn.BeginTransaction();

                try
                {
                    T resultado = accion(cn, tx);
                    tx.Commit();
                    return resultado;
                }
                catch
                {
                    try { tx.Rollback(); } catch { /* la transacción ya finalizó */ }
                    throw;
                }
            });
        }

        protected static DataTable ConsultarTx(SqlConnection cn, SqlTransaction tx,
                                               string sql, params SqlParameter[] parametros)
        {
            using SqlCommand cmd = new SqlCommand(sql, cn, tx);
            cmd.Parameters.AddRange(parametros);
            using SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        protected static int EjecutarTx(SqlConnection cn, SqlTransaction tx,
                                        string sql, params SqlParameter[] parametros)
        {
            using SqlCommand cmd = new SqlCommand(sql, cn, tx);
            cmd.Parameters.AddRange(parametros);
            return cmd.ExecuteNonQuery();
        }

        protected static object? EscalarTx(SqlConnection cn, SqlTransaction tx,
                                           string sql, params SqlParameter[] parametros)
        {
            using SqlCommand cmd = new SqlCommand(sql, cn, tx);
            cmd.Parameters.AddRange(parametros);
            return cmd.ExecuteScalar();
        }

        // ---------- Utilidades ----------

        /// <summary>Escapa los comodines de LIKE para buscar texto literal.</summary>
        protected static string EscaparLike(string texto)
            => texto.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]");

        private static T Proteger<T>(Func<T> accion)
        {
            try
            {
                return accion();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new ReglaNegocioException(
                    "La operación no se puede completar porque el registro está relacionado con otros datos.", ex);
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                throw new ReglaNegocioException(
                    "Ya existe un registro con los mismos datos únicos.", ex);
            }
        }
    }
}
