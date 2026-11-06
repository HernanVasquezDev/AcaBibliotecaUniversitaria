using System.Data;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Excepciones;
using AcaBiblioteca.Modelos;

namespace AcaBiblioteca.Negocio
{
    /// <summary>Servicio para la gestión de usuarios.</summary>
    public class UsuarioServicio
    {
        /// Campos privados para acceder al repositorio de usuarios
        private readonly UsuarioRepositorio _repositorio = new UsuarioRepositorio();

        /// <summary>Lista todos los usuarios registrados en la base de datos.</summary>
        public DataTable Listar() => _repositorio.Listar();
        /// <summary>Lista todos los usuarios registrados en la base de datos para un combo.</summary>
        public DataTable ListarParaCombo() => _repositorio.ListarParaCombo();

        /// <summary>Obtiene un usuario por su Id.</summary>
        public void Registrar(Usuario usuario)
        {
            // Validar los datos del usuario antes de registrarlo
            usuario.Validar();

            // Verificar si ya existe un usuario con el mismo documento
            if (_repositorio.ExisteDocumento(usuario.Documento, 0))
                throw new ReglaNegocioException("Ya existe un usuario con ese documento.");
            // Llamar al repositorio para insertar el nuevo usuario
            _repositorio.Insertar(usuario);
        }
        /// <summary>Actualiza los datos de un usuario existente.</summary>
        public void Actualizar(Usuario usuario)
        {
            // Validar los datos del usuario antes de actualizarlo
            if (usuario.IdUsuario <= 0)
                throw new ReglaNegocioException("Seleccione un usuario de la tabla para editar.");
            // Validar los datos del usuario antes de actualizarlo
            usuario.Validar();
            // Verificar si ya existe otro usuario con el mismo documento
            if (_repositorio.ExisteDocumento(usuario.Documento, usuario.IdUsuario))
                throw new ReglaNegocioException("Ya existe otro usuario con ese documento.");
            // Llamar al repositorio para actualizar el usuario
            if (_repositorio.Actualizar(usuario) == 0)
                throw new ReglaNegocioException("El usuario seleccionado ya no existe.");
        }
        /// <summary>Elimina un usuario por su Id.</summary>
        public void Eliminar(int idUsuario)
        {
            // Validar que el IdUsuario sea válido antes de eliminarlo
            if (idUsuario <= 0)
                throw new ReglaNegocioException("Seleccione un usuario de la tabla para eliminar.");
            // Verificar si el usuario tiene préstamos asociados antes de eliminarlo
            int prestamos = _repositorio.ContarPrestamos(idUsuario);
            if (prestamos > 0)
                throw new ReglaNegocioException(
                    $"No se puede eliminar el usuario: tiene {prestamos} préstamo(s) registrado(s).");
            // Llamar al repositorio para eliminar el usuario
            _repositorio.Eliminar(idUsuario);
        }
    }
}
