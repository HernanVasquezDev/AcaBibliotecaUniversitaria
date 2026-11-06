using System.Data;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Excepciones;
using AcaBiblioteca.Modelos;

namespace AcaBiblioteca.Negocio
{
    /// <summary>Servicio para la generación de reportes.</summary>
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
        /// <summary>Constructor que inicializa un elemento del catálogo de reportes.</summary>
        public ItemReporte(TipoReporte tipo, string nombre)
        {
            Tipo = tipo;
            Nombre = nombre;
        }
        /// <summary>Tipo de reporte.</summary>
        public TipoReporte Tipo { get; }
        public string Nombre { get; }
    }
    /// <summary>Servicio para la generación de reportes.</summary>
    public class ReporteServicio
    {
        /// Campos privados para acceder a los repositorios de reportes y préstamos
        private readonly ReporteRepositorio _reportes = new ReporteRepositorio();
        private readonly PrestamoRepositorio _prestamos = new PrestamoRepositorio();
        /// <summary>Obtiene el catálogo de reportes disponibles.</summary>
        public static List<ItemReporte> Catalogo() => new List<ItemReporte>
        {
            /// Elementos del catálogo de reportes con su tipo y nombre descriptivo
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
        /// <summary>Obtiene un resumen consolidado de la biblioteca.</summary>
        public ResumenBiblioteca ObtenerResumen() => _reportes.ObtenerResumen();
        /// <summary>Genera un reporte según el tipo especificado y un Id de usuario opcional.</summary>
        public DataTable Generar(TipoReporte tipo, int? idUsuario = null)
        {
            // Generar el reporte según el tipo especificado
            switch (tipo)
            {
                // Llamar al método correspondiente del repositorio de reportes o construir el resumen consolidado
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
                // Validar que se proporcione un Id de usuario válido para el historial por usuario
                case TipoReporte.HistorialPorUsuario:
                    // Validar que se proporcione un Id de usuario válido para el historial por usuario
                    if (!idUsuario.HasValue || idUsuario.Value <= 0)
                        throw new ReglaNegocioException(
                            "Seleccione un usuario para consultar su historial.");
                    // Llamar al repositorio de reportes para obtener el historial por usuario
                    return _reportes.HistorialPorUsuario(idUsuario.Value);
                // Lanzar una excepción si el tipo de reporte no está disponible
                default:
                    throw new ReglaNegocioException("El reporte solicitado no está disponible.");
            }
        }
        /// <summary>Construye un resumen consolidado de la biblioteca en forma de DataTable.</summary>
        private DataTable ConstruirResumen()
        {
            // Obtener el resumen consolidado de la biblioteca desde el repositorio de reportes
            ResumenBiblioteca r = _reportes.ObtenerResumen();

            // Crear un DataTable para almacenar los indicadores y sus valores
            DataTable tabla = new DataTable();
            // Agregar columnas al DataTable para el indicador y su valor
            tabla.Columns.Add("Indicador", typeof(string));
            tabla.Columns.Add("Valor", typeof(int));
            // Agregar filas al DataTable con los indicadores y sus valores correspondientes
            tabla.Rows.Add("Libros (títulos) registrados", r.TotalLibros);
            tabla.Rows.Add("Ejemplares disponibles (existencias)", r.TotalExistencias);
            tabla.Rows.Add("Autores", r.TotalAutores);
            tabla.Rows.Add("Editoriales", r.TotalEditoriales);
            tabla.Rows.Add("Usuarios", r.TotalUsuarios);
            tabla.Rows.Add("Préstamos registrados", r.TotalPrestamos);
            tabla.Rows.Add("Préstamos activos", r.PrestamosActivos);
            tabla.Rows.Add("Préstamos devueltos", r.PrestamosDevueltos);
            // Devolver el DataTable con el resumen consolidado
            return tabla;
        }
    }
}
