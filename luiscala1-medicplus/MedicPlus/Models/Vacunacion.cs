using System;

namespace MedicPlus.Models
{
    /// <summary>
    /// Representa un servicio de vacunación en la clínica veterinaria.
    /// Hereda de ServicioVeterinario e implementa el método Atender().
    /// </summary>
    public class Vacunacion : ServicioVeterinario
    {
        private string _tipoVacuna;
        private DateTime _proximaVacuna;
        private bool _aplicada;
        private string _lote;

        /// <summary>
        /// Constructor de Vacunacion.
        /// </summary>
        public Vacunacion(Paciente paciente, Mascota mascota, string tipoVacuna = "")
            : base(paciente, mascota, tipoVacuna)
        {
            _tipoVacuna = tipoVacuna ?? string.Empty;
            _aplicada = false;
            _lote = string.Empty;
            // Próxima vacuna típicamente es 1 año después
            _proximaVacuna = DateTime.Now.AddYears(1);
        }

        /// <summary>
        /// Tipo de vacuna a aplicar (ej: Rabia, DHPP, Triplé).
        /// </summary>
        public string TipoVacuna
        {
            get { return _tipoVacuna; }
            set { _tipoVacuna = value ?? string.Empty; }
        }

        /// <summary>
        /// Fecha aproximada de la próxima vacunación.
        /// </summary>
        public DateTime ProximaVacuna
        {
            get { return _proximaVacuna; }
            set { _proximaVacuna = value; }
        }

        /// <summary>
        /// Indica si la vacuna ya fue aplicada.
        /// </summary>
        public bool Aplicada
        {
            get { return _aplicada; }
            set { _aplicada = value; }
        }

        /// <summary>
        /// Número de lote de la vacuna.
        /// </summary>
        public string Lote
        {
            get { return _lote; }
            set { _lote = value ?? string.Empty; }
        }

        /// <summary>
        /// Implementación del método abstracto Atender().
        /// Aplica la vacunación a la mascota.
        /// </summary>
        public override string Atender()
        {
            if (_mascota == null || _paciente == null)
                return "Error: Mascota o paciente no asignado.";

            _aplicada = true;
            _fecha = DateTime.Now;
            _lote = $"LOTE-{DateTime.Now.Year}-{new Random().Next(1000, 9999)}";

            Console.WriteLine("\n╔════════════════════════════════════╗");
            Console.WriteLine($"║  VACUNANDO A: {_mascota.Nombre.ToUpper()}");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.WriteLine($"💉 Tipo de vacuna: {_tipoVacuna}");
            Console.WriteLine($"📅 Fecha: {_fecha:dd/MM/yyyy HH:mm:ss}");
            Console.WriteLine($"🐾 Mascota: {_mascota.Nombre} ({_mascota.Especie})");
            Console.WriteLine($"👤 Dueño: {_paciente.NombreCompleto}");
            Console.WriteLine("\n[Preparando para vacunación...]");
            Console.WriteLine($"   El {_mascota.Especie.ToLower()} emite: {_mascota.EmitirSonido()}");
            Console.WriteLine("   Limpiando el área...");
            Console.WriteLine($"   Aplicando {_tipoVacuna}...");
            Console.WriteLine($"   Lote: {_lote}");
            Console.WriteLine("\n✅ ¡Vacunación completada!");
            Console.WriteLine($"📆 Próxima dosis: {_proximaVacuna:dd/MM/yyyy}");
            Console.WriteLine("ℹ️  Recomendaciones: Evite baños durante 24 horas\n");

            return $"Vacunación ({_tipoVacuna}) aplicada a {_mascota.Nombre}. Próxima: {_proximaVacuna:dd/MM/yyyy}";
        }

        /// <summary>
        /// Registra la vacunación en el sistema.
        /// Sobrescribe el método base.
        /// </summary>
        public override string Registrar()
        {
            return base.Registrar() + $" - Vacuna: {_tipoVacuna} - Lote: {_lote}";
        }

        /// <summary>
        /// Obtiene la fecha de la próxima vacunación.
        /// </summary>
        public DateTime ObtenerProximaVacuna()
        {
            return _proximaVacuna;
        }

        /// <summary>
        /// Calcula los días que faltan para la próxima vacunación.
        /// </summary>
        public int DiasFaltanteParaProximaVacuna()
        {
            TimeSpan diferencia = _proximaVacuna - DateTime.Now;
            return (int)diferencia.TotalDays;
        }

        /// <summary>
        /// Obtiene información detallada de la vacunación.
        /// </summary>
        public override string ObtenerInfo()
        {
            return base.ObtenerInfo() + "\n" +
                   $"Tipo: Vacunación\n" +
                   $"Vacuna: {_tipoVacuna}\n" +
                   $"Lote: {_lote}\n" +
                   $"Estado: {(_aplicada ? "✅ Aplicada" : "⏳ Pendiente")}\n" +
                   $"Próxima dosis: {_proximaVacuna:dd/MM/yyyy} ({DiasFaltanteParaProximaVacuna()} días)";
        }

        /// <summary>
        /// Verifica si la vacunación está vencida y necesita renovación.
        /// </summary>
        public bool NecesitaRenovacion()
        {
            return _aplicada && DateTime.Now >= _proximaVacuna;
        }

        /// <summary>
        /// Representación en texto de la vacunación.
        /// </summary>
        public override string ToString()
        {
            return $"[VACUNACIÓN] {_mascota?.Nombre} - {_tipoVacuna} - {(_aplicada ? "✓ Aplicada" : "⏳ Pendiente")} - Próxima: {_proximaVacuna:dd/MM/yyyy}";
        }
    }
}
