using System.Data;
using AcaBiblioteca.Negocio;
using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca
{
    public partial class FrmReportes : Form
    {
        private readonly ReporteServicio _servicio = new ReporteServicio();
        private readonly UsuarioServicio _usuarios = new UsuarioServicio();
        private DataTable? _tablaActual;

        public FrmReportes()
        {
            InitializeComponent();

            cmbReporte.DisplayMember = nameof(ItemReporte.Nombre);
            cmbReporte.ValueMember = nameof(ItemReporte.Tipo);
            cmbReporte.DataSource = ReporteServicio.Catalogo();

            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                cmbUsuarioReporte.DisplayMember = "Descripcion";
                cmbUsuarioReporte.ValueMember = "IdUsuario";
                cmbUsuarioReporte.DataSource = _usuarios.ListarParaCombo();
                cmbUsuarioReporte.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "cargar los usuarios");
            }
        }

        private ItemReporte? ReporteSeleccionado => cmbReporte.SelectedItem as ItemReporte;

        private void cmbReporte_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // El selector de usuario solo aplica al historial por usuario.
            cmbUsuarioReporte.Enabled = ReporteSeleccionado?.Tipo == TipoReporte.HistorialPorUsuario;
        }

        private void btnGenerar_Click(object? sender, EventArgs e)
        {
            try
            {
                ItemReporte? reporte = ReporteSeleccionado;
                if (reporte == null)
                {
                    Mensajes.Advertencia("Seleccione un reporte.");
                    return;
                }

                int? idUsuario = null;
                if (reporte.Tipo == TipoReporte.HistorialPorUsuario)
                {
                    if (cmbUsuarioReporte.SelectedIndex < 0)
                    {
                        Mensajes.Advertencia("Seleccione un usuario para consultar su historial.");
                        return;
                    }
                    idUsuario = Convert.ToInt32(cmbUsuarioReporte.SelectedValue);
                }

                _tablaActual = _servicio.Generar(reporte.Tipo, idUsuario);

                dgvReporte.DataSource = _tablaActual;
                Grids.Encabezado(dgvReporte, "IdPrestamo", "ID préstamo");
                Grids.Encabezado(dgvReporte, "FechaPrestamo", "Fecha de préstamo");
                Grids.Encabezado(dgvReporte, "FechaDevolucion", "Fecha de devolución");
                Grids.FormatearFechas(dgvReporte);
                dgvReporte.ClearSelection();

                lblRegistros.Text = $"{reporte.Nombre}: {_tablaActual.Rows.Count} registro(s).";
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "generar el reporte");
            }
        }

        private void btnExportar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_tablaActual == null || _tablaActual.Rows.Count == 0)
                {
                    Mensajes.Advertencia("Genere primero un reporte que tenga registros.");
                    return;
                }

                string nombre = ReporteSeleccionado?.Nombre ?? "Reporte";
                foreach (char invalido in Path.GetInvalidFileNameChars())
                    nombre = nombre.Replace(invalido, '_');

                using SaveFileDialog dialogo = new SaveFileDialog
                {
                    Filter = "Archivo CSV (*.csv)|*.csv",
                    FileName = $"{nombre}_{DateTime.Now:yyyyMMdd}.csv"
                };

                if (dialogo.ShowDialog() != DialogResult.OK)
                    return;

                ExportadorCsv.Exportar(_tablaActual, dialogo.FileName);
                Mensajes.Informacion("Reporte exportado correctamente.");
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "exportar el reporte");
            }
        }
    }
}
