namespace AcaBiblioteca
{
    partial class FrmUsuarios
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblDocumento = new Label();
            txtDocumento = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            pnlBotones = new Panel();
            tlpBotones = new TableLayoutPanel();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();
            dgvUsuarios = new DataGridView();
            pnlTitulo.SuspendLayout();
            pnlDatos.SuspendLayout();
            tlpCampos.SuspendLayout();
            pnlBotones.SuspendLayout();
            tlpBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
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
            lblTitulo.Text = "GESTIÓN DE USUARIOS";
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
            tlpCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 280F));
            tlpCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            // 
            // lblNombre
            // 
            lblNombre.Name = "lblNombre";
            lblNombre.Anchor = AnchorStyles.Right;
            lblNombre.AutoSize = true;
            lblNombre.Margin = new Padding(0, 0, 10, 0);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre :";
            // 
            // txtNombre
            // 
            txtNombre.Name = "txtNombre";
            txtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtNombre.TabIndex = 1;
            txtNombre.MaxLength = 100;
            // 
            // lblApellido
            // 
            lblApellido.Name = "lblApellido";
            lblApellido.Anchor = AnchorStyles.Right;
            lblApellido.AutoSize = true;
            lblApellido.Margin = new Padding(0, 0, 10, 0);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido :";
            // 
            // txtApellido
            // 
            txtApellido.Name = "txtApellido";
            txtApellido.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtApellido.TabIndex = 3;
            txtApellido.MaxLength = 100;
            // 
            // lblDocumento
            // 
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Anchor = AnchorStyles.Right;
            lblDocumento.AutoSize = true;
            lblDocumento.Margin = new Padding(0, 0, 10, 0);
            lblDocumento.TabIndex = 4;
            lblDocumento.Text = "Documento :";
            // 
            // txtDocumento
            // 
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDocumento.TabIndex = 5;
            txtDocumento.MaxLength = 30;
            // 
            // lblTelefono
            // 
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Anchor = AnchorStyles.Right;
            lblTelefono.AutoSize = true;
            lblTelefono.Margin = new Padding(0, 0, 10, 0);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "Teléfono :";
            // 
            // txtTelefono
            // 
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTelefono.TabIndex = 7;
            txtTelefono.MaxLength = 30;
            // 
            // lblCorreo
            // 
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Anchor = AnchorStyles.Right;
            lblCorreo.AutoSize = true;
            lblCorreo.Margin = new Padding(0, 0, 10, 0);
            lblCorreo.TabIndex = 8;
            lblCorreo.Text = "Correo :";
            // 
            // txtCorreo
            // 
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtCorreo.TabIndex = 9;
            txtCorreo.MaxLength = 150;
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
            tlpBotones.ColumnCount = 7;
            tlpBotones.RowCount = 1;
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
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
            btnGuardar.Text = "Guardar";
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
            btnEliminar.TabIndex = 3;
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
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.TabIndex = 3;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            // 
            // FrmUsuarios
            // 
            pnlTitulo.Controls.Add(lblTitulo);
            pnlDatos.Controls.Add(tlpCampos);
            tlpCampos.Controls.Add(lblNombre, 1, 0);
            tlpCampos.Controls.Add(txtNombre, 2, 0);
            tlpCampos.Controls.Add(lblApellido, 1, 1);
            tlpCampos.Controls.Add(txtApellido, 2, 1);
            tlpCampos.Controls.Add(lblDocumento, 1, 2);
            tlpCampos.Controls.Add(txtDocumento, 2, 2);
            tlpCampos.Controls.Add(lblTelefono, 1, 3);
            tlpCampos.Controls.Add(txtTelefono, 2, 3);
            tlpCampos.Controls.Add(lblCorreo, 1, 4);
            tlpCampos.Controls.Add(txtCorreo, 2, 4);
            pnlBotones.Controls.Add(tlpBotones);
            tlpBotones.Controls.Add(btnNuevo, 1, 0);
            tlpBotones.Controls.Add(btnGuardar, 2, 0);
            tlpBotones.Controls.Add(btnEditar, 3, 0);
            tlpBotones.Controls.Add(btnEliminar, 4, 0);
            tlpBotones.Controls.Add(btnCancelar, 5, 0);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Name = "FrmUsuarios";
            Text = "Usuarios";
            Controls.Add(dgvUsuarios);
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
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTitulo;
        private Label lblTitulo;
        private Panel pnlDatos;
        private TableLayoutPanel tlpCampos;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblDocumento;
        private TextBox txtDocumento;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblCorreo;
        private TextBox txtCorreo;
        private Panel pnlBotones;
        private TableLayoutPanel tlpBotones;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnCancelar;
        private DataGridView dgvUsuarios;
    }
}
