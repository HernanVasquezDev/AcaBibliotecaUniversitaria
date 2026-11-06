using System.Data;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Excepciones;
using AcaBiblioteca.Modelos;

namespace AcaBiblioteca.Negocio
{
    // / <summary>Servicio para la gestión de autores.</summary>
    public class AutorServicio
    {
        // Campos privados para acceder al repositorio de autores
        private readonly AutorRepositorio _repositorio = new AutorRepositorio();

        /// <summary>Lista todos los autores registrados en la base de datos.</summary>
        public DataTable Listar() => _repositorio.Listar();
        /// <summary>Lista todos los autores registrados en la base de datos para un combo.</summary>
        public DataTable ListarParaCombo() => _repositorio.ListarParaCombo();
        /// <summary>Obtiene un autor por su Id.</summary>
        public void Registrar(Autor autor)
        {
            autor.Validar();

            if (_repositorio.ExisteNombre(autor.Nombre, autor.Apellido, 0))
                throw new ReglaNegocioException("Ya existe un autor con ese nombre y apellido.");

            _repositorio.Insertar(autor);
        }
        /// <summary>Actualiza los datos de un autor existente.</summary>
        public void Actualizar(Autor autor)
        {
            if (autor.IdAutor <= 0)
                throw new ReglaNegocioException("Seleccione un autor de la tabla para editar.");

            autor.Validar();

            if (_repositorio.ExisteNombre(autor.Nombre, autor.Apellido, autor.IdAutor))
                throw new ReglaNegocioException("Ya existe otro autor con ese nombre y apellido.");

            if (_repositorio.Actualizar(autor) == 0)
                throw new ReglaNegocioException("El autor seleccionado ya no existe.");
        }
        /// <summary>Elimina un autor por su Id.</summary>
        public void Eliminar(int idAutor)
        {
            if (idAutor <= 0)
                throw new ReglaNegocioException("Seleccione un autor de la tabla para eliminar.");
            // Verificar si el autor tiene libros asociados antes de eliminarlo
            int libros = _repositorio.ContarLibros(idAutor);
            if (libros > 0)
                throw new ReglaNegocioException(
                    $"No se puede eliminar el autor: tiene {libros} libro(s) registrado(s).");
            // Llamar al repositorio para eliminar el autor
            _repositorio.Eliminar(idAutor);
        }
    }
}
