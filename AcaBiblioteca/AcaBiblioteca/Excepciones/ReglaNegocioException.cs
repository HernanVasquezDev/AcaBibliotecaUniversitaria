namespace AcaBiblioteca.Excepciones
{
    /// <summary>
    /// Se lanza cuando una operación incumple una regla del sistema
    /// (campo obligatorio, duplicado, restricción de integridad, etc.).
    /// Su mensaje es apto para mostrarse directamente al usuario.
    /// </summary>
    public class ReglaNegocioException : Exception
    {
        public ReglaNegocioException(string mensaje) : base(mensaje)
        {
        }

        public ReglaNegocioException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {
        }
    }
}
