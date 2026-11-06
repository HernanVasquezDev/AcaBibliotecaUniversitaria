using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca.Modelos
{
    public class Editorial
    {
        //getters y setters
        public const int LongitudMaximaNombre = 150;

        private string _nombre = string.Empty;

        // constructor sin par�metros
        public Editorial()
        {
        }

        // constructor con todos los campos, excepto el IdEditorial, que se asigna autom�ticamente al insertar en la base de datos
        public Editorial(string nombre)
        {
            Nombre = nombre;
        }

        // constructor con todos los campos, incluyendo el IdEditorial
        public Editorial(int idEditorial, string nombre)
        {
            IdEditorial = idEditorial;
            Nombre = nombre;
        }

        // getters y setters
        public int IdEditorial { get; set; }

        public string Nombre
        {
            get => _nombre;
            set => _nombre = value?.Trim() ?? string.Empty;
        }

        // funcion para validar los datos de la editorial, en este caso solo el nombre
        public void Validar()
        {
            Validador.Requerido(Nombre, "El nombre de la editorial", LongitudMaximaNombre);
        }

        // sobrescribir el metodo ToString para que devuelva el nombre de la editorial
        public override string ToString() => Nombre;
    }
}
