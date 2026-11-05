using System.Data;
using AcaBiblioteca.Modelos;

namespace AcaBiblioteca.Datos
{
    public class EditorialRepositorio : RepositorioBase
    {
        public DataTable Listar()
            => Consultar("SELECT IdEditorial, Nombre FROM Editoriales ORDER BY IdEditorial");

        public DataTable ListarParaCombo()
            => Consultar("SELECT IdEditorial, Nombre FROM Editoriales ORDER BY Nombre");

        public bool ExisteId(int idEditorial)
            => Existe("SELECT COUNT(1) FROM Editoriales WHERE IdEditorial = @Id",
                      Param("@Id", idEditorial));

        public bool ExisteNombre(string nombre, int excluirId)
            => Existe("SELECT COUNT(1) FROM Editoriales WHERE Nombre = @Nombre AND IdEditorial <> @Id",
                      Param("@Nombre", nombre), Param("@Id", excluirId));

        public int ContarLibros(int idEditorial)
            => Convert.ToInt32(Escalar("SELECT COUNT(1) FROM Libros WHERE IdEditorial = @Id",
                                       Param("@Id", idEditorial)));

        public int Insertar(Editorial editorial)
            => Ejecutar("INSERT INTO Editoriales (Nombre) VALUES (@Nombre)",
                        Param("@Nombre", editorial.Nombre));

        public int Actualizar(Editorial editorial)
            => Ejecutar("UPDATE Editoriales SET Nombre = @Nombre WHERE IdEditorial = @Id",
                        Param("@Nombre", editorial.Nombre), Param("@Id", editorial.IdEditorial));

        public int Eliminar(int idEditorial)
            => Ejecutar("DELETE FROM Editoriales WHERE IdEditorial = @Id", Param("@Id", idEditorial));
    }
}
