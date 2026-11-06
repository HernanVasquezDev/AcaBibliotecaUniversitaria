using System.Data;
using System.Text;

namespace AcaBiblioteca.Utilidades
{
    public static class ExportadorCsv
    {
        /// <summary>Exporta un DataTable a CSV (UTF-8 con BOM, para que Excel respete las tildes).</summary>
        public static void Exportar(DataTable tabla, string ruta)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Join(";", tabla.Columns.Cast<DataColumn>()
                                                .Select(c => Escapar(c.ColumnName))));

            foreach (DataRow fila in tabla.Rows)
            {
                sb.AppendLine(string.Join(";", fila.ItemArray.Select(Formatear)));
            }

            File.WriteAllText(ruta, sb.ToString(), new UTF8Encoding(true));
        }

        private static string Formatear(object? valor)
        {
            if (valor == null || valor == DBNull.Value)
                return string.Empty;

            if (valor is DateTime fecha)
                return fecha.ToString("dd/MM/yyyy");

            return Escapar(Convert.ToString(valor) ?? string.Empty);
        }

        private static string Escapar(string texto)
        {
            if (texto.Contains(';') || texto.Contains('"') || texto.Contains('\n'))
                return "\"" + texto.Replace("\"", "\"\"") + "\"";

            return texto;
        }
    }
}
