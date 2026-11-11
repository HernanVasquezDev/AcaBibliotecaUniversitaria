using System.Data;
using AcaBiblioteca.Modelos;
using AcaBiblioteca.Negocio;
using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca
{
    public partial class FrmAutores : Form
    {
        private readonly AutorServicio _servicio = new AutorServicio();
        private int _idSeleccionado;   // 0 = ningún autor seleccionado

        public FrmAutores()
        {
            InitializeComponent();
            CargarAutores();
        }

        private void CargarAutores()
        {
            try
            {
                dgvAutores.DataSource = _servicio.Listar();
                Grids.Encabezado(dgvAutores, "IdAutor", "ID");
                dgvAutores.ClearSelection();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "cargar los autores");
            }
        }

        private void LimpiarFormulario()
        {
            _idSeleccionado = 0;
            txtNombre.Clear();
            txtApellido.Clear();
            dgvAutores.ClearSelection();
            txtNombre.Focus();
        }

        private void btnNuevo_Click(object? sender, EventArgs e) => LimpiarFormulario();

        private void btnCancelar_Click(object? sender, EventArgs e) => LimpiarFormulario();

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                _servicio.Registrar(new Autor(txtNombre.Text, txtApellido.Text));
                Mensajes.Informacion("Autor guardado correctamente.");
                CargarAutores();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "guardar el autor");
            }
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_idSeleccionado == 0)
                {
                    Mensajes.Advertencia("Seleccione un autor de la tabla para editar.");
                    return;
                }

                _servicio.Actualizar(new Autor(_idSeleccionado, txtNombre.Text, txtApellido.Text));
                Mensajes.Informacion("Autor actualizado correctamente.");
                CargarAutores();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "actualizar el autor");
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_idSeleccionado == 0)
                {
                    Mensajes.Advertencia("Seleccione un autor de la tabla para eliminar.");
                    return;
                }

                if (!Mensajes.Confirmar("¿Está seguro de eliminar este autor?"))
                    return;

                _servicio.Eliminar(_idSeleccionado);
                Mensajes.Informacion("Autor eliminado correctamente.");
                CargarAutores();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "eliminar el autor");
            }
        }

        private void dgvAutores_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvAutores.Rows[e.RowIndex];
            _idSeleccionado = Convert.ToInt32(fila.Cells["IdAutor"].Value);
            txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
            txtApellido.Text = fila.Cells["Apellido"].Value?.ToString();
        }
    }
}
