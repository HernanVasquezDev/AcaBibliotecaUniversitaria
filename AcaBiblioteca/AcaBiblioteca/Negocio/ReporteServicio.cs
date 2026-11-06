using System.Data;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Excepciones;
using AcaBiblioteca.Modelos;

namespace AcaBiblioteca.Negocio
{
    public enum TipoReporte
    {
        ResumenConsolidado,
        ListadoLibros,
        LibrosDisponibles,
        LibrosMasPrestados,
        Autores,
        Editoriales,
        Usuarios,
        TodosLosPrestamos,
        PrestamosActivos,
        PrestamosDevueltos,
        HistorialPorUsuario
    }

    /// <summary>Elemento del catálogo de reportes (para enlazar a un ComboBox).</summary>
    public class ItemReporte
    {
        public ItemReporte(TipoReporte tipo, string nombre)
        {
            Tipo = tipo;
            Nombre = nombre;
        }

        public TipoReporte Tipo { get; }
        public string Nombre { get; }
    }

    public class ReporteServicio
    {
        private readonly ReporteRepositorio _reportes = new ReporteRepositorio();
        private readonly PrestamoRepositorio _prestamos = new PrestamoRepositorio();

        public static List<ItemReporte> Catalogo() => new List<ItemReporte>
        {
            new ItemReporte(TipoReporte.ResumenConsolidado, "Resumen consolidado de la biblioteca"),
            new ItemReporte(TipoReporte.ListadoLibros, "Listado de libros registrados"),
            new ItemReporte(TipoReporte.LibrosDisponibles, "Libros con existencias disponibles"),
            new ItemReporte(TipoReporte.LibrosMasPrestados, "Libros más prestados"),
            new ItemReporte(TipoReporte.Autores, "Listado de autores"),
            new ItemReporte(TipoReporte.Editoriales, "Listado de editoriales"),
            new ItemReporte(TipoReporte.Usuarios, "Listado de usuarios registrados"),
            new ItemReporte(TipoReporte.TodosLosPrestamos, "Relación de préstamos registrados"),
            new ItemReporte(TipoReporte.PrestamosActivos, "Préstamos activos (prestados)"),
            new ItemReporte(TipoReporte.PrestamosDevueltos, "Préstamos devueltos"),
            new ItemReporte(TipoReporte.HistorialPorUsuario, "Historial de préstamos por usuario")
        };

        public ResumenBiblioteca ObtenerResumen() => _reportes.ObtenerResumen();

        public DataTable Generar(TipoReporte tipo, int? idUsuario = null)
        {
            switch (tipo)
            {
                case TipoReporte.ResumenConsolidado: return ConstruirResumen();
                case TipoReporte.ListadoLibros: return _reportes.ListadoLibros();
                case TipoReporte.LibrosDisponibles: return _reportes.LibrosDisponibles();
                case TipoReporte.LibrosMasPrestados: return _reportes.LibrosMasPrestados();
                case TipoReporte.Autores: return _reportes.Autores();
                case TipoReporte.Editoriales: return _reportes.Editoriales();
                case TipoReporte.Usuarios: return _reportes.Usuarios();
                case TipoReporte.TodosLosPrestamos: return _prestamos.Listar(string.Empty);
                case TipoReporte.PrestamosActivos: return _prestamos.Listar(EstadoPrestamo.Prestado);
                case TipoReporte.PrestamosDevueltos: return _prestamos.Listar(EstadoPrestamo.Devuelto);
                case TipoReporte.HistorialPorUsuario:
                    if (!idUsuario.HasValue || idUsuario.Value <= 0)
                        throw new ReglaNegocioException(
                            "Seleccione un usuario para consultar su historial.");
                    return _reportes.HistorialPorUsuario(idUsuario.Value);
                default:
                    throw new ReglaNegocioException("El reporte solicitado no está disponible.");
            }
        }

        private DataTable ConstruirResumen()
        {
            ResumenBiblioteca r = _reportes.ObtenerResumen();

            DataTable tabla = new DataTable();
            tabla.Columns.Add("Indicador", typeof(string));
            tabla.Columns.Add("Valor", typeof(int));

            tabla.Rows.Add("Libros (títulos) registrados", r.TotalLibros);
            tabla.Rows.Add("Ejemplares disponibles (existencias)", r.TotalExistencias);
            tabla.Rows.Add("Autores", r.TotalAutores);
            tabla.Rows.Add("Editoriales", r.TotalEditoriales);
            tabla.Rows.Add("Usuarios", r.TotalUsuarios);
            tabla.Rows.Add("Préstamos registrados", r.TotalPrestamos);
            tabla.Rows.Add("Préstamos activos", r.PrestamosActivos);
            tabla.Rows.Add("Préstamos devueltos", r.PrestamosDevueltos);

            return tabla;
        }
    }
}
