namespace AcaBiblioteca
{
    partial class FrmPrestamos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlTitulo = new Panel();
            lblTitulo = new Label();
            pnlDatos = new Panel();
            tlpCampos = new TableLayoutPanel();
            lblUsuario = new Label();
            cmbUsuario = new ComboBox();
            lblLibro = new Label();
            cmbLibro = new ComboBox();
            lblFechaPrestamo = new Label();
            dtpFechaPrestamo = new DateTimePicker();
            lblFechaDevolucion = new Label();
            dtpFechaDevolucion = new DateTimePicker();
            lblEstado = new Label();
            txtEstado = new TextBox();
            pnlBotones = new Panel();
            tlpBotones = new TableLayoutPanel();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnDevolver = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();
            pnlFiltro = new Panel();
            lblFiltro = new Label();
            cmbFiltroEstado = new ComboBox();
            lblTotal = new Label();
            dgvPrestamos = new DataGridView();
            pnlTitulo.SuspendLayout();
            pnlDatos.SuspendLayout();
            tlpCampos.SuspendLayout();
            pnlBotones.SuspendLayout();
            tlpBotones.SuspendLayout();
            pnlFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).BeginInit();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.BackColor = Color.RoyalBlue;
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Size = new Size(1000, 60);
            pnlTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Text = "GESTIÓN DE PRÉSTAMOS";
            // 
            // pnlDatos
            // 
            pnlDatos.Name = "pnlDatos";
            pnlDatos.Dock = DockStyle.Top;
            pnlDatos.Size = new Size(1000, 230);
            pnlDatos.TabIndex = 1;
            // 
            // tlpCampos
            // 
            tlpCampos.Name = "tlpCampos";
            tlpCampos.Dock = DockStyle.Fill;
            tlpCampos.ColumnCount = 4;
            tlpCampos.RowCount = 5;
            tlpCampos.Padding = new Padding(0, 15, 0, 15);
            tlpCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 380F));
            tlpCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            // 
            // lblUsuario
            // 
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Anchor = AnchorStyles.Right;
            lblUsuario.AutoSize = true;
            lblUsuario.Margin = new Padding(0, 0, 10, 0);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario :";
            // 
            // cmbUsuario
            // 
            cmbUsuario.Name = "cmbUsuario";
            cmbUsuario.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbUsuario.TabIndex = 1;
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // lblLibro
            // 
            lblLibro.Name = "lblLibro";
            lblLibro.Anchor = AnchorStyles.Right;
            lblLibro.AutoSize = true;
            lblLibro.Margin = new Padding(0, 0, 10, 0);
            lblLibro.TabIndex = 2;
            lblLibro.Text = "Libro :";
            // 
            // cmbLibro
            // 
            cmbLibro.Name = "cmbLibro";
            cmbLibro.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbLibro.TabIndex = 3;
            cmbLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // lblFechaPrestamo
            // 
            lblFechaPrestamo.Name = "lblFechaPrestamo";
            lblFechaPrestamo.Anchor = AnchorStyles.Right;
            lblFechaPrestamo.AutoSize = true;
            lblFechaPrestamo.Margin = new Padding(0, 0, 10, 0);
            lblFechaPrestamo.TabIndex = 4;
            lblFechaPrestamo.Text = "Fecha de préstamo :";
            // 
            // dtpFechaPrestamo
            // 
            dtpFechaPrestamo.Name = "dtpFechaPrestamo";
            dtpFechaPrestamo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpFechaPrestamo.TabIndex = 5;
            dtpFechaPrestamo.Format = DateTimePickerFormat.Short;
            // 
            // lblFechaDevolucion
            // 
            lblFechaDevolucion.Name = "lblFechaDevolucion";
            lblFechaDevolucion.Anchor = AnchorStyles.Right;
            lblFechaDevolucion.AutoSize = true;
            lblFechaDevolucion.Margin = new Padding(0, 0, 10, 0);
            lblFechaDevolucion.TabIndex = 6;
            lblFechaDevolucion.Text = "Fecha de devolución :";
            // 
            // dtpFechaDevolucion
            // 
            dtpFechaDevolucion.Name = "dtpFechaDevolucion";
            dtpFechaDevolucion.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpFechaDevolucion.TabIndex = 7;
            dtpFechaDevolucion.Format = DateTimePickerFormat.Short;
            // 
            // lblEstado
            // 
            lblEstado.Name = "lblEstado";
            lblEstado.Anchor = AnchorStyles.Right;
            lblEstado.AutoSize = true;
            lblEstado.Margin = new Padding(0, 0, 10, 0);
            lblEstado.TabIndex = 8;
            lblEstado.Text = "Estado :";
            // 
            // txtEstado
            // 
            txtEstado.Name = "txtEstado";
            txtEstado.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtEstado.TabIndex = 9;
            txtEstado.ReadOnly = true;
            // 
            // pnlBotones
            // 
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Dock = DockStyle.Top;
            pnlBotones.Size = new Size(1000, 60);
            pnlBotones.TabIndex = 2;
            // 
            // tlpBotones
            // 
            tlpBotones.Name = "tlpBotones";
            tlpBotones.Dock = DockStyle.Fill;
            tlpBotones.ColumnCount = 8;
            tlpBotones.RowCount = 1;
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpBotones.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            // 
            // btnNuevo
            // 
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Dock = DockStyle.Fill;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.BackColor = Color.Gainsboro;
            btnNuevo.ForeColor = Color.Black;
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.Margin = new Padding(6, 10, 6, 10);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Dock = DockStyle.Fill;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.BackColor = Color.SeaGreen;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Margin = new Padding(6, 10, 6, 10);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Registrar préstamo";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Name = "btnEditar";
            btnEditar.Dock = DockStyle.Fill;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.BackColor = Color.RoyalBlue;
            btnEditar.ForeColor = Color.White;
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.Margin = new Padding(6, 10, 6, 10);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnDevolver
            // 
            btnDevolver.Name = "btnDevolver";
            btnDevolver.Dock = DockStyle.Fill;
            btnDevolver.FlatAppearance.BorderSize = 0;
            btnDevolver.FlatStyle = FlatStyle.Flat;
            btnDevolver.BackColor = Color.DarkOrange;
            btnDevolver.ForeColor = Color.White;
            btnDevolver.Cursor = Cursors.Hand;
            btnDevolver.Margin = new Padding(6, 10, 6, 10);
            btnDevolver.TabIndex = 3;
            btnDevolver.Text = "Registrar devolución";
            btnDevolver.UseVisualStyleBackColor = false;
            btnDevolver.Click += btnDevolver_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Dock = DockStyle.Fill;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.BackColor = Color.Firebrick;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Margin = new Padding(6, 10, 6, 10);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Dock = DockStyle.Fill;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.BackColor = Color.Gainsboro;
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Margin = new Padding(6, 10, 6, 10);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pnlFiltro
            // 
            pnlFiltro.Name = "pnlFiltro";
            pnlFiltro.Dock = DockStyle.Top;
            pnlFiltro.Size = new Size(1000, 45);
            pnlFiltro.TabIndex = 3;
            // 
            // lblFiltro
            // 
            lblFiltro.Name = "lblFiltro";
            lblFiltro.AutoSize = true;
            lblFiltro.Location = new Point(20, 13);
            lblFiltro.Text = "Mostrar préstamos:";
            // 
            // cmbFiltroEstado
            // 
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroEstado.Location = new Point(150, 9);
            cmbFiltroEstado.Size = new Size(160, 23);
            cmbFiltroEstado.SelectedIndexChanged += cmbFiltroEstado_SelectedIndexChanged;
            // 
            // lblTotal
            // 
            lblTotal.Name = "lblTotal";
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(340, 13);
            lblTotal.Text = "";
            // 
            // dgvPrestamos
            // 
            dgvPrestamos.Name = "dgvPrestamos";
            dgvPrestamos.AllowUserToAddRows = false;
            dgvPrestamos.AllowUserToDeleteRows = false;
            dgvPrestamos.AllowUserToResizeRows = false;
            dgvPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrestamos.BackgroundColor = Color.White;
            dgvPrestamos.Dock = DockStyle.Fill;
            dgvPrestamos.MultiSelect = false;
            dgvPrestamos.ReadOnly = true;
            dgvPrestamos.RowHeadersVisible = false;
            dgvPrestamos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrestamos.TabIndex = 4;
            dgvPrestamos.CellClick += dgvPrestamos_CellClick;
            // 
            // FrmPrestamos
            // 
            pnlTitulo.Controls.Add(lblTitulo);
            pnlDatos.Controls.Add(tlpCampos);
            tlpCampos.Controls.Add(lblUsuario, 1, 0);
            tlpCampos.Controls.Add(cmbUsuario, 2, 0);
            tlpCampos.Controls.Add(lblLibro, 1, 1);
            tlpCampos.Controls.Add(cmbLibro, 2, 1);
            tlpCampos.Controls.Add(lblFechaPrestamo, 1, 2);
            tlpCampos.Controls.Add(dtpFechaPrestamo, 2, 2);
            tlpCampos.Controls.Add(lblFechaDevolucion, 1, 3);
            tlpCampos.Controls.Add(dtpFechaDevolucion, 2, 3);
            tlpCampos.Controls.Add(lblEstado, 1, 4);
            tlpCampos.Controls.Add(txtEstado, 2, 4);
            pnlBotones.Controls.Add(tlpBotones);
            tlpBotones.Controls.Add(btnNuevo, 1, 0);
            tlpBotones.Controls.Add(btnGuardar, 2, 0);
            tlpBotones.Controls.Add(btnEditar, 3, 0);
            tlpBotones.Controls.Add(btnDevolver, 4, 0);
            tlpBotones.Controls.Add(btnEliminar, 5, 0);
            tlpBotones.Controls.Add(btnCancelar, 6, 0);
            pnlFiltro.Controls.Add(lblFiltro);
            pnlFiltro.Controls.Add(cmbFiltroEstado);
            pnlFiltro.Controls.Add(lblTotal);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Name = "FrmPrestamos";
            Text = "Préstamos";
            Controls.Add(dgvPrestamos);
            Controls.Add(pnlFiltro);
            Controls.Add(pnlBotones);
            Controls.Add(pnlDatos);
            Controls.Add(pnlTitulo);
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            pnlDatos.ResumeLayout(false);
            pnlDatos.PerformLayout();
            tlpCampos.ResumeLayout(false);
            tlpCampos.PerformLayout();
            pnlBotones.ResumeLayout(false);
            pnlBotones.PerformLayout();
            tlpBotones.ResumeLayout(false);
            tlpBotones.PerformLayout();
            pnlFiltro.ResumeLayout(false);
            pnlFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTitulo;
        private Label lblTitulo;
        private Panel pnlDatos;
        private TableLayoutPanel tlpCampos;
        private Label lblUsuario;
        private ComboBox cmbUsuario;
        private Label lblLibro;
        private ComboBox cmbLibro;
        private Label lblFechaPrestamo;
        private DateTimePicker dtpFechaPrestamo;
        private Label lblFechaDevolucion;
        private DateTimePicker dtpFechaDevolucion;
        private Label lblEstado;
        private TextBox txtEstado;
        private Panel pnlBotones;
        private TableLayoutPanel tlpBotones;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnDevolver;
        private Button btnEliminar;
        private Button btnCancelar;
        private Panel pnlFiltro;
        private Label lblFiltro;
        private ComboBox cmbFiltroEstado;
        private Label lblTotal;
        private DataGridView dgvPrestamos;
    }
}
