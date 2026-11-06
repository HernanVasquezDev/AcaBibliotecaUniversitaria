using AcaBiblioteca.Excepciones;
using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca.Modelos
{
    /// <summary>Representa un libro de la biblioteca.</summary>
    public class Libro
    {
        //getters y setters 
        // Constantes para la validación de los campos
    public class Libro
    {
        public const int LongitudMaximaIsbn = 20;
        public const int LongitudMaximaTitulo = 200;
        public const int LongitudMaximaCategoria = 100;

        // Campos privados para almacenar los valores de las propiedades
        private string _isbn = string.Empty;
        private string _titulo = string.Empty;
        private string _categoria = string.Empty;

        // Constructor sin parámetros
        public Libro()
        {
        }
        // Constructor con todos los campos, excepto el ISBN, que se asigna automáticamente al insertar en la base de datos
        public Libro()
        {
        }

        public Libro(string isbn, string titulo, int idAutor, int idEditorial,
                     string categoria, int anio, int existencias)
        {
            ISBN = isbn;
            Titulo = titulo;
            IdAutor = idAutor;
            IdEditorial = idEditorial;
            Categoria = categoria;
            Anio = anio;
            Existencias = existencias;
        }

        // Constructor con todos los campos, incluyendo el ISBN
        public string ISBN
        {
            get => _isbn;
            set => _isbn = value?.Trim() ?? string.Empty;
        }
        //getters y setters

        public string Titulo
        {
            get => _titulo;
            set => _titulo = value?.Trim() ?? string.Empty;
        }

        public int IdAutor { get; set; }

        public int IdEditorial { get; set; }

        public string Categoria
        {
            get => _categoria;
            set => _categoria = value?.Trim() ?? string.Empty;
        }

        public int Anio { get; set; }

        public int Existencias { get; set; }

        // Propiedad calculada que indica si hay existencias disponibles del libro
        public bool HayDisponibilidad => Existencias > 0;

        // Método para validar los datos del libro, lanzando excepciones si algún dato no es válido
        public bool HayDisponibilidad => Existencias > 0;

        public void Validar()
        {
            Validador.Requerido(ISBN, "El ISBN", LongitudMaximaIsbn);
            Validador.Codigo(ISBN, "El ISBN");
            Validador.Requerido(Titulo, "El título", LongitudMaximaTitulo);
            Validador.Requerido(Categoria, "La categoría", LongitudMaximaCategoria);

            if (IdAutor <= 0)
                throw new ReglaNegocioException("Seleccione un autor.");

            if (IdEditorial <= 0)
                throw new ReglaNegocioException("Seleccione una editorial.");

            if (Anio < 1 || Anio > DateTime.Today.Year)
                throw new ReglaNegocioException(
                    $"El año debe estar entre 1 y {DateTime.Today.Year}.");

            if (Existencias < 0)
                throw new ReglaNegocioException("Las existencias no pueden ser negativas.");
        }
    }
}
