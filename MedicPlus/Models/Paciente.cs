

namespace MedicPlus.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string Sintoma { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"[ID: {Id}] - {Nombre} ({Edad} años) | Síntoma: {Sintoma}";
        }
    }
}
