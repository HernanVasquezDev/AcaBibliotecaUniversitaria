using System.Data;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Excepciones;
using AcaBiblioteca.Modelos;

namespace AcaBiblioteca.Negocio
{
    /// <summary>Servicio para la gestión de editoriales.</summary>
    public class EditorialServicio
    {
        // Campos privados para acceder al repositorio de editoriales
        private readonly EditorialRepositorio _repositorio = new EditorialRepositorio();
        /// <summary>Lista todas las editoriales registradas en la base de datos.</summary>
        public DataTable Listar() => _repositorio.Listar();
        /// <summary>Lista todas las editoriales registradas en la base de datos para un combo.</summary>
        public DataTable ListarParaCombo() => _repositorio.ListarParaCombo();
        /// <summary>Obtiene una editorial por su Id.</summary>
        public void Registrar(Editorial editorial)
        {
            editorial.Validar();
            // Verificar si ya existe una editorial con el mismo nombre
            if (_repositorio.ExisteNombre(editorial.Nombre, 0))
                throw new ReglaNegocioException("Ya existe una editorial con ese nombre.");
            // Llamar al repositorio para insertar la nueva editorial
            _repositorio.Insertar(editorial);
        }
        /// <summary>Actualiza los datos de una editorial existente.</summary>
        public void Actualizar(Editorial editorial)
        {
            if (editorial.IdEditorial <= 0)
                throw new ReglaNegocioException("Seleccione una editorial de la tabla para editar.");

            editorial.Validar();
            // Verificar si ya existe otra editorial con el mismo nombre
            if (_repositorio.ExisteNombre(editorial.Nombre, editorial.IdEditorial))
                throw new ReglaNegocioException("Ya existe otra editorial con ese nombre.");
            // Llamar al repositorio para actualizar la editorial
            if (_repositorio.Actualizar(editorial) == 0)
                throw new ReglaNegocioException("La editorial seleccionada ya no existe.");
        }
        /// <summary>Elimina una editorial por su Id.</summary>
        public void Eliminar(int idEditorial)
        {
            if (idEditorial <= 0)
                throw new ReglaNegocioException("Seleccione una editorial de la tabla para eliminar.");
            // Verificar si la editorial tiene libros asociados antes de eliminarla
            int libros = _repositorio.ContarLibros(idEditorial);
            if (libros > 0)
                throw new ReglaNegocioException(
                    $"No se puede eliminar la editorial: tiene {libros} libro(s) registrado(s).");
            // Llamar al repositorio para eliminar la editorial
            _repositorio.Eliminar(idEditorial);
        }
    }
}
