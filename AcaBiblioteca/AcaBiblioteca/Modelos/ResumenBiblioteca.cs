namespace AcaBiblioteca.Modelos
{
    /// <summary>Indicadores consolidados de la biblioteca.</summary>
    public class ResumenBiblioteca
    {
        public int TotalLibros { get; set; }
        public int TotalExistencias { get; set; }
        public int TotalAutores { get; set; }
        public int TotalEditoriales { get; set; }
        public int TotalUsuarios { get; set; }
        public int PrestamosActivos { get; set; }
        public int PrestamosDevueltos { get; set; }

        public int TotalPrestamos => PrestamosActivos + PrestamosDevueltos;
    }
}
