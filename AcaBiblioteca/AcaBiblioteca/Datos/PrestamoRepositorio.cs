using System.Data;
using AcaBiblioteca.Excepciones;
using AcaBiblioteca.Modelos;
using Microsoft.Data.SqlClient;

namespace AcaBiblioteca.Datos
{
    /// <summary>
    /// Acceso a datos de préstamos. Las operaciones que afectan a las
    /// existencias del libro se ejecutan en una transacción para que el
    /// préstamo y el inventario nunca queden inconsistentes.
    /// </summary>
    public class PrestamoRepositorio : RepositorioBase
    {
        private const string ConsultaBase = @"SELECT P.IdPrestamo, P.IdUsuario,
                                                     U.Nombre + ' ' + U.Apellido AS Usuario,
                                                     P.ISBN, L.Titulo AS Libro,
                                                     P.FechaPrestamo, P.FechaDevolucion, P.Estado
                                              FROM Prestamos P
                                              INNER JOIN Usuarios U ON U.IdUsuario = P.IdUsuario
                                              INNER JOIN Libros L ON L.ISBN = P.ISBN";

        /// <summary>Lista los préstamos; estado vacío = todos.</summary>
        public DataTable Listar(string? estado)
            => Consultar(ConsultaBase + @" WHERE (@Estado = '' OR P.Estado = @Estado)
                                           ORDER BY P.IdPrestamo DESC",
                         Param("@Estado", estado ?? string.Empty));

        public Prestamo? Obtener(int idPrestamo)
        {
            DataTable tabla = Consultar(@"SELECT IdPrestamo, IdUsuario, ISBN, FechaPrestamo,
                                                 FechaDevolucion, Estado
                                          FROM Prestamos WHERE IdPrestamo = @Id",
                                        Param("@Id", idPrestamo));

            if (tabla.Rows.Count == 0)
                return null;

            DataRow f = tabla.Rows[0];
            return new Prestamo(Convert.ToInt32(f["IdUsuario"]),
                                Convert.ToString(f["ISBN"]) ?? string.Empty,
                                Convert.ToDateTime(f["FechaPrestamo"]))
            {
                IdPrestamo = Convert.ToInt32(f["IdPrestamo"]),
                FechaDevolucion = f["FechaDevolucion"] == DBNull.Value
                                    ? null : Convert.ToDateTime(f["FechaDevolucion"]),
                Estado = Convert.ToString(f["Estado"]) ?? string.Empty
            };
        }

        public bool ExistePrestamoActivo(int idUsuario, string isbn, int excluirId)
            => Existe(@"SELECT COUNT(1) FROM Prestamos
                        WHERE IdUsuario = @IdUsuario AND ISBN = @ISBN
                          AND Estado = 'Prestado' AND IdPrestamo <> @Id",
                      Param("@IdUsuario", idUsuario), Param("@ISBN", isbn), Param("@Id", excluirId));

        /// <summary>Registra el préstamo y descuenta una existencia del libro.</summary>
        public int Registrar(Prestamo p)
        {
            return EnTransaccion((cn, tx) =>
            {
                AjustarExistencias(cn, tx, p.ISBN, -1);

                object? id = EscalarTx(cn, tx,
                    @"INSERT INTO Prestamos (IdUsuario, ISBN, FechaPrestamo, FechaDevolucion, Estado)
                      OUTPUT INSERTED.IdPrestamo
                      VALUES (@IdUsuario, @ISBN, @FechaPrestamo, NULL, @Estado)",
                    Param("@IdUsuario", p.IdUsuario), Param("@ISBN", p.ISBN),
                    ParamFecha("@FechaPrestamo", p.FechaPrestamo),
                    Param("@Estado", EstadoPrestamo.Prestado));

                return Convert.ToInt32(id);
            });
        }

        /// <summary>
        /// Modifica un préstamo activo. Si cambia el libro, devuelve la
        /// existencia al libro anterior y descuenta la del nuevo.
        /// </summary>
        public void Actualizar(Prestamo p)
        {
            EnTransaccion((cn, tx) =>
            {
                DataRow actual = LeerPrestamoTx(cn, tx, p.IdPrestamo);

                if (Convert.ToString(actual["Estado"]) != EstadoPrestamo.Prestado)
                    throw new ReglaNegocioException(
                        "Solo se pueden editar los préstamos en estado 'Prestado'.");

                string isbnAnterior = Convert.ToString(actual["ISBN"]) ?? string.Empty;

                if (!string.Equals(isbnAnterior, p.ISBN, StringComparison.OrdinalIgnoreCase))
                {
                    AjustarExistencias(cn, tx, p.ISBN, -1);
                    AjustarExistencias(cn, tx, isbnAnterior, +1);
                }

                EjecutarTx(cn, tx,
                    @"UPDATE Prestamos
                      SET IdUsuario = @IdUsuario, ISBN = @ISBN, FechaPrestamo = @FechaPrestamo
                      WHERE IdPrestamo = @Id",
                    Param("@IdUsuario", p.IdUsuario), Param("@ISBN", p.ISBN),
                    ParamFecha("@FechaPrestamo", p.FechaPrestamo), Param("@Id", p.IdPrestamo));

                return 0;
            });
        }

        /// <summary>Registra la devolución y reintegra la existencia al libro.</summary>
        public void Devolver(int idPrestamo, DateTime fechaDevolucion)
        {
            EnTransaccion((cn, tx) =>
            {
                DataRow actual = LeerPrestamoTx(cn, tx, idPrestamo);

                if (Convert.ToString(actual["Estado"]) == EstadoPrestamo.Devuelto)
                    throw new ReglaNegocioException("Este préstamo ya fue devuelto.");

                EjecutarTx(cn, tx,
                    @"UPDATE Prestamos
                      SET FechaDevolucion = @Fecha, Estado = @Estado
                      WHERE IdPrestamo = @Id",
                    ParamFecha("@Fecha", fechaDevolucion),
                    Param("@Estado", EstadoPrestamo.Devuelto), Param("@Id", idPrestamo));

                AjustarExistencias(cn, tx, Convert.ToString(actual["ISBN"]) ?? string.Empty, +1);
                return 0;
            });
        }

        /// <summary>Elimina el préstamo; si seguía activo, reintegra la existencia.</summary>
        public void Eliminar(int idPrestamo)
        {
            EnTransaccion((cn, tx) =>
            {
                DataRow actual = LeerPrestamoTx(cn, tx, idPrestamo);

                if (Convert.ToString(actual["Estado"]) == EstadoPrestamo.Prestado)
                    AjustarExistencias(cn, tx, Convert.ToString(actual["ISBN"]) ?? string.Empty, +1);

                EjecutarTx(cn, tx, "DELETE FROM Prestamos WHERE IdPrestamo = @Id",
                           Param("@Id", idPrestamo));
                return 0;
            });
        }

        // ---------- Auxiliares transaccionales ----------

        private static DataRow LeerPrestamoTx(SqlConnection cn, SqlTransaction tx, int idPrestamo)
        {
            DataTable tabla = ConsultarTx(cn, tx,
                @"SELECT ISBN, Estado, FechaPrestamo
                  FROM Prestamos WITH (UPDLOCK, ROWLOCK)
                  WHERE IdPrestamo = @Id",
                Param("@Id", idPrestamo));

            if (tabla.Rows.Count == 0)
                throw new ReglaNegocioException("El préstamo seleccionado ya no existe.");

            return tabla.Rows[0];
        }

        private static void AjustarExistencias(SqlConnection cn, SqlTransaction tx,
                                               string isbn, int delta)
        {
            object? actual = EscalarTx(cn, tx,
                "SELECT Existencias FROM Libros WITH (UPDLOCK, ROWLOCK) WHERE ISBN = @ISBN",
                Param("@ISBN", isbn));

            if (actual == null || actual == DBNull.Value)
                throw new ReglaNegocioException("El libro seleccionado no existe.");

            int nuevo = Convert.ToInt32(actual) + delta;

            if (nuevo < 0)
                throw new ReglaNegocioException(
                    "El libro seleccionado no tiene existencias disponibles.");

            EjecutarTx(cn, tx, "UPDATE Libros SET Existencias = @Nuevo WHERE ISBN = @ISBN",
                       Param("@Nuevo", nuevo), Param("@ISBN", isbn));
        }
    }
}
