using System.Data;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Excepciones;
using AcaBiblioteca.Modelos;

namespace AcaBiblioteca.Negocio
{
    public class AutorServicio
    {
        private readonly AutorRepositorio _repositorio = new AutorRepositorio();

        public DataTable Listar() => _repositorio.Listar();

        public DataTable ListarParaCombo() => _repositorio.ListarParaCombo();

        public void Registrar(Autor autor)
        {
            autor.Validar();

            if (_repositorio.ExisteNombre(autor.Nombre, autor.Apellido, 0))
                throw new ReglaNegocioException("Ya existe un autor con ese nombre y apellido.");

            _repositorio.Insertar(autor);
        }

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

        public void Eliminar(int idAutor)
        {
            if (idAutor <= 0)
                throw new ReglaNegocioException("Seleccione un autor de la tabla para eliminar.");

            int libros = _repositorio.ContarLibros(idAutor);
            if (libros > 0)
                throw new ReglaNegocioException(
                    $"No se puede eliminar el autor: tiene {libros} libro(s) registrado(s).");

            _repositorio.Eliminar(idAutor);
        }
    }
}
