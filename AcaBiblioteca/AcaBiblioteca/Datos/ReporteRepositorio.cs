using System.Data;
using AcaBiblioteca.Modelos;

namespace AcaBiblioteca.Datos
{
    /// <summary>Consultas de solo lectura que alimentan el módulo de reportes.</summary>
    public class ReporteRepositorio : RepositorioBase
    {
        private const string LibrosBase = @"SELECT L.ISBN, L.Titulo,
                                                   A.Nombre + ' ' + A.Apellido AS Autor,
                                                   E.Nombre AS Editorial,
                                                   L.Categoria, L.Anio AS [Año], L.Existencias
                                            FROM Libros L
                                            INNER JOIN Autores A ON A.IdAutor = L.IdAutor
                                            INNER JOIN Editoriales E ON E.IdEditorial = L.IdEditorial";

        public DataTable ListadoLibros()
            => Consultar(LibrosBase + " ORDER BY L.Titulo");

        public DataTable LibrosDisponibles()
            => Consultar(LibrosBase + " WHERE L.Existencias > 0 ORDER BY L.Titulo");

        public DataTable LibrosMasPrestados()
            => Consultar(@"SELECT L.ISBN, L.Titulo, COUNT(P.IdPrestamo) AS [Total de préstamos]
                           FROM Libros L
                           LEFT JOIN Prestamos P ON P.ISBN = L.ISBN
                           GROUP BY L.ISBN, L.Titulo
                           ORDER BY COUNT(P.IdPrestamo) DESC, L.Titulo");

        public DataTable Autores()
            => Consultar(@"SELECT A.IdAutor, A.Nombre, A.Apellido, COUNT(L.ISBN) AS [Libros registrados]
                           FROM Autores A
                           LEFT JOIN Libros L ON L.IdAutor = A.IdAutor
                           GROUP BY A.IdAutor, A.Nombre, A.Apellido
                           ORDER BY A.Nombre, A.Apellido");

        public DataTable Editoriales()
            => Consultar(@"SELECT E.IdEditorial, E.Nombre, COUNT(L.ISBN) AS [Libros registrados]
                           FROM Editoriales E
                           LEFT JOIN Libros L ON L.IdEditorial = E.IdEditorial
                           GROUP BY E.IdEditorial, E.Nombre
                           ORDER BY E.Nombre");

        public DataTable Usuarios()
            => Consultar(@"SELECT U.IdUsuario, U.Nombre, U.Apellido, U.Documento, U.Telefono, U.Correo,
                                  (SELECT COUNT(1) FROM Prestamos P
                                   WHERE P.IdUsuario = U.IdUsuario AND P.Estado = 'Prestado') AS [Préstamos activos]
                           FROM Usuarios U
                           ORDER BY U.Nombre, U.Apellido");

        public DataTable HistorialPorUsuario(int idUsuario)
            => Consultar(@"SELECT P.IdPrestamo, P.ISBN, L.Titulo AS Libro,
                                  P.FechaPrestamo, P.FechaDevolucion, P.Estado,
                                  DATEDIFF(DAY, P.FechaPrestamo,
                                           ISNULL(P.FechaDevolucion, CAST(GETDATE() AS DATE))) AS [Días]
                           FROM Prestamos P
                           INNER JOIN Libros L ON L.ISBN = P.ISBN
                           WHERE P.IdUsuario = @IdUsuario
                           ORDER BY P.FechaPrestamo DESC",
                         Param("@IdUsuario", idUsuario));

        public ResumenBiblioteca ObtenerResumen()
        {
            DataTable t = Consultar(@"SELECT
                (SELECT COUNT(1) FROM Libros) AS TotalLibros,
                (SELECT ISNULL(SUM(Existencias), 0) FROM Libros) AS TotalExistencias,
                (SELECT COUNT(1) FROM Autores) AS TotalAutores,
                (SELECT COUNT(1) FROM Editoriales) AS TotalEditoriales,
                (SELECT COUNT(1) FROM Usuarios) AS TotalUsuarios,
                (SELECT COUNT(1) FROM Prestamos WHERE Estado = 'Prestado') AS PrestamosActivos,
                (SELECT COUNT(1) FROM Prestamos WHERE Estado = 'Devuelto') AS PrestamosDevueltos");

            DataRow f = t.Rows[0];
            return new ResumenBiblioteca
            {
                TotalLibros = Convert.ToInt32(f["TotalLibros"]),
                TotalExistencias = Convert.ToInt32(f["TotalExistencias"]),
                TotalAutores = Convert.ToInt32(f["TotalAutores"]),
                TotalEditoriales = Convert.ToInt32(f["TotalEditoriales"]),
                TotalUsuarios = Convert.ToInt32(f["TotalUsuarios"]),
                PrestamosActivos = Convert.ToInt32(f["PrestamosActivos"]),
                PrestamosDevueltos = Convert.ToInt32(f["PrestamosDevueltos"])
            };
        }
    }
}
