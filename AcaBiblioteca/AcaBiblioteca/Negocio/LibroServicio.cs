using System.Data;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Excepciones;
using AcaBiblioteca.Modelos;

namespace AcaBiblioteca.Negocio
{
    public class LibroServicio
    {
        private readonly LibroRepositorio _libros = new LibroRepositorio();
        private readonly AutorRepositorio _autores = new AutorRepositorio();
        private readonly EditorialRepositorio _editoriales = new EditorialRepositorio();

        public DataTable Listar(string? filtro = null) => _libros.Listar(filtro);

        public DataTable ListarParaPrestamo() => _libros.ListarParaPrestamo();

        public Libro? Obtener(string isbn) => _libros.Obtener(isbn);

        public void Registrar(Libro libro)
        {
            libro.Validar();
            ValidarReferencias(libro);

            if (_libros.Existe(libro.ISBN))
                throw new ReglaNegocioException("Ya existe un libro con ese ISBN.");

            _libros.Insertar(libro);
        }

        public void Actualizar(Libro libro)
        {
            libro.Validar();
            ValidarReferencias(libro);

            if (_libros.Actualizar(libro) == 0)
                throw new ReglaNegocioException(
                    "No existe un libro con ese ISBN. Para crear uno nuevo use el botón Guardar.");
        }

        public void Eliminar(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ReglaNegocioException("Seleccione un libro de la tabla para eliminar.");

            int prestamos = _libros.ContarPrestamos(isbn);
            if (prestamos > 0)
                throw new ReglaNegocioException(
                    $"No se puede eliminar el libro: tiene {prestamos} préstamo(s) registrado(s).");

            _libros.Eliminar(isbn);
        }

        private void ValidarReferencias(Libro libro)
        {
            if (!_autores.ExisteId(libro.IdAutor))
                throw new ReglaNegocioException("El autor seleccionado no existe.");

            if (!_editoriales.ExisteId(libro.IdEditorial))
                throw new ReglaNegocioException("La editorial seleccionada no existe.");
        }
    }
}
