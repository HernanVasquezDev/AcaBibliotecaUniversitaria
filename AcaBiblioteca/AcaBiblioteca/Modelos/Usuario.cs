using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca.Modelos
{
    public class Usuario : Persona
    {
        public const int LongitudMaximaDocumento = 30;
        public const int LongitudMaximaTelefono = 30;
        public const int LongitudMaximaCorreo = 150;

        private string _documento = string.Empty;
        private string? _telefono;
        private string? _correo;

        public Usuario()
        {
        }

        public Usuario(string nombre, string apellido, string documento,
                       string? telefono, string? correo)
            : base(nombre, apellido)
        {
            Documento = documento;
            Telefono = telefono;
            Correo = correo;
        }

        public int IdUsuario { get; set; }

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
