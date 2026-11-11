using AcaBiblioteca.Excepciones;

namespace AcaBiblioteca.Modelos
{
    /// <summary>Representa un préstamo de un libro a un usuario.</summary>
    public class Prestamo
    {
        /// Campos privados para almacenar los valores de las propiedades
        private string _isbn = string.Empty;

        /// <summary>Constructor sin parámetros que inicializa la fecha del préstamo y el estado.</summary>
    public class Prestamo
    {
        private string _isbn = string.Empty;

        public Prestamo()
        {
            FechaPrestamo = DateTime.Today;
            Estado = EstadoPrestamo.Prestado;
        }

        /// <summary>Constructor que inicializa el IdUsuario, ISBN y FechaPrestamo.</summary>
        public Prestamo(int idUsuario, string isbn, DateTime fechaPrestamo) : this()
        {
            IdUsuario = idUsuario;
            ISBN = isbn;
            FechaPrestamo = fechaPrestamo.Date;
        }
        /// <summary>Constructor que inicializa todos los campos del préstamo.</summary>

        public int IdPrestamo { get; set; }

        public int IdUsuario { get; set; }

        public string ISBN
        {
            get => _isbn;
            set => _isbn = value?.Trim() ?? string.Empty;
        }
        //getters y setters

        public DateTime FechaPrestamo { get; set; }

        public DateTime? FechaDevolucion { get; set; }

        public string Estado { get; set; }

        /// <summary>Propiedad calculada que indica si el préstamo está activo (no devuelto).</summary>
        public bool EstaActivo => Estado == EstadoPrestamo.Prestado;

        /// <summary>Valida los datos del préstamo y lanza excepciones si hay errores.</summary>
        public bool EstaActivo => Estado == EstadoPrestamo.Prestado;

        public void Validar()
        {
            if (IdUsuario <= 0)
                throw new ReglaNegocioException("Seleccione un usuario.");

            if (string.IsNullOrWhiteSpace(ISBN))
                throw new ReglaNegocioException("Seleccione un libro.");

            if (FechaPrestamo.Date > DateTime.Today)
                throw new ReglaNegocioException(
                    "La fecha del préstamo no puede ser posterior a hoy.");

            if (Estado != EstadoPrestamo.Prestado && Estado != EstadoPrestamo.Devuelto)
                throw new ReglaNegocioException("El estado del préstamo no es válido.");

            if (Estado == EstadoPrestamo.Prestado && FechaDevolucion.HasValue)
                throw new ReglaNegocioException(
                    "Un préstamo en estado 'Prestado' no puede tener fecha de devolución.");

            if (Estado == EstadoPrestamo.Devuelto && !FechaDevolucion.HasValue)
                throw new ReglaNegocioException(
                    "Un préstamo 'Devuelto' debe tener fecha de devolución.");

            if (FechaDevolucion.HasValue && FechaDevolucion.Value.Date < FechaPrestamo.Date)
                throw new ReglaNegocioException(
                    "La fecha de devolución no puede ser anterior a la fecha del préstamo.");
        }
    }
}
