using System.Data;
using AcaBiblioteca.Modelos;
using AcaBiblioteca.Negocio;
using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca
{
    public partial class FrmUsuarios : Form
    {
        private readonly UsuarioServicio _servicio = new UsuarioServicio();
        private int _idSeleccionado;   // 0 = ningún usuario seleccionado

        public FrmUsuarios()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                dgvUsuarios.DataSource = _servicio.Listar();
                Grids.Encabezado(dgvUsuarios, "IdUsuario", "ID");
                Grids.Encabezado(dgvUsuarios, "Telefono", "Teléfono");
                dgvUsuarios.ClearSelection();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "cargar los usuarios");
            }
        }

        private Usuario LeerFormulario(int idUsuario)
        {
            return new Usuario(txtNombre.Text, txtApellido.Text, txtDocumento.Text,
                               txtTelefono.Text, txtCorreo.Text)
            {
                IdUsuario = idUsuario
            };
        }

        private void LimpiarFormulario()
        {
            _idSeleccionado = 0;
            txtNombre.Clear();
            txtApellido.Clear();
            txtDocumento.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            dgvUsuarios.ClearSelection();
            txtNombre.Focus();
        }

        private void btnNuevo_Click(object? sender, EventArgs e) => LimpiarFormulario();

        private void btnCancelar_Click(object? sender, EventArgs e) => LimpiarFormulario();

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                _servicio.Registrar(LeerFormulario(0));
                Mensajes.Informacion("Usuario guardado correctamente.");
                CargarUsuarios();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "guardar el usuario");
            }
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_idSeleccionado == 0)
                {
                    Mensajes.Advertencia("Seleccione un usuario de la tabla para editar.");
                    return;
                }

                _servicio.Actualizar(LeerFormulario(_idSeleccionado));
                Mensajes.Informacion("Usuario actualizado correctamente.");
                CargarUsuarios();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "actualizar el usuario");
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_idSeleccionado == 0)
                {
                    Mensajes.Advertencia("Seleccione un usuario de la tabla para eliminar.");
                    return;
                }

                if (!Mensajes.Confirmar("¿Está seguro de eliminar este usuario?"))
                    return;

                _servicio.Eliminar(_idSeleccionado);
                Mensajes.Informacion("Usuario eliminado correctamente.");
                CargarUsuarios();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "eliminar el usuario");
            }
        }

        private void dgvUsuarios_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];
            _idSeleccionado = Convert.ToInt32(fila.Cells["IdUsuario"].Value);
            txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
            txtApellido.Text = fila.Cells["Apellido"].Value?.ToString();
            txtDocumento.Text = fila.Cells["Documento"].Value?.ToString();
            txtTelefono.Text = fila.Cells["Telefono"].Value?.ToString();
            txtCorreo.Text = fila.Cells["Correo"].Value?.ToString();
        }
    }
}
