using System.Data;
using AcaBiblioteca.Modelos;
using AcaBiblioteca.Negocio;
using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca
{
    public partial class FrmLibros : Form
    {
        private readonly LibroServicio _servicio = new LibroServicio();
        private readonly AutorServicio _autores = new AutorServicio();
        private readonly EditorialServicio _editoriales = new EditorialServicio();

        public FrmLibros()
        {
            InitializeComponent();
            CargarAutores();
            CargarEditoriales();
            CargarLibros(null);
            LimpiarFormulario();
        }

        // ---------- Carga de datos ----------

        private void CargarLibros(string? filtro)
        {
            try
            {
                dgvLibros.DataSource = _servicio.Listar(filtro);

                Grids.Ocultar(dgvLibros, "IdAutor");
                Grids.Ocultar(dgvLibros, "IdEditorial");
                Grids.Encabezado(dgvLibros, "Titulo", "Título");
                Grids.Encabezado(dgvLibros, "Categoria", "Categoría");
                Grids.Encabezado(dgvLibros, "Anio", "Año");
                dgvLibros.ClearSelection();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "cargar los libros");
            }
        }

        private void CargarAutores()
        {
            try
            {
                cmbAutor.DisplayMember = "NombreCompleto";
                cmbAutor.ValueMember = "IdAutor";
                cmbAutor.DataSource = _autores.ListarParaCombo();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "cargar los autores");
            }
        }

        private void CargarEditoriales()
        {
            try
            {
                cmbEditorial.DisplayMember = "Nombre";
                cmbEditorial.ValueMember = "IdEditorial";
                cmbEditorial.DataSource = _editoriales.ListarParaCombo();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "cargar las editoriales");
            }
        }

        // ---------- Formulario ----------

        private void LimpiarFormulario()
        {
            txtISBN.Clear();
            txtTitulo.Clear();
            txtCategoria.Clear();
            txtAnio.Clear();
            txtExistencias.Clear();
            cmbAutor.SelectedIndex = -1;
            cmbEditorial.SelectedIndex = -1;
            dgvLibros.ClearSelection();

            txtISBN.Enabled = true;   // el ISBN solo es editable al registrar un libro nuevo
            txtISBN.Focus();
        }

        private void MostrarLibro(string isbn, string titulo, int idAutor, int idEditorial,
                                  string categoria, string anio, string existencias)
        {
            txtISBN.Text = isbn;
            txtTitulo.Text = titulo;
            cmbAutor.SelectedValue = idAutor;
            cmbEditorial.SelectedValue = idEditorial;
            txtCategoria.Text = categoria;
            txtAnio.Text = anio;
            txtExistencias.Text = existencias;

            txtISBN.Enabled = false;  // el ISBN identifica el registro y no se modifica
        }

        /// <summary>Convierte los campos del formulario en un Libro; devuelve null si hay datos inválidos.</summary>
        private Libro? LeerFormulario()
        {
            if (!int.TryParse(txtAnio.Text.Trim(), out int anio))
            {
                Mensajes.Advertencia("El año debe ser un número entero.");
                return null;
            }

            if (!int.TryParse(txtExistencias.Text.Trim(), out int existencias))
            {
                Mensajes.Advertencia("Las existencias deben ser un número entero.");
                return null;
            }

            int idAutor = cmbAutor.SelectedIndex < 0 ? 0 : Convert.ToInt32(cmbAutor.SelectedValue);
            int idEditorial = cmbEditorial.SelectedIndex < 0 ? 0 : Convert.ToInt32(cmbEditorial.SelectedValue);

            return new Libro(txtISBN.Text, txtTitulo.Text, idAutor, idEditorial,
                             txtCategoria.Text, anio, existencias);
        }

        // ---------- Eventos ----------

        private void btnBuscar_Click(object? sender, EventArgs e)
        {
            string filtro = txtBuscarISBN.Text.Trim();
            CargarLibros(filtro);

            if (filtro.Length == 0)
                return;

            if (dgvLibros.Rows.Count == 0)
                Mensajes.Informacion("No se encontraron libros con ese ISBN, título o autor.");
            else if (dgvLibros.Rows.Count == 1)
                dgvLibros_CellClick(null, new DataGridViewCellEventArgs(0, 0));
        }

        private void btnNuevo_Click(object? sender, EventArgs e) => LimpiarFormulario();

        private void btnCancelar_Click(object? sender, EventArgs e) => LimpiarFormulario();

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!txtISBN.Enabled)
                {
                    Mensajes.Advertencia("Está editando un libro existente. Use Editar para guardar los cambios " +
                                         "o Nuevo para registrar otro libro.");
                    return;
                }

                Libro? libro = LeerFormulario();
                if (libro == null)
                    return;

                _servicio.Registrar(libro);
                Mensajes.Informacion("Libro guardado correctamente.");
                CargarLibros(null);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "guardar el libro");
            }
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (txtISBN.Enabled)
                {
                    Mensajes.Advertencia("Seleccione un libro de la tabla para editar.");
                    return;
                }

                Libro? libro = LeerFormulario();
                if (libro == null)
                    return;

                _servicio.Actualizar(libro);
                Mensajes.Informacion("Libro actualizado correctamente.");
                CargarLibros(null);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "actualizar el libro");
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (txtISBN.Enabled || string.IsNullOrWhiteSpace(txtISBN.Text))
                {
                    Mensajes.Advertencia("Seleccione un libro de la tabla para eliminar.");
                    return;
                }

                if (!Mensajes.Confirmar("¿Está seguro de eliminar este libro?"))
                    return;

                _servicio.Eliminar(txtISBN.Text);
                Mensajes.Informacion("Libro eliminado correctamente.");
                CargarLibros(null);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                Mensajes.ManejarError(ex, "eliminar el libro");
            }
        }

        private void dgvLibros_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvLibros.Rows[e.RowIndex];

            MostrarLibro(
                Convert.ToString(fila.Cells["ISBN"].Value) ?? string.Empty,
                Convert.ToString(fila.Cells["Titulo"].Value) ?? string.Empty,
                Convert.ToInt32(fila.Cells["IdAutor"].Value),
                Convert.ToInt32(fila.Cells["IdEditorial"].Value),
                Convert.ToString(fila.Cells["Categoria"].Value) ?? string.Empty,
                Convert.ToString(fila.Cells["Anio"].Value) ?? string.Empty,
                Convert.ToString(fila.Cells["Existencias"].Value) ?? string.Empty);
        }
    }
}
