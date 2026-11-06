using System.Data;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Excepciones;
using AcaBiblioteca.Modelos;

namespace AcaBiblioteca.Negocio
{
    /// <summary>Servicio para la gestión de libros.</summary>
    public class LibroServicio
    {
        /// Campos privados para acceder a los repositorios de libros, autores y editoriales
        private readonly LibroRepositorio _libros = new LibroRepositorio();
        private readonly AutorRepositorio _autores = new AutorRepositorio();
        private readonly EditorialRepositorio _editoriales = new EditorialRepositorio();

        /// <summary>Lista todos los libros registrados en la base de datos, con un filtro opcional.</summary>
        public DataTable Listar(string? filtro = null) => _libros.Listar(filtro);
        /// <summary>Lista todos los libros registrados en la base de datos para un combo.</summary>
        public DataTable ListarParaPrestamo() => _libros.ListarParaPrestamo();
        /// <summary>Obtiene un libro por su ISBN.</summary>
        public Libro? Obtener(string isbn) => _libros.Obtener(isbn);
        /// <summary>Registra un nuevo libro en la base de datos.</summary>
        public void Registrar(Libro libro)
        {
            libro.Validar();
            ValidarReferencias(libro);
            // Verificar si ya existe un libro con el mismo ISBN
            if (_libros.Existe(libro.ISBN))
                throw new ReglaNegocioException("Ya existe un libro con ese ISBN.");
            // Llamar al repositorio para insertar el nuevo libro
            _libros.Insertar(libro);
        }
        /// <summary>Actualiza los datos de un libro existente.</summary>
        public void Actualizar(Libro libro)
        {
            libro.Validar();
            ValidarReferencias(libro);
            // Verificar si el libro existe antes de actualizarlo
            if (_libros.Actualizar(libro) == 0)
                throw new ReglaNegocioException(
                    "No existe un libro con ese ISBN. Para crear uno nuevo use el botón Guardar.");
        }
        /// <summary>Elimina un libro por su ISBN.</summary>
        public void Eliminar(string isbn)
        {
            // Validar que el ISBN no esté vacío
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ReglaNegocioException("Seleccione un libro de la tabla para eliminar.");
            // Verificar si el libro tiene préstamos asociados antes de eliminarlo
            int prestamos = _libros.ContarPrestamos(isbn);
            if (prestamos > 0)
                throw new ReglaNegocioException(
                    $"No se puede eliminar el libro: tiene {prestamos} préstamo(s) registrado(s).");
            // Llamar al repositorio para eliminar el libro
            _libros.Eliminar(isbn);
        }
        /// <summary>Valida que el autor y la editorial del libro existan en la base de datos.</summary>
        private void ValidarReferencias(Libro libro)
        {
            // Verificar si el autor y la editorial existen en la base de datos
            if (!_autores.ExisteId(libro.IdAutor))
                throw new ReglaNegocioException("El autor seleccionado no existe.");
            // Verificar si el autor y la editorial existen en la base de datos
            if (!_editoriales.ExisteId(libro.IdEditorial))
                throw new ReglaNegocioException("La editorial seleccionada no existe.");
        }
    }
}
