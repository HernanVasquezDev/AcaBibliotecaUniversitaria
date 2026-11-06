using System.Data;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Excepciones;
using AcaBiblioteca.Modelos;

namespace AcaBiblioteca.Negocio
{
    public class EditorialServicio
    {
        private readonly EditorialRepositorio _repositorio = new EditorialRepositorio();

        public DataTable Listar() => _repositorio.Listar();

        public DataTable ListarParaCombo() => _repositorio.ListarParaCombo();

        public void Registrar(Editorial editorial)
        {
            editorial.Validar();

            if (_repositorio.ExisteNombre(editorial.Nombre, 0))
                throw new ReglaNegocioException("Ya existe una editorial con ese nombre.");

            _repositorio.Insertar(editorial);
        }

        public void Actualizar(Editorial editorial)
        {
            if (editorial.IdEditorial <= 0)
                throw new ReglaNegocioException("Seleccione una editorial de la tabla para editar.");

            editorial.Validar();

            if (_repositorio.ExisteNombre(editorial.Nombre, editorial.IdEditorial))
                throw new ReglaNegocioException("Ya existe otra editorial con ese nombre.");

            if (_repositorio.Actualizar(editorial) == 0)
                throw new ReglaNegocioException("La editorial seleccionada ya no existe.");
        }

        public void Eliminar(int idEditorial)
        {
            if (idEditorial <= 0)
                throw new ReglaNegocioException("Seleccione una editorial de la tabla para eliminar.");

            int libros = _repositorio.ContarLibros(idEditorial);
            if (libros > 0)
                throw new ReglaNegocioException(
                    $"No se puede eliminar la editorial: tiene {libros} libro(s) registrado(s).");

            _repositorio.Eliminar(idEditorial);
        }
    }
}
