using System.Data;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Excepciones;
using AcaBiblioteca.Modelos;

namespace AcaBiblioteca.Negocio
{
    /// <summary>
    /// Reglas de préstamos y devoluciones:
    /// el usuario y el libro deben existir, el libro debe tener existencias,
    /// un usuario no puede tener dos veces el mismo libro activo y las fechas
    /// deben ser coherentes con el estado.
    /// </summary>
    public class PrestamoServicio
    {
        /// Campos privados para acceder a los repositorios de préstamos, usuarios y libros
        private readonly PrestamoRepositorio _prestamos = new PrestamoRepositorio();
        /// Campos privados para acceder a los repositorios de préstamos, usuarios y libros
        private readonly UsuarioRepositorio _usuarios = new UsuarioRepositorio();
        /// Campos privados para acceder a los repositorios de préstamos, usuarios y libros
        private readonly LibroRepositorio _libros = new LibroRepositorio();
        /// <summary>Lista todos los préstamos registrados en la base de datos, con un filtro opcional por estado.</summary>
        public DataTable Listar(string? estado = null) => _prestamos.Listar(estado);
        /// <summary>Obtiene un préstamo por su Id.</summary>
        public void Registrar(Prestamo prestamo)
        {
            prestamo.Estado = EstadoPrestamo.Prestado;
            prestamo.FechaDevolucion = null;
            prestamo.Validar();
            // Validar que el usuario y el libro existan y que el libro tenga existencias
            ValidarUsuarioYLibro(prestamo, exigirExistencias: true);
            // Verificar si el usuario ya tiene un préstamo activo del mismo libro
            if (_prestamos.ExistePrestamoActivo(prestamo.IdUsuario, prestamo.ISBN, 0))
                throw new ReglaNegocioException(
                    "El usuario ya tiene prestado este libro y aún no lo ha devuelto.");
            // Llamar al repositorio para registrar el nuevo préstamo
            _prestamos.Registrar(prestamo);
        }
        /// <summary>Actualiza los datos de un préstamo existente.</summary>
        public void Actualizar(Prestamo prestamo)
        {
            // Validar que el IdPrestamo sea válido
            if (prestamo.IdPrestamo <= 0)
                throw new ReglaNegocioException("Seleccione un préstamo de la tabla para editar.");
            // Obtener el préstamo actual de la base de datos
            Prestamo actual = ObtenerExistente(prestamo.IdPrestamo);
            // Validar que el préstamo esté activo antes de permitir la edición
            if (!actual.EstaActivo)
                throw new ReglaNegocioException(
                    "Solo se pueden editar los préstamos en estado 'Prestado'.");
            // Establecer el estado y la fecha de devolución para la validación
            prestamo.Estado = EstadoPrestamo.Prestado;
            // La fecha de devolución debe ser nula para un préstamo activo
            prestamo.FechaDevolucion = null;
            // Validar los datos del préstamo
            prestamo.Validar();
            // Validar que el usuario y el libro existan y que el libro tenga existencias si se cambia el libro
            bool cambiaLibro = !string.Equals(actual.ISBN, prestamo.ISBN,
                                              StringComparison.OrdinalIgnoreCase);
            // Validar que el usuario y el libro existan y que el libro tenga existencias si se cambia el libro
            ValidarUsuarioYLibro(prestamo, exigirExistencias: cambiaLibro);
            // Verificar si el usuario ya tiene un préstamo activo del mismo libro, excluyendo el préstamo actual
            if (_prestamos.ExistePrestamoActivo(prestamo.IdUsuario, prestamo.ISBN, prestamo.IdPrestamo))
                throw new ReglaNegocioException(
                    "El usuario ya tiene prestado este libro y aún no lo ha devuelto.");
            // Llamar al repositorio para actualizar el préstamo
            _prestamos.Actualizar(prestamo);
        }
        /// <summary>Registra la devolución de un préstamo existente.</summary>
        public void Devolver(int idPrestamo, DateTime fechaDevolucion)
        {
            // Validar que el IdPrestamo sea válido
            if (idPrestamo <= 0)
                throw new ReglaNegocioException("Seleccione un préstamo de la tabla para devolver.");
            // Obtener el préstamo actual de la base de datos
            Prestamo actual = ObtenerExistente(idPrestamo);
            // Validar que el préstamo esté activo antes de permitir la devolución
            if (!actual.EstaActivo)
                throw new ReglaNegocioException("Este préstamo ya fue devuelto.");
            // Validar que la fecha de devolución sea coherente con la fecha del préstamo y la fecha actual
            if (fechaDevolucion.Date < actual.FechaPrestamo.Date)
                throw new ReglaNegocioException(
                    "La fecha de devolución no puede ser anterior a la fecha del préstamo.");
            // Validar que la fecha de devolución no sea posterior a la fecha actual
            if (fechaDevolucion.Date > DateTime.Today)
                throw new ReglaNegocioException(
                    "La fecha de devolución no puede ser posterior a hoy.");
            // Llamar al repositorio para registrar la devolución del préstamo
            _prestamos.Devolver(idPrestamo, fechaDevolucion);
        }
        /// <summary>Elimina un préstamo por su Id.</summary>
        public void Eliminar(int idPrestamo)
        {
            // Validar que el IdPrestamo sea válido
            if (idPrestamo <= 0)
                throw new ReglaNegocioException("Seleccione un préstamo de la tabla para eliminar.");
            // Llamar al repositorio para eliminar el préstamo
            _prestamos.Eliminar(idPrestamo);
        }
        /// <summary>Obtiene un préstamo existente por su Id o lanza una excepción si no existe.</summary>
        private Prestamo ObtenerExistente(int idPrestamo)
        {
            // Llamar al repositorio para obtener el préstamo por su Id
            return _prestamos.Obtener(idPrestamo)
                   ?? throw new ReglaNegocioException("El préstamo seleccionado ya no existe.");
        }
        /// <summary>Valida que el usuario y el libro del préstamo existan en la base de datos y que el libro tenga existencias si se exige.</summary>
        private void ValidarUsuarioYLibro(Prestamo prestamo, bool exigirExistencias)
        {
            // Validar que el usuario exista en la base de datos
            if (!_usuarios.ExisteId(prestamo.IdUsuario))
                throw new ReglaNegocioException("El usuario seleccionado no existe.");
            // Validar que el libro exista en la base de datos y obtenerlo
            Libro libro = _libros.Obtener(prestamo.ISBN)
                          ?? throw new ReglaNegocioException("El libro seleccionado no existe.");
            // Validar que el libro tenga existencias si se exige
            if (exigirExistencias && !libro.HayDisponibilidad)
                throw new ReglaNegocioException(
                    $"No hay existencias disponibles de \"{libro.Titulo}\".");
        }
    }
}
