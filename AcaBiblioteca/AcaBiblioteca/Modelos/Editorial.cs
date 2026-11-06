using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca.Modelos
{
    public class Editorial
    {
        public const int LongitudMaximaNombre = 150;

        private string _nombre = string.Empty;

        public Editorial()
        {
        }

        public Editorial(string nombre)
        {
            Nombre = nombre;
        }

        public Editorial(int idEditorial, string nombre)
        {
            IdEditorial = idEditorial;
            Nombre = nombre;
        }

        public int IdEditorial { get; set; }

        public string Nombre
        {
            get => _nombre;
            set => _nombre = value?.Trim() ?? string.Empty;
        }

        public void Validar()
        {
            Validador.Requerido(Nombre, "El nombre de la editorial", LongitudMaximaNombre);
        }

        public override string ToString() => Nombre;
    }
}
