using System.Data;
using AcaBiblioteca.Modelos;
using AcaBiblioteca.Negocio;
using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca
{
    public partial class FrmPrestamos : Form
    {
        private readonly PrestamoServicio _servicio = new PrestamoServicio();
        private readonly UsuarioServicio _usuarios = new UsuarioServicio();
        private readonly LibroServicio _libros = new LibroServicio();

        private int _idSeleccionado;          // 0 = ningún préstamo seleccionado
        private bool _inicializando = true;   // evita recargas mientras se arma el formulario

        public FrmPrestamos()
        {
            InitializeComponent();

            cmbFiltroEstado.Items.AddRange(new object[]
            {
                "Todos", EstadoPrestamo.Prestado, EstadoPrestamo.Devuelto
            });
            cmbFiltroEstado.SelectedIndex = 0;

            CargarCombos();
            CargarPrestamos();
            LimpiarFormulario();

            _inicializando = false;
        }

        // ---------- Carga de datos ----------

        private void CargarCombos()
        {
            try
            {
                cmbUsuario.DisplayMember = "Descripcion";
                cmbUsuario.ValueMember = "IdUsuario";
                cmbUsuario.DataSource = _usuarios.ListarParaCombo();

                cmbLibro.DisplayMember = "Descripcion";
                cmbLibro.ValueMember = "ISBN";
                cmbLibro.DataSource = _libros.ListarParaPrestamo();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "cargar los usuarios y libros");
            }
        }

        private void CargarPrestamos()
        {
            try
            {
                string estado = cmbFiltroEstado.SelectedIndex <= 0 ? string.Empty : cmbFiltroEstado.Text;
                DataTable tabla = _servicio.Listar(estado);

                dgvPrestamos.DataSource = tabla;
                Grids.Ocultar(dgvPrestamos, "IdUsuario");
                Grids.Encabezado(dgvPrestamos, "IdPrestamo", "ID");
                Grids.Encabezado(dgvPrestamos, "FechaPrestamo", "Fecha de préstamo");
                Grids.Encabezado(dgvPrestamos, "FechaDevolucion", "Fecha de devolución");
                Grids.FormatearFechas(dgvPrestamos);
                dgvPrestamos.ClearSelection();

                lblTotal.Text = $"{tabla.Rows.Count} registro(s)";
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "cargar los préstamos");
            }
        }

        // ---------- Estado del formulario ----------

        private void LimpiarFormulario()
        {
            _idSeleccionado = 0;
            cmbUsuario.SelectedIndex = -1;
            cmbLibro.SelectedIndex = -1;
            dtpFechaPrestamo.Value = DateTime.Today;
            dtpFechaDevolucion.Value = DateTime.Today;
            txtEstado.Clear();
            dgvPrestamos.ClearSelection();
            ActualizarControles();
        }

        /// <summary>Habilita solo las acciones válidas según el préstamo seleccionado.</summary>
        private void ActualizarControles()
        {
            bool haySeleccion = _idSeleccionado != 0;
            bool activo = txtEstado.Text == EstadoPrestamo.Prestado;
            bool editable = !haySeleccion || activo;

            cmbUsuario.Enabled = editable;
            cmbLibro.Enabled = editable;
            dtpFechaPrestamo.Enabled = editable;
            dtpFechaDevolucion.Enabled = haySeleccion && activo;

            btnGuardar.Enabled = !haySeleccion;
            btnEditar.Enabled = haySeleccion && activo;
            btnDevolver.Enabled = haySeleccion && activo;
            btnEliminar.Enabled = haySeleccion;
        }

        private void RefrescarTodo()
        {
            CargarCombos();       // las existencias cambian con cada operación
            CargarPrestamos();
            LimpiarFormulario();
        }

        private Prestamo? LeerFormulario()
        {
            if (cmbUsuario.SelectedIndex < 0)
            {
                Mensajes.Advertencia("Seleccione un usuario.");
                return null;
            }

            if (cmbLibro.SelectedIndex < 0)
            {
                Mensajes.Advertencia("Seleccione un libro.");
                return null;
            }

            return new Prestamo(Convert.ToInt32(cmbUsuario.SelectedValue),
                                Convert.ToString(cmbLibro.SelectedValue) ?? string.Empty,
                                dtpFechaPrestamo.Value.Date)
            {
                IdPrestamo = _idSeleccionado
            };
        }

        // ---------- Eventos ----------

        private void btnNuevo_Click(object? sender, EventArgs e) => LimpiarFormulario();

        private void btnCancelar_Click(object? sender, EventArgs e) => LimpiarFormulario();

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                Prestamo? prestamo = LeerFormulario();
                if (prestamo == null)
                    return;

                _servicio.Registrar(prestamo);
                Mensajes.Informacion("Préstamo registrado correctamente.");
                RefrescarTodo();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "registrar el préstamo");
            }
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            try
            {
                Prestamo? prestamo = LeerFormulario();
                if (prestamo == null)
                    return;

                _servicio.Actualizar(prestamo);
                Mensajes.Informacion("Préstamo actualizado correctamente.");
                RefrescarTodo();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "actualizar el préstamo");
            }
        }

        private void btnDevolver_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_idSeleccionado == 0)
                {
                    Mensajes.Advertencia("Seleccione un préstamo de la tabla para registrar su devolución.");
                    return;
                }

                _servicio.Devolver(_idSeleccionado, dtpFechaDevolucion.Value.Date);
                Mensajes.Informacion("Devolución registrada correctamente.");
                RefrescarTodo();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "registrar la devolución");
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_idSeleccionado == 0)
                {
                    Mensajes.Advertencia("Seleccione un préstamo de la tabla para eliminar.");
                    return;
                }

                string pregunta = txtEstado.Text == EstadoPrestamo.Prestado
                    ? "El préstamo sigue activo: al eliminarlo el libro volverá a las existencias.\n¿Desea continuar?"
                    : "¿Está seguro de eliminar este préstamo?";

                if (!Mensajes.Confirmar(pregunta))
                    return;

                _servicio.Eliminar(_idSeleccionado);
                Mensajes.Informacion("Préstamo eliminado correctamente.");
                RefrescarTodo();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "eliminar el préstamo");
            }
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_inicializando)
                return;

            CargarPrestamos();
            LimpiarFormulario();
        }

        private void dgvPrestamos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvPrestamos.Rows[e.RowIndex];

            _idSeleccionado = Convert.ToInt32(fila.Cells["IdPrestamo"].Value);
            cmbUsuario.SelectedValue = Convert.ToInt32(fila.Cells["IdUsuario"].Value);
            cmbLibro.SelectedValue = Convert.ToString(fila.Cells["ISBN"].Value) ?? string.Empty;
            dtpFechaPrestamo.Value = Convert.ToDateTime(fila.Cells["FechaPrestamo"].Value);

            object? devolucion = fila.Cells["FechaDevolucion"].Value;
            dtpFechaDevolucion.Value = devolucion == null || devolucion == DBNull.Value
                ? DateTime.Today
                : Convert.ToDateTime(devolucion);

            txtEstado.Text = Convert.ToString(fila.Cells["Estado"].Value);
            ActualizarControles();
        }
    }
}
