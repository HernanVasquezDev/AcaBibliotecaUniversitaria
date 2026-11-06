using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca.Modelos
{
    /// <summary>
    /// Clase base abstracta para las entidades que representan personas
    /// (autores y usuarios). Centraliza nombre, apellido y su validación.
    /// </summary>
    public abstract class Persona
    {
        public const int LongitudMaximaNombre = 100;
        public const int LongitudMaximaApellido = 100;

        private string _nombre = string.Empty;
        private string _apellido = string.Empty;

        protected Persona()
        {
        }

        protected Persona(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        public string Nombre
        {
            get => _nombre;
            set => _nombre = value?.Trim() ?? string.Empty;
        }

        public string Apellido
        {
            get => _apellido;
            set => _apellido = value?.Trim() ?? string.Empty;
        }

        public string NombreCompleto => $"{Nombre} {Apellido}".Trim();

        /// <summary>
        /// Valida los datos de la persona. Las clases derivadas pueden
        /// sobrescribirlo para agregar sus propias reglas (polimorfismo).
        /// </summary>
        public virtual void Validar()
        {
            Validador.Requerido(Nombre, "El nombre", LongitudMaximaNombre);
            Validador.Requerido(Apellido, "El apellido", LongitudMaximaApellido);
        }

        public override string ToString() => NombreCompleto;
    }
}
