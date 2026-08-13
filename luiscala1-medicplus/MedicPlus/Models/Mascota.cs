using System;

namespace MedicPlus.Models
{
    /// <summary>
    /// Representa una mascota en la clínica veterinaria.
    /// Hereda de Animal y pertenece a un Paciente (dueño).
    /// </summary>
    public class Mascota : Animal, IRegistrable
    {
        private string _raza;
        private Paciente? _propietario;
        private string _sintomas;
        private DateTime _fechaNacimiento;
        private DateTime _fechaRegistro;

        /// <summary>
        /// Constructor de la mascota.
        /// </summary>
        public Mascota(string nombre, string especie, int edad, string raza = "", string sintomas = "")
            : base(nombre, edad, especie)
        {
            _raza = raza ?? string.Empty;
            _sintomas = sintomas ?? string.Empty;
            _propietario = null;
            _fechaRegistro = DateTime.Now;
            _fechaNacimiento = DateTime.Now.AddYears(-edad);
        }

        /// <summary>
        /// Raza de la mascota.
        /// </summary>
        public string Raza
        {
            get { return _raza; }
            set { _raza = value ?? string.Empty; }
        }

        /// <summary>
        /// Síntomas o problemas de salud reportados.
        /// </summary>
        public string Sintomas
        {
            get { return _sintomas; }
            set { _sintomas = value ?? string.Empty; }
        }

        /// <summary>
        /// Propietario/Paciente de la mascota.
        /// </summary>
        public Paciente? Propietario
        {
            get { return _propietario; }
        }

        /// <summary>
        /// Fecha de nacimiento de la mascota.
        /// </summary>
        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        /// <summary>
        /// Fecha de registro en el sistema.
        /// </summary>
        public DateTime FechaRegistro
        {
            get { return _fechaRegistro; }
        }

        /// <summary>
        /// Asigna un propietario a la mascota (usualmente llamado por Paciente.AgregarMascota).
        /// </summary>
        internal void AsignarPropietario(Paciente paciente)
        {
            if (paciente == null)
                throw new ArgumentNullException(nameof(paciente));
            _propietario = paciente;
        }

        /// <summary>
        /// Método abstracto EmitirSonido implementado según la especie.
        /// Demuestra polimorfismo: cada especie emite un sonido diferente.
        /// </summary>
        public override string EmitirSonido()
        {
            return Especie.ToLower() switch
            {
                "perro" => "¡Guau guau! 🐕",
                "gato" => "¡Miau miau! 🐱",
                "ave" => "¡Chirp chirp! 🐦",
                "conejo" => "¡Squeak squeak! 🐰",
                "hamster" => "¡Squeak! 🐹",
                "tortuga" => "...",
                _ => "Sonido desconocido"
            };
        }

        /// <summary>
        /// Retorna información detallada de la mascota.
        /// Sobrescribe el método de la clase Animal.
        /// </summary>
        public override string ObtenerInfo()
        {
            string razaInfo = string.IsNullOrWhiteSpace(_raza) ? "Sin definir" : _raza;
            string propietarioInfo = _propietario?.NombreCompleto ?? "No asignado";
            return $"[{Especie}] {Nombre} ({razaInfo}) - {Edad} años\n" +
                   $"  Dueño: {propietarioInfo}\n" +
                   $"  Síntomas: {(_sintomas.Length > 0 ? _sintomas : "Ninguno reportado")}";
        }

        /// <summary>
        /// Registra la mascota en el sistema.
        /// Implementación de IRegistrable.
        /// </summary>
        public string Registrar()
        {
            string propietario = _propietario?.NombreCompleto ?? "Sin propietario";
            return $"[REGISTRO] Mascota '{Nombre}' ({Especie}) registrada en el sistema el {_fechaRegistro:dd/MM/yyyy HH:mm:ss} - Propietario: {propietario}";
        }

        /// <summary>
        /// Muestra los detalles completos de la mascota.
        /// </summary>
        public void MostrarDetalles()
        {
            Console.WriteLine("\n╔════════════════════════════════════╗");
            Console.WriteLine($"║  DETALLES DE LA MASCOTA");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.WriteLine($"  Nombre:         {Nombre}");
            Console.WriteLine($"  Especie:        {Especie}");
            Console.WriteLine($"  Raza:           {(_raza.Length > 0 ? _raza : "Sin definir")}");
            Console.WriteLine($"  Edad:           {Edad} años");
            Console.WriteLine($"  Sonido:         {EmitirSonido()}");
            Console.WriteLine($"  Dueño:          {(_propietario?.NombreCompleto ?? "No asignado")}");
            Console.WriteLine($"  Síntomas:       {(_sintomas.Length > 0 ? _sintomas : "Ninguno")}");
            Console.WriteLine($"  Fecha Nacimiento: {_fechaNacimiento:dd/MM/yyyy}");
            Console.WriteLine($"  Registrada:     {_fechaRegistro:dd/MM/yyyy HH:mm:ss}");
        }

        /// <summary>
        /// Reporta síntomas de la mascota.
        /// </summary>
        public void ReportarSintomas(string nuevosSintomas)
        {
            _sintomas = nuevosSintomas ?? string.Empty;
            Console.WriteLine($"⚠️  Síntomas actualizados para {Nombre}: {_sintomas}");
        }

        /// <summary>
        /// Representación en texto de la mascota.
        /// </summary>
        public override string ToString()
        {
            return $"{Nombre} ({Especie}) - Edad: {Edad} años - Dueño: {(_propietario?.NombreCompleto ?? "Sin asignar")}";
        }
    }
}
