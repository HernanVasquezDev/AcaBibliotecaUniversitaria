using AcaBiblioteca.Excepciones;

namespace AcaBiblioteca.Modelos
{
    public class Prestamo
    {
        private string _isbn = string.Empty;

        public Prestamo()
        {
            FechaPrestamo = DateTime.Today;
            Estado = EstadoPrestamo.Prestado;
        }

        public Prestamo(int idUsuario, string isbn, DateTime fechaPrestamo) : this()
        {
            IdUsuario = idUsuario;
            ISBN = isbn;
            FechaPrestamo = fechaPrestamo.Date;
        }

        public int IdPrestamo { get; set; }

        public int IdUsuario { get; set; }

        public string ISBN
        {
            get => _isbn;
            set => _isbn = value?.Trim() ?? string.Empty;
        }

        public DateTime FechaPrestamo { get; set; }

        public DateTime? FechaDevolucion { get; set; }

        public string Estado { get; set; }

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
