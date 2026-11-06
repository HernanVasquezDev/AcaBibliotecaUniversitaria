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
        private readonly PrestamoRepositorio _prestamos = new PrestamoRepositorio();
        private readonly UsuarioRepositorio _usuarios = new UsuarioRepositorio();
        private readonly LibroRepositorio _libros = new LibroRepositorio();

        public DataTable Listar(string? estado = null) => _prestamos.Listar(estado);

        public void Registrar(Prestamo prestamo)
        {
            prestamo.Estado = EstadoPrestamo.Prestado;
            prestamo.FechaDevolucion = null;
            prestamo.Validar();

            ValidarUsuarioYLibro(prestamo, exigirExistencias: true);

            if (_prestamos.ExistePrestamoActivo(prestamo.IdUsuario, prestamo.ISBN, 0))
                throw new ReglaNegocioException(
                    "El usuario ya tiene prestado este libro y aún no lo ha devuelto.");

            _prestamos.Registrar(prestamo);
        }

        public void Actualizar(Prestamo prestamo)
        {
            if (prestamo.IdPrestamo <= 0)
                throw new ReglaNegocioException("Seleccione un préstamo de la tabla para editar.");

            Prestamo actual = ObtenerExistente(prestamo.IdPrestamo);

            if (!actual.EstaActivo)
                throw new ReglaNegocioException(
                    "Solo se pueden editar los préstamos en estado 'Prestado'.");

            prestamo.Estado = EstadoPrestamo.Prestado;
            prestamo.FechaDevolucion = null;
            prestamo.Validar();

            bool cambiaLibro = !string.Equals(actual.ISBN, prestamo.ISBN,
                                              StringComparison.OrdinalIgnoreCase);
            ValidarUsuarioYLibro(prestamo, exigirExistencias: cambiaLibro);

            if (_prestamos.ExistePrestamoActivo(prestamo.IdUsuario, prestamo.ISBN, prestamo.IdPrestamo))
                throw new ReglaNegocioException(
                    "El usuario ya tiene prestado este libro y aún no lo ha devuelto.");

            _prestamos.Actualizar(prestamo);
        }

        public void Devolver(int idPrestamo, DateTime fechaDevolucion)
        {
            if (idPrestamo <= 0)
                throw new ReglaNegocioException("Seleccione un préstamo de la tabla para devolver.");

            Prestamo actual = ObtenerExistente(idPrestamo);

            if (!actual.EstaActivo)
                throw new ReglaNegocioException("Este préstamo ya fue devuelto.");

            if (fechaDevolucion.Date < actual.FechaPrestamo.Date)
                throw new ReglaNegocioException(
                    "La fecha de devolución no puede ser anterior a la fecha del préstamo.");

            if (fechaDevolucion.Date > DateTime.Today)
                throw new ReglaNegocioException(
                    "La fecha de devolución no puede ser posterior a hoy.");

            _prestamos.Devolver(idPrestamo, fechaDevolucion);
        }

        public void Eliminar(int idPrestamo)
        {
            if (idPrestamo <= 0)
                throw new ReglaNegocioException("Seleccione un préstamo de la tabla para eliminar.");

            _prestamos.Eliminar(idPrestamo);
        }

        private Prestamo ObtenerExistente(int idPrestamo)
        {
            return _prestamos.Obtener(idPrestamo)
                   ?? throw new ReglaNegocioException("El préstamo seleccionado ya no existe.");
        }

        private void ValidarUsuarioYLibro(Prestamo prestamo, bool exigirExistencias)
        {
            if (!_usuarios.ExisteId(prestamo.IdUsuario))
                throw new ReglaNegocioException("El usuario seleccionado no existe.");

            Libro libro = _libros.Obtener(prestamo.ISBN)
                          ?? throw new ReglaNegocioException("El libro seleccionado no existe.");

            if (exigirExistencias && !libro.HayDisponibilidad)
                throw new ReglaNegocioException(
                    $"No hay existencias disponibles de \"{libro.Titulo}\".");
        }
    }
}
