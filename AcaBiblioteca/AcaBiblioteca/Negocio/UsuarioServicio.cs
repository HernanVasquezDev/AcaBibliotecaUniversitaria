using System.Data;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Excepciones;
using AcaBiblioteca.Modelos;

namespace AcaBiblioteca.Negocio
{
    public class UsuarioServicio
    {
        private readonly UsuarioRepositorio _repositorio = new UsuarioRepositorio();

        public DataTable Listar() => _repositorio.Listar();

        public DataTable ListarParaCombo() => _repositorio.ListarParaCombo();

        public void Registrar(Usuario usuario)
        {
            usuario.Validar();

            if (_repositorio.ExisteDocumento(usuario.Documento, 0))
                throw new ReglaNegocioException("Ya existe un usuario con ese documento.");

            _repositorio.Insertar(usuario);
        }

        public void Actualizar(Usuario usuario)
        {
            if (usuario.IdUsuario <= 0)
                throw new ReglaNegocioException("Seleccione un usuario de la tabla para editar.");

            usuario.Validar();

            if (_repositorio.ExisteDocumento(usuario.Documento, usuario.IdUsuario))
                throw new ReglaNegocioException("Ya existe otro usuario con ese documento.");

            if (_repositorio.Actualizar(usuario) == 0)
                throw new ReglaNegocioException("El usuario seleccionado ya no existe.");
        }

        public void Eliminar(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new ReglaNegocioException("Seleccione un usuario de la tabla para eliminar.");

            int prestamos = _repositorio.ContarPrestamos(idUsuario);
            if (prestamos > 0)
                throw new ReglaNegocioException(
                    $"No se puede eliminar el usuario: tiene {prestamos} préstamo(s) registrado(s).");

            _repositorio.Eliminar(idUsuario);
        }
    }
}
