using System.Data;
using AcaBiblioteca.Modelos;

namespace AcaBiblioteca.Datos
{
    public class UsuarioRepositorio : RepositorioBase
    {
        public DataTable Listar()
            => Consultar(@"SELECT IdUsuario, Nombre, Apellido, Documento, Telefono, Correo
                           FROM Usuarios ORDER BY IdUsuario");

        public DataTable ListarParaCombo()
            => Consultar(@"SELECT IdUsuario,
                                  Nombre + ' ' + Apellido + ' - ' + Documento AS Descripcion
                           FROM Usuarios ORDER BY Nombre, Apellido");

        public bool ExisteId(int idUsuario)
            => Existe("SELECT COUNT(1) FROM Usuarios WHERE IdUsuario = @Id",
                      Param("@Id", idUsuario));

        public bool ExisteDocumento(string documento, int excluirId)
            => Existe("SELECT COUNT(1) FROM Usuarios WHERE Documento = @Documento AND IdUsuario <> @Id",
                      Param("@Documento", documento), Param("@Id", excluirId));

        public int ContarPrestamos(int idUsuario)
            => Convert.ToInt32(Escalar("SELECT COUNT(1) FROM Prestamos WHERE IdUsuario = @Id",
                                       Param("@Id", idUsuario)));

        public int Insertar(Usuario u)
            => Ejecutar(@"INSERT INTO Usuarios (Nombre, Apellido, Documento, Telefono, Correo)
                          VALUES (@Nombre, @Apellido, @Documento, @Telefono, @Correo)",
                        Param("@Nombre", u.Nombre), Param("@Apellido", u.Apellido),
                        Param("@Documento", u.Documento), Param("@Telefono", u.Telefono),
                        Param("@Correo", u.Correo));

        public int Actualizar(Usuario u)
            => Ejecutar(@"UPDATE Usuarios
                          SET Nombre = @Nombre, Apellido = @Apellido, Documento = @Documento,
                              Telefono = @Telefono, Correo = @Correo
                          WHERE IdUsuario = @Id",
                        Param("@Nombre", u.Nombre), Param("@Apellido", u.Apellido),
                        Param("@Documento", u.Documento), Param("@Telefono", u.Telefono),
                        Param("@Correo", u.Correo), Param("@Id", u.IdUsuario));

        public int Eliminar(int idUsuario)
            => Ejecutar("DELETE FROM Usuarios WHERE IdUsuario = @Id", Param("@Id", idUsuario));
    }
}
