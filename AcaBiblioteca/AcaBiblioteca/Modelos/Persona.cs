using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca.Modelos
{
    /// <summary>
    /// Clase base abstracta para las entidades que representan personas
    /// (autores y usuarios). Centraliza nombre, apellido y su validación.
    /// </summary>
    public abstract class Persona
    {
        // / <summary>Longitud máxima permitida para el campo Nombre.</summary>
        public const int LongitudMaximaNombre = 100;
        public const int LongitudMaximaApellido = 100;

        /// Campos privados para almacenar los valores de las propiedades
        private string _nombre = string.Empty;
        private string _apellido = string.Empty;

        /// <summary>Constructor protegido sin parámetros para permitir la herencia.</summary>
        protected Persona()
        {
        }
        /// <summary>Constructor protegido que inicializa nombre y apellido.</summary>
        protected Persona(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }
        /// <summary>Propiedad para el nombre de la persona.</summary>
        public string Nombre
        {
            get => _nombre;
            set => _nombre = value?.Trim() ?? string.Empty;
        }
        /// <summary>Propiedad para el apellido de la persona.</summary>
        public string Apellido
        {
            get => _apellido;
            set => _apellido = value?.Trim() ?? string.Empty;
        }
        /// <summary>Propiedad calculada que devuelve el nombre completo de la persona.</summary>
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
        /// funcion para sobrescribir el metodo ToString para que devuelva el nombre completo de la persona
        public override string ToString() => NombreCompleto;
    }
}
