using System.Data;
using AcaBiblioteca.Modelos;
using AcaBiblioteca.Negocio;
using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca
{
    public partial class FrmEditoriales : Form
    {
        private readonly EditorialServicio _servicio = new EditorialServicio();
        private int _idSeleccionado;   // 0 = ninguna editorial seleccionada

        public FrmEditoriales()
        {
            InitializeComponent();
            CargarEditoriales();
        }

        private void CargarEditoriales()
        {
            try
            {
                dgvEditoriales.DataSource = _servicio.Listar();
                Grids.Encabezado(dgvEditoriales, "IdEditorial", "ID");
                dgvEditoriales.ClearSelection();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "cargar las editoriales");
            }
        }

        private void LimpiarFormulario()
        {
            _idSeleccionado = 0;
            txtNombre.Clear();
            dgvEditoriales.ClearSelection();
            txtNombre.Focus();
        }

        private void btnNuevo_Click(object? sender, EventArgs e) => LimpiarFormulario();

        private void btnCancelar_Click(object? sender, EventArgs e) => LimpiarFormulario();

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                _servicio.Registrar(new Editorial(txtNombre.Text));
                Mensajes.Informacion("Editorial guardada correctamente.");
                CargarEditoriales();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "guardar la editorial");
            }
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_idSeleccionado == 0)
                {
                    Mensajes.Advertencia("Seleccione una editorial de la tabla para editar.");
                    return;
                }

                _servicio.Actualizar(new Editorial(_idSeleccionado, txtNombre.Text));
                Mensajes.Informacion("Editorial actualizada correctamente.");
                CargarEditoriales();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "actualizar la editorial");
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_idSeleccionado == 0)
                {
                    Mensajes.Advertencia("Seleccione una editorial de la tabla para eliminar.");
                    return;
                }

                if (!Mensajes.Confirmar("¿Está seguro de eliminar esta editorial?"))
                    return;

                _servicio.Eliminar(_idSeleccionado);
                Mensajes.Informacion("Editorial eliminada correctamente.");
                CargarEditoriales();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "eliminar la editorial");
            }
        }

        private void dgvEditoriales_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvEditoriales.Rows[e.RowIndex];
            _idSeleccionado = Convert.ToInt32(fila.Cells["IdEditorial"].Value);
            txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
        }
    }
}
