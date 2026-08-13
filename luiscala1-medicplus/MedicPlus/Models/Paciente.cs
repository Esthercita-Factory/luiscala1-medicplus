
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicPlus.Models
{
    /// <summary>
    /// Representa un paciente (dueño) en la clínica veterinaria.
    /// Puede poseer una o varias mascotas.
    /// </summary>
    public class Paciente : IRegistrable
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private string _telefono;
        private string _email;
        private List<Mascota> _mascotasPropias;
        private DateTime _fechaRegistro;

        /// <summary>
        /// Constructor principal del paciente.
        /// </summary>
        public Paciente(int id, string nombre, string apellido, string direccion, string telefono, string email = "")
        {
            _id = id > 0 ? id : throw new ArgumentException("El ID debe ser mayor a 0", nameof(id));
            _nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            _apellido = apellido ?? throw new ArgumentNullException(nameof(apellido));
            _direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            _telefono = telefono ?? throw new ArgumentNullException(nameof(telefono));
            _email = email ?? string.Empty;
            _mascotasPropias = new List<Mascota>();
            _fechaRegistro = DateTime.Now;
        }

        /// <summary>
        /// Identificador único del paciente.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value > 0 ? value : throw new ArgumentException("El ID debe ser mayor a 0"); }
        }

        /// <summary>
        /// Nombre del dueño de la mascota.
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        /// <summary>
        /// Apellido del dueño.
        /// </summary>
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        /// <summary>
        /// Nombre completo (Nombre + Apellido).
        /// </summary>
        public string NombreCompleto => $"{_nombre} {_apellido}";

        /// <summary>
        /// Dirección del paciente (dueño).
        /// </summary>
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        /// <summary>
        /// Teléfono de contacto (datos sensibles).
        /// </summary>
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        /// <summary>
        /// Email de contacto.
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value ?? string.Empty; }
        }

        /// <summary>
        /// Fecha de registro en el sistema.
        /// </summary>
        public DateTime FechaRegistro
        {
            get { return _fechaRegistro; }
        }

        /// <summary>
        /// Colección de mascotas del paciente (lectura y acceso controlado).
        /// </summary>
        public IReadOnlyList<Mascota> MascotasPropias => _mascotasPropias.AsReadOnly();

        /// <summary>
        /// Cantidad de mascotas que posee.
        /// </summary>
        public int CantidadMascotas => _mascotasPropias.Count;

        /// <summary>
        /// Agrega una mascota a la lista de mascotas del paciente.
        /// </summary>
        public void AgregarMascota(Mascota mascota)
        {
            if (mascota == null)
                throw new ArgumentNullException(nameof(mascota));

            if (_mascotasPropias.Contains(mascota))
                throw new InvalidOperationException("Esta mascota ya está registrada para este paciente");

            mascota.AsignarPropietario(this);
            _mascotasPropias.Add(mascota);
            Console.WriteLine($"✓ Mascota '{mascota.Nombre}' agregada al paciente {NombreCompleto}");
        }

        /// <summary>
        /// Elimina una mascota de la lista.
        /// </summary>
        public bool EliminarMascota(Mascota mascota)
        {
            if (mascota != null && _mascotasPropias.Remove(mascota))
            {
                Console.WriteLine($"✓ Mascota '{mascota.Nombre}' eliminada del paciente {NombreCompleto}");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Obtiene una mascota por su nombre.
        /// </summary>
        public Mascota? ObtenerMascotaPorNombre(string nombre)
        {
            return _mascotasPropias.FirstOrDefault(m => m.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Obtiene información del paciente.
        /// </summary>
        public string ObtenerInfo()
        {
            return $"Paciente: {NombreCompleto}\n" +
                   $"Dirección: {_direccion}\n" +
                   $"Teléfono: {_telefono}\n" +
                   $"Email: {_email}\n" +
                   $"Mascotas: {CantidadMascotas}";
        }

        /// <summary>
        /// Registra el paciente en el sistema.
        /// </summary>
        public string Registrar()
        {
            return $"[REGISTRO] Paciente '{NombreCompleto}' (ID: {_id}) registrado en el sistema el {_fechaRegistro:dd/MM/yyyy HH:mm:ss}";
        }

        /// <summary>
        /// Muestra todas las mascotas del paciente.
        /// </summary>
        public void MostrarMascotas()
        {
            Console.WriteLine($"\n--- Mascotas de {NombreCompleto} ---");
            if (_mascotasPropias.Count == 0)
            {
                Console.WriteLine("No tiene mascotas registradas.");
                return;
            }

            foreach (var mascota in _mascotasPropias)
            {
                Console.WriteLine($"  • {mascota.ObtenerInfo()}");
            }
        }

        /// <summary>
        /// Representación en texto del paciente.
        /// </summary>
        public override string ToString()
        {
            return $"[ID: {_id}] {NombreCompleto} - Tel: {_telefono} - Mascotas: {CantidadMascotas}";
        }

        // Propiedades legacy para compatibilidad con código existente
        public string NombreDuenio { get => NombreCompleto; set => _nombre = value; }
        public string NombreMascota { get; set; } = string.Empty;
        public string Especie { get; set; } = string.Empty;
        public string Raza { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string Sintoma { get; set; } = string.Empty;
    }
}