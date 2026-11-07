using AcaBiblioteca.Modelos;
using AcaBiblioteca.Negocio;
using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
            CargarResumen();
        }

        /// <summary>
        /// Muestra los indicadores de la biblioteca. También sirve como
        /// verificación de la conexión con SQL Server al abrir la aplicación.
        /// </summary>
        private void CargarResumen()
        {
            try
            {
                ResumenBiblioteca resumen = new ReporteServicio().ObtenerResumen();

                lblTotalLibros.Text = resumen.TotalLibros.ToString();
                lblTotalExistencias.Text = resumen.TotalExistencias.ToString();
                lblPrestamosActivos.Text = resumen.PrestamosActivos.ToString();
                lblTotalUsuarios.Text = resumen.TotalUsuarios.ToString();
                lblTotalAutores.Text = resumen.TotalAutores.ToString();
                lblTotalEditoriales.Text = resumen.TotalEditoriales.ToString();
            }
            catch (Exception ex)
            {
                Mensajes.Error("No fue posible consultar la base de datos.\n" +
                               "Verifique que SQL Server esté en ejecución y la cadena de conexión en Datos\\Conexion.cs.\n\n" +
                               "Detalle: " + ex.Message);
            }
        }
    }
}
