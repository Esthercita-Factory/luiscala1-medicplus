namespace MedicPlus.Models
{
    /// <summary>
    /// Interfaz que define el contrato para registrar entidades en el sistema.
    /// Implementada por Paciente, Mascota y servicios veterinarios.
    /// </summary>
    public interface IRegistrable
    {
        /// <summary>
        /// Registra la entidad en el sistema.
        /// </summary>
        /// <returns>Mensaje confirmando el registro.</returns>
        string Registrar();
    }
}
