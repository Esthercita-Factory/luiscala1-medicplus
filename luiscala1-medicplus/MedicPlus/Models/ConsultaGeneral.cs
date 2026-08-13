using System;

namespace MedicPlus.Models
{
    /// <summary>
    /// Representa una consulta general en la clínica veterinaria.
    /// Hereda de ServicioVeterinario e implementa el método Atender().
    /// </summary>
    public class ConsultaGeneral : ServicioVeterinario
    {
        private string _razonConsulta;
        private string _diagnostico;
        private string _tratamiento;
        private bool _atendida;

        /// <summary>
        /// Constructor de ConsultaGeneral.
        /// </summary>
        public ConsultaGeneral(Paciente paciente, Mascota mascota, string razonConsulta = "")
            : base(paciente, mascota, razonConsulta)
        {
            _razonConsulta = razonConsulta ?? string.Empty;
            _diagnostico = string.Empty;
            _tratamiento = string.Empty;
            _atendida = false;
        }

        /// <summary>
        /// Razón por la cual se solicita la consulta.
        /// </summary>
        public string RazonConsulta
        {
            get { return _razonConsulta; }
            set { _razonConsulta = value ?? string.Empty; }
        }

        /// <summary>
        /// Diagnóstico realizado por el veterinario.
        /// </summary>
        public string Diagnostico
        {
            get { return _diagnostico; }
            set { _diagnostico = value ?? string.Empty; }
        }

        /// <summary>
        /// Tratamiento recomendado.
        /// </summary>
        public string Tratamiento
        {
            get { return _tratamiento; }
            set { _tratamiento = value ?? string.Empty; }
        }

        /// <summary>
        /// Indica si la consulta ha sido atendida.
        /// </summary>
        public bool Atendida
        {
            get { return _atendida; }
            set { _atendida = value; }
        }

        /// <summary>
        /// Implementación del método abstracto Atender().
        /// Realiza el diagnóstico de la mascota.
        /// </summary>
        public override string Atender()
        {
            if (_mascota == null || _paciente == null)
                return "Error: Mascota o paciente no asignado.";

            _atendida = true;
            _fecha = DateTime.Now;

            Console.WriteLine("\n╔════════════════════════════════════╗");
            Console.WriteLine($"║  CONSULTANDO A: {_mascota.Nombre.ToUpper()}");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.WriteLine($"🏥 Veterinario: Dr. Medicus Plus");
            Console.WriteLine($"📅 Fecha: {_fecha:dd/MM/yyyy HH:mm:ss}");
            Console.WriteLine($"🐾 Mascota: {_mascota.Nombre} ({_mascota.Especie})");
            Console.WriteLine($"👤 Dueño: {_paciente.NombreCompleto}");
            Console.WriteLine($"⚠️  Razón de consulta: {_razonConsulta}");
            Console.WriteLine("\n[Examinando mascota...]");
            Console.WriteLine($"   Sonido emitido: {_mascota.EmitirSonido()}");
            _mascota.Dormir();
            Console.WriteLine("\n[Diagnóstico]");

            _diagnostico = _mascota.Especie.ToLower() switch
            {
                "perro" => "Infección leve, requiere antibióticos",
                "gato" => "Alergias estacionales, aplicar tratamiento tópico",
                "ave" => "Plumaje inflamado, requiere suplementos vitamínicos",
                "conejo" => "Estrés ambiental, reposo recomendado",
                _ => "Chequeo general completado"
            };

            _tratamiento = $"Tomar medicinas durante 7 días + revisión en 1 mes";

            Console.WriteLine($"   {_diagnostico}");
            Console.WriteLine($"💊 Tratamiento: {_tratamiento}");
            Console.WriteLine("✅ Consulta completada.\n");

            return $"Consulta atendida para {_mascota.Nombre}. Diagnóstico: {_diagnostico}";
        }

        /// <summary>
        /// Realiza el diagnóstico de una enfermedad específica.
        /// </summary>
        public void DiagnosticarEnfermedad(string enfermedad)
        {
            if (string.IsNullOrWhiteSpace(enfermedad))
                throw new ArgumentException("La enfermedad no puede estar vacía", nameof(enfermedad));

            _diagnostico = $"Se diagnostica: {enfermedad}";
            Console.WriteLine($"🔍 Diagnóstico actualizado: {_diagnostico}");
        }

        /// <summary>
        /// Obtiene información detallada de la consulta.
        /// </summary>
        public override string ObtenerInfo()
        {
            return base.ObtenerInfo() + "\n" +
                   $"Tipo: Consulta General\n" +
                   $"Razón: {_razonConsulta}\n" +
                   $"Diagnóstico: {(_diagnostico.Length > 0 ? _diagnostico : "Pendiente")}\n" +
                   $"Tratamiento: {(_tratamiento.Length > 0 ? _tratamiento : "Pendiente")}\n" +
                   $"Estado: {(_atendida ? "Atendida" : "Pendiente")}";
        }

        /// <summary>
        /// Representación en texto de la consulta.
        /// </summary>
        public override string ToString()
        {
            return $"[CONSULTA] {_mascota?.Nombre} - Razón: {_razonConsulta} - {(_atendida ? "✓ Atendida" : "⏳ Pendiente")}";
        }
    }
}
