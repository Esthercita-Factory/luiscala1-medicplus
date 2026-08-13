using System;

namespace MedicPlus.Models
{
    /// <summary>
    /// Clase abstracta que representa un servicio veterinario en la clínica.
    /// Todos los servicios deben implementar el método Atender().
    /// </summary>
    public abstract class ServicioVeterinario : IRegistrable
    {
        protected DateTime _fecha;
        protected Paciente? _paciente;
        protected Mascota? _mascota;
        protected string _descripcion;
        private DateTime _fechaRegistro;

        /// <summary>
        /// Constructor protegido del servicio veterinario.
        /// </summary>
        protected ServicioVeterinario(Paciente paciente, Mascota mascota, string descripcion = "")
        {
            _paciente = paciente ?? throw new ArgumentNullException(nameof(paciente));
            _mascota = mascota ?? throw new ArgumentNullException(nameof(mascota));
            _descripcion = descripcion ?? string.Empty;
            _fecha = DateTime.Now;
            _fechaRegistro = DateTime.Now;
        }

        /// <summary>
        /// Fecha del servicio.
        /// </summary>
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        /// <summary>
        /// Paciente asociado al servicio.
        /// </summary>
        public Paciente? Paciente => _paciente;

        /// <summary>
        /// Mascota que recibe el servicio.
        /// </summary>
        public Mascota? Mascota => _mascota;

        /// <summary>
        /// Descripción del servicio.
        /// </summary>
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value ?? string.Empty; }
        }

        /// <summary>
        /// Fecha de registro del servicio en el sistema.
        /// </summary>
        public DateTime FechaRegistro => _fechaRegistro;

        /// <summary>
        /// Método abstracto que debe ser implementado por cada subclase.
        /// Define cómo se atiende el servicio específico.
        /// </summary>
        public abstract string Atender();

        /// <summary>
        /// Registra el servicio en el sistema.
        /// Implementación de IRegistrable.
        /// </summary>
        public virtual string Registrar()
        {
            return $"[SERVICIO] {GetType().Name} registrado el {_fechaRegistro:dd/MM/yyyy HH:mm:ss} - " +
                   $"Mascota: {_mascota?.Nombre}, Dueño: {_paciente?.NombreCompleto}";
        }

        /// <summary>
        /// Obtiene información del servicio.
        /// </summary>
        public virtual string ObtenerInfo()
        {
            return $"Servicio: {GetType().Name}\n" +
                   $"Mascota: {_mascota?.Nombre}\n" +
                   $"Dueño: {_paciente?.NombreCompleto}\n" +
                   $"Fecha: {_fecha:dd/MM/yyyy HH:mm:ss}\n" +
                   $"Descripción: {_descripcion}";
        }

        /// <summary>
        /// Representación en texto del servicio.
        /// </summary>
        public override string ToString()
        {
            return $"[{GetType().Name}] {_mascota?.Nombre} - {_fecha:dd/MM/yyyy HH:mm:ss}";
        }
    }
}
