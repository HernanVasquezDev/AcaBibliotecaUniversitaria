namespace AcaBiblioteca
{
    partial class FrmInicio
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
            lblDescripcion = new Label();
            tlpTarjetas = new TableLayoutPanel();
            pnlTotalLibros = new Panel();
            lblTotalLibros = new Label();
            lblCaptionTotalLibros = new Label();
            pnlTotalExistencias = new Panel();
            lblTotalExistencias = new Label();
            lblCaptionTotalExistencias = new Label();
            pnlPrestamosActivos = new Panel();
            lblPrestamosActivos = new Label();
            lblCaptionPrestamosActivos = new Label();
            pnlTotalUsuarios = new Panel();
            lblTotalUsuarios = new Label();
            lblCaptionTotalUsuarios = new Label();
            pnlTotalAutores = new Panel();
            lblTotalAutores = new Label();
            lblCaptionTotalAutores = new Label();
            pnlTotalEditoriales = new Panel();
            lblTotalEditoriales = new Label();
            lblCaptionTotalEditoriales = new Label();
            pnlTitulo.SuspendLayout();
            tlpTarjetas.SuspendLayout();
            pnlTotalLibros.SuspendLayout();
            pnlTotalExistencias.SuspendLayout();
            pnlPrestamosActivos.SuspendLayout();
            pnlTotalUsuarios.SuspendLayout();
            pnlTotalAutores.SuspendLayout();
            pnlTotalEditoriales.SuspendLayout();
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
            lblTitulo.Text = "BIENVENIDO AL SISTEMA DE GESTIÓN DE BIBLIOTECA";
            // 
            // lblDescripcion
            // 
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Dock = DockStyle.Top;
            lblDescripcion.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescripcion.Size = new Size(1000, 50);
            lblDescripcion.TextAlign = ContentAlignment.MiddleCenter;
            lblDescripcion.Text = "Administre libros, autores, editoriales, usuarios y préstamos desde el menú lateral.";
            lblDescripcion.TabIndex = 1;
            // 
            // tlpTarjetas
            // 
            tlpTarjetas.Name = "tlpTarjetas";
            tlpTarjetas.Dock = DockStyle.Fill;
            tlpTarjetas.ColumnCount = 3;
            tlpTarjetas.RowCount = 2;
            tlpTarjetas.Padding = new Padding(40);
            tlpTarjetas.TabIndex = 2;
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpTarjetas.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpTarjetas.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            // 
            // pnlTotalLibros
            // 
            pnlTotalLibros.Name = "pnlTotalLibros";
            pnlTotalLibros.BackColor = Color.RoyalBlue;
            pnlTotalLibros.Dock = DockStyle.Fill;
            pnlTotalLibros.Margin = new Padding(15);
            // 
            // lblTotalLibros
            // 
            lblTotalLibros.Name = "lblTotalLibros";
            lblTotalLibros.Dock = DockStyle.Fill;
            lblTotalLibros.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalLibros.ForeColor = Color.White;
            lblTotalLibros.TextAlign = ContentAlignment.MiddleCenter;
            lblTotalLibros.Text = "-";
            // 
            // lblCaptionTotalLibros
            // 
            lblCaptionTotalLibros.Name = "lblCaptionTotalLibros";
            lblCaptionTotalLibros.Dock = DockStyle.Bottom;
            lblCaptionTotalLibros.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCaptionTotalLibros.ForeColor = Color.White;
            lblCaptionTotalLibros.Size = new Size(100, 40);
            lblCaptionTotalLibros.TextAlign = ContentAlignment.MiddleCenter;
            lblCaptionTotalLibros.Text = "Libros registrados";
            // 
            // pnlTotalExistencias
            // 
            pnlTotalExistencias.Name = "pnlTotalExistencias";
            pnlTotalExistencias.BackColor = Color.SeaGreen;
            pnlTotalExistencias.Dock = DockStyle.Fill;
            pnlTotalExistencias.Margin = new Padding(15);
            // 
            // lblTotalExistencias
            // 
            lblTotalExistencias.Name = "lblTotalExistencias";
            lblTotalExistencias.Dock = DockStyle.Fill;
            lblTotalExistencias.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalExistencias.ForeColor = Color.White;
            lblTotalExistencias.TextAlign = ContentAlignment.MiddleCenter;
            lblTotalExistencias.Text = "-";
            // 
            // lblCaptionTotalExistencias
            // 
            lblCaptionTotalExistencias.Name = "lblCaptionTotalExistencias";
            lblCaptionTotalExistencias.Dock = DockStyle.Bottom;
            lblCaptionTotalExistencias.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCaptionTotalExistencias.ForeColor = Color.White;
            lblCaptionTotalExistencias.Size = new Size(100, 40);
            lblCaptionTotalExistencias.TextAlign = ContentAlignment.MiddleCenter;
            lblCaptionTotalExistencias.Text = "Ejemplares disponibles";
            // 
            // pnlPrestamosActivos
            // 
            pnlPrestamosActivos.Name = "pnlPrestamosActivos";
            pnlPrestamosActivos.BackColor = Color.DarkOrange;
            pnlPrestamosActivos.Dock = DockStyle.Fill;
            pnlPrestamosActivos.Margin = new Padding(15);
            // 
            // lblPrestamosActivos
            // 
            lblPrestamosActivos.Name = "lblPrestamosActivos";
            lblPrestamosActivos.Dock = DockStyle.Fill;
            lblPrestamosActivos.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrestamosActivos.ForeColor = Color.White;
            lblPrestamosActivos.TextAlign = ContentAlignment.MiddleCenter;
            lblPrestamosActivos.Text = "-";
            // 
            // lblCaptionPrestamosActivos
            // 
            lblCaptionPrestamosActivos.Name = "lblCaptionPrestamosActivos";
            lblCaptionPrestamosActivos.Dock = DockStyle.Bottom;
            lblCaptionPrestamosActivos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCaptionPrestamosActivos.ForeColor = Color.White;
            lblCaptionPrestamosActivos.Size = new Size(100, 40);
            lblCaptionPrestamosActivos.TextAlign = ContentAlignment.MiddleCenter;
            lblCaptionPrestamosActivos.Text = "Préstamos activos";
            // 
            // pnlTotalUsuarios
            // 
            pnlTotalUsuarios.Name = "pnlTotalUsuarios";
            pnlTotalUsuarios.BackColor = Color.MediumPurple;
            pnlTotalUsuarios.Dock = DockStyle.Fill;
            pnlTotalUsuarios.Margin = new Padding(15);
            // 
            // lblTotalUsuarios
            // 
            lblTotalUsuarios.Name = "lblTotalUsuarios";
            lblTotalUsuarios.Dock = DockStyle.Fill;
            lblTotalUsuarios.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalUsuarios.ForeColor = Color.White;
            lblTotalUsuarios.TextAlign = ContentAlignment.MiddleCenter;
            lblTotalUsuarios.Text = "-";
            // 
            // lblCaptionTotalUsuarios
            // 
            lblCaptionTotalUsuarios.Name = "lblCaptionTotalUsuarios";
            lblCaptionTotalUsuarios.Dock = DockStyle.Bottom;
            lblCaptionTotalUsuarios.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCaptionTotalUsuarios.ForeColor = Color.White;
            lblCaptionTotalUsuarios.Size = new Size(100, 40);
            lblCaptionTotalUsuarios.TextAlign = ContentAlignment.MiddleCenter;
            lblCaptionTotalUsuarios.Text = "Usuarios";
            // 
            // pnlTotalAutores
            // 
            pnlTotalAutores.Name = "pnlTotalAutores";
            pnlTotalAutores.BackColor = Color.Teal;
            pnlTotalAutores.Dock = DockStyle.Fill;
            pnlTotalAutores.Margin = new Padding(15);
            // 
            // lblTotalAutores
            // 
            lblTotalAutores.Name = "lblTotalAutores";
            lblTotalAutores.Dock = DockStyle.Fill;
            lblTotalAutores.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalAutores.ForeColor = Color.White;
            lblTotalAutores.TextAlign = ContentAlignment.MiddleCenter;
            lblTotalAutores.Text = "-";
            // 
            // lblCaptionTotalAutores
            // 
            lblCaptionTotalAutores.Name = "lblCaptionTotalAutores";
            lblCaptionTotalAutores.Dock = DockStyle.Bottom;
            lblCaptionTotalAutores.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCaptionTotalAutores.ForeColor = Color.White;
            lblCaptionTotalAutores.Size = new Size(100, 40);
            lblCaptionTotalAutores.TextAlign = ContentAlignment.MiddleCenter;
            lblCaptionTotalAutores.Text = "Autores";
            // 
            // pnlTotalEditoriales
            // 
            pnlTotalEditoriales.Name = "pnlTotalEditoriales";
            pnlTotalEditoriales.BackColor = Color.IndianRed;
            pnlTotalEditoriales.Dock = DockStyle.Fill;
            pnlTotalEditoriales.Margin = new Padding(15);
            // 
            // lblTotalEditoriales
            // 
            lblTotalEditoriales.Name = "lblTotalEditoriales";
            lblTotalEditoriales.Dock = DockStyle.Fill;
            lblTotalEditoriales.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalEditoriales.ForeColor = Color.White;
            lblTotalEditoriales.TextAlign = ContentAlignment.MiddleCenter;
            lblTotalEditoriales.Text = "-";
            // 
            // lblCaptionTotalEditoriales
            // 
            lblCaptionTotalEditoriales.Name = "lblCaptionTotalEditoriales";
            lblCaptionTotalEditoriales.Dock = DockStyle.Bottom;
            lblCaptionTotalEditoriales.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCaptionTotalEditoriales.ForeColor = Color.White;
            lblCaptionTotalEditoriales.Size = new Size(100, 40);
            lblCaptionTotalEditoriales.TextAlign = ContentAlignment.MiddleCenter;
            lblCaptionTotalEditoriales.Text = "Editoriales";
            // 
            // FrmInicio
            // 
            pnlTitulo.Controls.Add(lblTitulo);
            tlpTarjetas.Controls.Add(pnlTotalLibros, 0, 0);
            pnlTotalLibros.Controls.Add(lblTotalLibros);
            pnlTotalLibros.Controls.Add(lblCaptionTotalLibros);
            tlpTarjetas.Controls.Add(pnlTotalExistencias, 1, 0);
            pnlTotalExistencias.Controls.Add(lblTotalExistencias);
            pnlTotalExistencias.Controls.Add(lblCaptionTotalExistencias);
            tlpTarjetas.Controls.Add(pnlPrestamosActivos, 2, 0);
            pnlPrestamosActivos.Controls.Add(lblPrestamosActivos);
            pnlPrestamosActivos.Controls.Add(lblCaptionPrestamosActivos);
            tlpTarjetas.Controls.Add(pnlTotalUsuarios, 0, 1);
            pnlTotalUsuarios.Controls.Add(lblTotalUsuarios);
            pnlTotalUsuarios.Controls.Add(lblCaptionTotalUsuarios);
            tlpTarjetas.Controls.Add(pnlTotalAutores, 1, 1);
            pnlTotalAutores.Controls.Add(lblTotalAutores);
            pnlTotalAutores.Controls.Add(lblCaptionTotalAutores);
            tlpTarjetas.Controls.Add(pnlTotalEditoriales, 2, 1);
            pnlTotalEditoriales.Controls.Add(lblTotalEditoriales);
            pnlTotalEditoriales.Controls.Add(lblCaptionTotalEditoriales);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Name = "FrmInicio";
            Text = "Inicio";
            Controls.Add(tlpTarjetas);
            Controls.Add(lblDescripcion);
            Controls.Add(pnlTitulo);
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            tlpTarjetas.ResumeLayout(false);
            tlpTarjetas.PerformLayout();
            pnlTotalLibros.ResumeLayout(false);
            pnlTotalLibros.PerformLayout();
            pnlTotalExistencias.ResumeLayout(false);
            pnlTotalExistencias.PerformLayout();
            pnlPrestamosActivos.ResumeLayout(false);
            pnlPrestamosActivos.PerformLayout();
            pnlTotalUsuarios.ResumeLayout(false);
            pnlTotalUsuarios.PerformLayout();
            pnlTotalAutores.ResumeLayout(false);
            pnlTotalAutores.PerformLayout();
            pnlTotalEditoriales.ResumeLayout(false);
            pnlTotalEditoriales.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTitulo;
        private Label lblTitulo;
        private Label lblDescripcion;
        private TableLayoutPanel tlpTarjetas;
        private Panel pnlTotalLibros;
        private Label lblTotalLibros;
        private Label lblCaptionTotalLibros;
        private Panel pnlTotalExistencias;
        private Label lblTotalExistencias;
        private Label lblCaptionTotalExistencias;
        private Panel pnlPrestamosActivos;
        private Label lblPrestamosActivos;
        private Label lblCaptionPrestamosActivos;
        private Panel pnlTotalUsuarios;
        private Label lblTotalUsuarios;
        private Label lblCaptionTotalUsuarios;
        private Panel pnlTotalAutores;
        private Label lblTotalAutores;
        private Label lblCaptionTotalAutores;
        private Panel pnlTotalEditoriales;
        private Label lblTotalEditoriales;
        private Label lblCaptionTotalEditoriales;
    }
}

}
