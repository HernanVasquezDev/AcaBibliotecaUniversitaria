using AcaBiblioteca.Excepciones;
using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca.Modelos
{
    public class Libro
    {
        public const int LongitudMaximaIsbn = 20;
        public const int LongitudMaximaTitulo = 200;
        public const int LongitudMaximaCategoria = 100;

        private string _isbn = string.Empty;
        private string _titulo = string.Empty;
        private string _categoria = string.Empty;

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

        public string ISBN
        {
            get => _isbn;
            set => _isbn = value?.Trim() ?? string.Empty;
        }

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
