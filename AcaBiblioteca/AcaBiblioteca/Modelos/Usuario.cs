using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca.Modelos
{
    /// <summary>Representa un usuario de la biblioteca.</summary>
    public class Usuario : Persona
    {
        // Constantes para la validación de los campos
        public const int LongitudMaximaDocumento = 30;
        public const int LongitudMaximaTelefono = 30;
        public const int LongitudMaximaCorreo = 150;

        // Campos privados para almacenar los valores de las propiedades
        private string _documento = string.Empty;
        private string? _telefono;
        private string? _correo;

        /// <summary>Constructor sin parámetros que inicializa un usuario vacío.</summary>
        public Usuario()
        {
        }

        /// <summary>Constructor que inicializa nombre, apellido y documento del usuario.</summary>
        public Usuario(string nombre, string apellido, string documento,
                       string? telefono, string? correo)
            : base(nombre, apellido)
        {
            Documento = documento;
            Telefono = telefono;
            Correo = correo;
        }
        /// <summary>Constructor que inicializa todos los campos del usuario, incluyendo el IdUsuario.</summary>
        public int IdUsuario { get; set; }

        /// <summary>Propiedad para el documento del usuario.</summary>
        public string Documento
        {
            get => _documento;
            set => _documento = value?.Trim() ?? string.Empty;
        }

        public string? Telefono
        {
            get => _telefono;
            set => _telefono = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }

        public string? Correo
        {
            get => _correo;
            set => _correo = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }
        // propiedad calculada que devuelve el nombre completo del usuario
        public override void Validar()
        {
            base.Validar();

            Validador.Requerido(Documento, "El documento", LongitudMaximaDocumento);
            Validador.Documento(Documento);

            Validador.LongitudOpcional(Telefono, "El teléfono", LongitudMaximaTelefono);
            Validador.Telefono(Telefono);

            Validador.LongitudOpcional(Correo, "El correo electrónico", LongitudMaximaCorreo);
            Validador.Correo(Correo);
        }
    }
}
