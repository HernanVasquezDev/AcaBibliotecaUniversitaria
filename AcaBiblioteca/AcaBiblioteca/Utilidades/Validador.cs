using System.Text.RegularExpressions;
using AcaBiblioteca.Excepciones;

namespace AcaBiblioteca.Utilidades
{
    /// <summary>
    /// Validaciones reutilizables para los datos ingresados por el usuario.
    /// </summary>
    public static class Validador
    {
        private static readonly Regex PatronCorreo =
            new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        private static readonly Regex PatronTelefono =
            new(@"^\+?[0-9\s\-()]{7,30}$", RegexOptions.Compiled);

        private static readonly Regex PatronDocumento =
            new(@"^[A-Za-z0-9\-]+$", RegexOptions.Compiled);

        private static readonly Regex PatronCodigo =
            new(@"^[A-Za-z0-9\-]+$", RegexOptions.Compiled);

        /// <summary>Valida un texto obligatorio y devuelve su versión recortada.</summary>
        public static string Requerido(string? valor, string sujeto, int longitudMaxima)
        {
            string limpio = valor?.Trim() ?? string.Empty;

            if (limpio.Length == 0)
                throw new ReglaNegocioException($"{sujeto} es obligatorio.");

            if (limpio.Length > longitudMaxima)
                throw new ReglaNegocioException(
                    $"{sujeto} no puede superar {longitudMaxima} caracteres.");

            return limpio;
        }

        /// <summary>Valida la longitud de un texto opcional.</summary>
        public static void LongitudOpcional(string? valor, string sujeto, int longitudMaxima)
        {
            if (!string.IsNullOrWhiteSpace(valor) && valor.Trim().Length > longitudMaxima)
                throw new ReglaNegocioException(
                    $"{sujeto} no puede superar {longitudMaxima} caracteres.");
        }

        public static void Documento(string documento)
        {
            if (!PatronDocumento.IsMatch(documento))
                throw new ReglaNegocioException(
                    "El documento solo puede contener letras, números y guiones.");
        }

        public static void Codigo(string codigo, string sujeto)
        {
            if (!PatronCodigo.IsMatch(codigo))
                throw new ReglaNegocioException(
                    $"{sujeto} solo puede contener letras, números y guiones.");
        }

        public static void Correo(string? correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
                return;

            if (!PatronCorreo.IsMatch(correo.Trim()))
                throw new ReglaNegocioException(
                    "El correo electrónico no tiene un formato válido (ejemplo: nombre@dominio.com).");
        }

        public static void Telefono(string? telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return;

            if (!PatronTelefono.IsMatch(telefono.Trim()))
                throw new ReglaNegocioException(
                    "El teléfono solo puede contener números, espacios, +, - y paréntesis (mínimo 7 caracteres).");
        }
    }
}
