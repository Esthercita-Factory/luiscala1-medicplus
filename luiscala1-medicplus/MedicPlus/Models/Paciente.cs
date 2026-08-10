

namespace MedicPlus.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string NombreDuenio { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string NombreMascota { get; set; } = string.Empty;
        public string Especie { get; set; } = string.Empty; // Ej: Perro, Gato, Ave
        public string Raza { get; set; } = string.Empty;    // Ej: Labrador, Mestizo, o ""
        public int Edad { get; set; }                       // Edad de la mascota
        public string Sintoma { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"[ID: {Id}] Mascota: {NombreMascota} ({Especie}, {Edad} años, Raza: {(string.IsNullOrWhiteSpace(Raza) ? "Sin definir" : Raza)}) | Dueño: {NombreDuenio} ({Telefono}) | Síntoma: {Sintoma}";
        }
    }
}