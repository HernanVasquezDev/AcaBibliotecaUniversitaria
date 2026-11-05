using System.Data;
using AcaBiblioteca.Modelos;

namespace AcaBiblioteca.Datos
{
    public class LibroRepositorio : RepositorioBase
    {
        /// <summary>Lista los libros; el filtro busca por ISBN, título o autor.</summary>
        public DataTable Listar(string? filtro)
        {
            string patron = "%" + EscaparLike((filtro ?? string.Empty).Trim()) + "%";

            return Consultar(@"SELECT L.ISBN, L.Titulo,
                                      L.IdAutor, A.Nombre + ' ' + A.Apellido AS Autor,
                                      L.IdEditorial, E.Nombre AS Editorial,
                                      L.Categoria, L.Anio, L.Existencias
                               FROM Libros L
                               INNER JOIN Autores A ON A.IdAutor = L.IdAutor
                               INNER JOIN Editoriales E ON E.IdEditorial = L.IdEditorial
                               WHERE L.ISBN LIKE @Patron
                                  OR L.Titulo LIKE @Patron
                                  OR A.Nombre + ' ' + A.Apellido LIKE @Patron
                               ORDER BY L.Titulo",
                             Param("@Patron", patron));
        }

        public DataTable ListarParaPrestamo()
            => Consultar(@"SELECT ISBN,
                                  Titulo + ' (' + ISBN + ') - Disp: ' + CAST(Existencias AS VARCHAR(10)) AS Descripcion
                           FROM Libros ORDER BY Titulo");

        public Libro? Obtener(string isbn)
        {
            DataTable tabla = Consultar(@"SELECT ISBN, Titulo, IdAutor, IdEditorial,
                                                 Categoria, Anio, Existencias
                                          FROM Libros WHERE ISBN = @ISBN",
                                        Param("@ISBN", isbn));

            if (tabla.Rows.Count == 0)
                return null;

            DataRow fila = tabla.Rows[0];
            return new Libro
            {
                ISBN = Convert.ToString(fila["ISBN"]) ?? string.Empty,
                Titulo = Convert.ToString(fila["Titulo"]) ?? string.Empty,
                IdAutor = Convert.ToInt32(fila["IdAutor"]),
                IdEditorial = Convert.ToInt32(fila["IdEditorial"]),
                Categoria = fila["Categoria"] == DBNull.Value ? string.Empty : Convert.ToString(fila["Categoria"]) ?? string.Empty,
                Anio = fila["Anio"] == DBNull.Value ? 0 : Convert.ToInt32(fila["Anio"]),
                Existencias = Convert.ToInt32(fila["Existencias"])
            };
        }

        public bool Existe(string isbn)
            => Existe("SELECT COUNT(1) FROM Libros WHERE ISBN = @ISBN", Param("@ISBN", isbn));

        public int ContarPrestamos(string isbn)
            => Convert.ToInt32(Escalar("SELECT COUNT(1) FROM Prestamos WHERE ISBN = @ISBN",
                                       Param("@ISBN", isbn)));

        public int Insertar(Libro l)
            => Ejecutar(@"INSERT INTO Libros (ISBN, Titulo, IdAutor, IdEditorial, Categoria, Anio, Existencias)
                          VALUES (@ISBN, @Titulo, @IdAutor, @IdEditorial, @Categoria, @Anio, @Existencias)",
                        Param("@ISBN", l.ISBN), Param("@Titulo", l.Titulo),
                        Param("@IdAutor", l.IdAutor), Param("@IdEditorial", l.IdEditorial),
                        Param("@Categoria", l.Categoria), Param("@Anio", l.Anio),
                        Param("@Existencias", l.Existencias));

        public int Actualizar(Libro l)
            => Ejecutar(@"UPDATE Libros
                          SET Titulo = @Titulo, IdAutor = @IdAutor, IdEditorial = @IdEditorial,
                              Categoria = @Categoria, Anio = @Anio, Existencias = @Existencias
                          WHERE ISBN = @ISBN",
                        Param("@ISBN", l.ISBN), Param("@Titulo", l.Titulo),
                        Param("@IdAutor", l.IdAutor), Param("@IdEditorial", l.IdEditorial),
                        Param("@Categoria", l.Categoria), Param("@Anio", l.Anio),
                        Param("@Existencias", l.Existencias));

        public int Eliminar(string isbn)
            => Ejecutar("DELETE FROM Libros WHERE ISBN = @ISBN", Param("@ISBN", isbn));
    }
}
