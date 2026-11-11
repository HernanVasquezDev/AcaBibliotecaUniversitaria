namespace AcaBiblioteca
{
    partial class FrmReportes
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
            pnlFiltros = new Panel();
            tlpFiltros = new TableLayoutPanel();
            lblReporte = new Label();
            cmbReporte = new ComboBox();
            lblUsuarioReporte = new Label();
            cmbUsuarioReporte = new ComboBox();
            btnGenerar = new Button();
            btnExportar = new Button();
            pnlResumen = new Panel();
            lblRegistros = new Label();
            dgvReporte = new DataGridView();
            pnlTitulo.SuspendLayout();
            pnlFiltros.SuspendLayout();
            tlpFiltros.SuspendLayout();
            pnlResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
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
            lblTitulo.Text = "REPORTES";
            // 
            // pnlFiltros
            // 
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Size = new Size(1000, 60);
            pnlFiltros.TabIndex = 1;
            // 
            // tlpFiltros
            // 
            tlpFiltros.Name = "tlpFiltros";
            tlpFiltros.Dock = DockStyle.Fill;
            tlpFiltros.ColumnCount = 8;
            tlpFiltros.RowCount = 1;
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpFiltros.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            // 
            // lblReporte
            // 
            lblReporte.Name = "lblReporte";
            lblReporte.Anchor = AnchorStyles.Right;
            lblReporte.AutoSize = true;
            lblReporte.Text = "Reporte :";
            // 
            // cmbReporte
            // 
            cmbReporte.Name = "cmbReporte";
            cmbReporte.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReporte.SelectedIndexChanged += cmbReporte_SelectedIndexChanged;
            // 
            // lblUsuarioReporte
            // 
            lblUsuarioReporte.Name = "lblUsuarioReporte";
            lblUsuarioReporte.Anchor = AnchorStyles.Right;
            lblUsuarioReporte.AutoSize = true;
            lblUsuarioReporte.Text = "Usuario :";
            // 
            // cmbUsuarioReporte
            // 
            cmbUsuarioReporte.Name = "cmbUsuarioReporte";
            cmbUsuarioReporte.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbUsuarioReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuarioReporte.Enabled = false;
            // 
            // btnGenerar
            // 
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Dock = DockStyle.Fill;
            btnGenerar.FlatAppearance.BorderSize = 0;
            btnGenerar.FlatStyle = FlatStyle.Flat;
            btnGenerar.BackColor = Color.RoyalBlue;
            btnGenerar.ForeColor = Color.White;
            btnGenerar.Cursor = Cursors.Hand;
            btnGenerar.Margin = new Padding(6, 10, 6, 10);
            btnGenerar.TabIndex = 0;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Name = "btnExportar";
            btnExportar.Dock = DockStyle.Fill;
            btnExportar.FlatAppearance.BorderSize = 0;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.BackColor = Color.SeaGreen;
            btnExportar.ForeColor = Color.White;
            btnExportar.Cursor = Cursors.Hand;
            btnExportar.Margin = new Padding(6, 10, 6, 10);
            btnExportar.TabIndex = 1;
            btnExportar.Text = "Exportar CSV";
            btnExportar.UseVisualStyleBackColor = false;
            btnExportar.Click += btnExportar_Click;
            // 
            // pnlResumen
            // 
            pnlResumen.Name = "pnlResumen";
            pnlResumen.Dock = DockStyle.Bottom;
            pnlResumen.Size = new Size(1000, 35);
            pnlResumen.TabIndex = 3;
            // 
            // lblRegistros
            // 
            lblRegistros.Name = "lblRegistros";
            lblRegistros.Dock = DockStyle.Fill;
            lblRegistros.Padding = new Padding(15, 0, 0, 0);
            lblRegistros.TextAlign = ContentAlignment.MiddleLeft;
            lblRegistros.Text = "Seleccione un reporte y pulse Generar.";
            // 
            // dgvReporte
            // 
            dgvReporte.Name = "dgvReporte";
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.AllowUserToDeleteRows = false;
            dgvReporte.AllowUserToResizeRows = false;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.BackgroundColor = Color.White;
            dgvReporte.Dock = DockStyle.Fill;
            dgvReporte.MultiSelect = false;
            dgvReporte.ReadOnly = true;
            dgvReporte.RowHeadersVisible = false;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.TabIndex = 2;
            // 
            // FrmReportes
            // 
            pnlTitulo.Controls.Add(lblTitulo);
            pnlFiltros.Controls.Add(tlpFiltros);
            tlpFiltros.Controls.Add(lblReporte, 1, 0);
            tlpFiltros.Controls.Add(cmbReporte, 2, 0);
            tlpFiltros.Controls.Add(lblUsuarioReporte, 3, 0);
            tlpFiltros.Controls.Add(cmbUsuarioReporte, 4, 0);
            tlpFiltros.Controls.Add(btnGenerar, 5, 0);
            tlpFiltros.Controls.Add(btnExportar, 6, 0);
            pnlResumen.Controls.Add(lblRegistros);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Name = "FrmReportes";
            Text = "Reportes";
            Controls.Add(dgvReporte);
            Controls.Add(pnlResumen);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlTitulo);
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            tlpFiltros.ResumeLayout(false);
            tlpFiltros.PerformLayout();
            pnlResumen.ResumeLayout(false);
            pnlResumen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTitulo;
        private Label lblTitulo;
        private Panel pnlFiltros;
        private TableLayoutPanel tlpFiltros;
        private Label lblReporte;
        private ComboBox cmbReporte;
        private Label lblUsuarioReporte;
        private ComboBox cmbUsuarioReporte;
        private Button btnGenerar;
        private Button btnExportar;
        private Panel pnlResumen;
        private Label lblRegistros;
        private DataGridView dgvReporte;
    }
}
