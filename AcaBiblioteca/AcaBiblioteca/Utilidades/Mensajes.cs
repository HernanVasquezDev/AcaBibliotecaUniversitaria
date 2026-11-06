using AcaBiblioteca.Excepciones;

namespace AcaBiblioteca.Utilidades
{
    /// <summary>Mensajes estándar de la aplicación (información, advertencia, error y confirmación).</summary>
    public static class Mensajes
    {
        private const string Titulo = "Biblioteca";

        public static void Informacion(string mensaje)
            => MessageBox.Show(mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void Advertencia(string mensaje)
            => MessageBox.Show(mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static void Error(string mensaje)
            => MessageBox.Show(mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static bool Confirmar(string pregunta)
            => MessageBox.Show(pregunta, Titulo, MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) == DialogResult.Yes;

        /// <summary>
        /// Muestra el error apropiado: las reglas de negocio como advertencia
        /// y cualquier otra excepción como error técnico.
        /// </summary>
        public static void ManejarError(Exception ex, string accion)
        {
            if (ex is ReglaNegocioException)
                Advertencia(ex.Message);
            else
                Error($"Error al {accion}:\n{ex.Message}");
        }
    }
}
