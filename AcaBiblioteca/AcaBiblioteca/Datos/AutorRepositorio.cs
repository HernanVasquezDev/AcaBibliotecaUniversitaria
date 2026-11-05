using System.Data;
using AcaBiblioteca.Modelos;

namespace AcaBiblioteca.Datos
{
    public class AutorRepositorio : RepositorioBase
    {
        public DataTable Listar()
            => Consultar("SELECT IdAutor, Nombre, Apellido FROM Autores ORDER BY IdAutor");

        public DataTable ListarParaCombo()
            => Consultar(@"SELECT IdAutor, Nombre + ' ' + Apellido AS NombreCompleto
                           FROM Autores ORDER BY Nombre, Apellido");

        public bool ExisteId(int idAutor)
            => Existe("SELECT COUNT(1) FROM Autores WHERE IdAutor = @IdAutor",
                      Param("@IdAutor", idAutor));

        public bool ExisteNombre(string nombre, string apellido, int excluirId)
            => Existe(@"SELECT COUNT(1) FROM Autores
                        WHERE Nombre = @Nombre AND Apellido = @Apellido AND IdAutor <> @Id",
                      Param("@Nombre", nombre), Param("@Apellido", apellido), Param("@Id", excluirId));

        public int ContarLibros(int idAutor)
            => Convert.ToInt32(Escalar("SELECT COUNT(1) FROM Libros WHERE IdAutor = @IdAutor",
                                       Param("@IdAutor", idAutor)));

        public int Insertar(Autor autor)
            => Ejecutar("INSERT INTO Autores (Nombre, Apellido) VALUES (@Nombre, @Apellido)",
                        Param("@Nombre", autor.Nombre), Param("@Apellido", autor.Apellido));

        public int Actualizar(Autor autor)
            => Ejecutar(@"UPDATE Autores SET Nombre = @Nombre, Apellido = @Apellido
                          WHERE IdAutor = @IdAutor",
                        Param("@Nombre", autor.Nombre), Param("@Apellido", autor.Apellido),
                        Param("@IdAutor", autor.IdAutor));

        public int Eliminar(int idAutor)
            => Ejecutar("DELETE FROM Autores WHERE IdAutor = @IdAutor", Param("@IdAutor", idAutor));
    }
}
