using System;
using System.Collections.Generic;
using System.Linq;
using MedicPlus.Models;

namespace MedicPlus.Services
{
    public class PacienteService
    {
        private readonly List<Paciente> _pacientes;
        private readonly Dictionary<int, Paciente> _pacientesDiccionario;

        public PacienteService()
        {
            // Inicialización de datos de prueba
            _pacientes = new List<Paciente>
            {
                new Paciente(1, "Carlos", "Pérez", "Calle 45 #12-34", "3001234567", "carlos@email.com") 
                { NombreMascota = "Max", Especie = "Perro", Raza = "Labrador", Edad = 5, Sintoma = "Fiebre y decaimiento" },
                new Paciente(2, "María", "Gómez", "Av. Principal 100", "3109876543", "maria@email.com")
                { NombreMascota = "Michi", Especie = "Gato", Raza = "Siames", Edad = 2, Sintoma = "Pérdida de apetito" },
                new Paciente(3, "Andrés", "López", "Calle 10 #5-6", "3204567890", "andres@email.com")
                { NombreMascota = "Rocky", Especie = "Perro", Raza = "", Edad = 8, Sintoma = "Cojera en pata trasera" },
                new Paciente(4, "Laura", "Martínez", "Cra. 5 #25-50", "3151112233", "laura@email.com")
                { NombreMascota = "Luna", Especie = "Gato", Raza = "Persa", Edad = 1, Sintoma = "Chequeo de rutina" },
                new Paciente(5, "Sofia", "Ramírez", "Calle 8 #10-2", "3018889900", "sofia@email.com")
                { NombreMascota = "Paco", Especie = "Ave", Raza = "Loro Cotorra", Edad = 12, Sintoma = "Plumas caídas" }
            };

            _pacientesDiccionario = _pacientes.ToDictionary(p => p.Id);
        }

        // --- TASK 1: Operaciones sobre Colecciones ---
        public void AgregarPaciente(Paciente paciente)
        {
            _pacientes.Add(paciente);
            _pacientesDiccionario[paciente.Id] = paciente;
        }

        public bool ModificarTelefono(int id, string nuevoTelefono)
        {
            if (_pacientesDiccionario.TryGetValue(id, out var paciente))
            {
                paciente.Telefono = nuevoTelefono;
                return true;
            }
            return false;
        }

        public bool EliminarPaciente(int id)
        {
            var paciente = _pacientesDiccionario.GetValueOrDefault(id);
            if (paciente != null)
            {
                _pacientes.Remove(paciente);
                _pacientesDiccionario.Remove(id);
                return true;
            }
            return false;
        }

        public Paciente? ObtenerPorId(int id)
        {
            _pacientesDiccionario.TryGetValue(id, out var paciente);
            return paciente;
        }

        public IEnumerable<Paciente> ObtenerTodos() => _pacientes;

        // --- TASK 2 & 4: Consultas y Encadenamiento LINQ ---
        public IEnumerable<Paciente> FiltrarPorEdadMinima(int edadMinima)
        {
            return _pacientes.Where(p => p.Edad > edadMinima);
        }

        public IEnumerable<string> ObtenerNombresDuenios()
        {
            return _pacientes.Select(p => p.NombreDuenio);
        }

        public IEnumerable<IGrouping<string, Paciente>> AgruparPorEspecie()
        {
            return _pacientes.GroupBy(p => p.Especie);
        }

        // TASK 4: Encadenamiento (Perros ordenados por edad proyectando contacto)
        public IEnumerable<dynamic> ObtenerContactoDueniosDeEspecie(string especie)
        {
            return _pacientes
                .Where(p => p.Especie.Equals(especie, StringComparison.OrdinalIgnoreCase))
                .OrderBy(p => p.Edad)
                .Select(p => new
                {
                    Propietario = p.NombreDuenio,
                    Contacto = p.Telefono,
                    Mascota = p.NombreMascota,
                    EdadMascota = p.Edad
                });
        }

        // --- TASK 5: Resolución de Problemas Prácticos ---
        public (Paciente? MasJoven, Paciente? MasViejo) ObtenerPacienteExtremosEdad()
        {
            if (!_pacientes.Any()) return (null, null);

            var masJoven = _pacientes.OrderBy(p => p.Edad).FirstOrDefault();
            var masViejo = _pacientes.OrderByDescending(p => p.Edad).FirstOrDefault();

            return (masJoven, masViejo);
        }

        public Dictionary<string, int> ContarMascotasPorEspecie()
        {
            return _pacientes
                .GroupBy(p => p.Especie)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public bool ExisteMascotaSinRaza()
        {
            return _pacientes.Any(p => string.IsNullOrWhiteSpace(p.Raza));
        }

        public IEnumerable<string> ObtenerDueniosEnMayusculasOrdenados()
        {
            return _pacientes
                .Select(p => p.NombreDuenio.ToUpper())
                .OrderBy(nombre => nombre);
        }
    }
}