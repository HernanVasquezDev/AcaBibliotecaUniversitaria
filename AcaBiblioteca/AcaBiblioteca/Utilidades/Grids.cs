namespace AcaBiblioteca.Utilidades
{
    public static class Grids
    {
        /// <summary>Da formato dd/MM/yyyy a todas las columnas de fecha del grid.</summary>
        public static void FormatearFechas(DataGridView grid)
        {
            foreach (DataGridViewColumn columna in grid.Columns)
            {
                if (columna.ValueType == typeof(DateTime))
                    columna.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        public static void Encabezado(DataGridView grid, string columna, string texto)
        {
            if (grid.Columns.Contains(columna))
                grid.Columns[columna]!.HeaderText = texto;
        }

        public static void Ocultar(DataGridView grid, string columna)
        {
            if (grid.Columns.Contains(columna))
                grid.Columns[columna]!.Visible = false;
        }
    }
}
