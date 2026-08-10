
using System;
using MedicPlus.Models;
using MedicPlus.Services;

namespace MedicPlus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("       SISTEMA MEDICPLUS - GESTIÓN VETERINARIA");
            Console.WriteLine("====================================================\n");

            var servicio = new PacienteService();

            // TASK 1: Probar Colecciones
            Console.WriteLine("--- TASK 1: Manejo de Colecciones y Diccionario ---");
            servicio.AgregarPaciente(new Paciente { Id = 6, NombreDuenio = "Pedro Infante", Telefono = "3127776655", NombreMascota = "Bruno", Especie = "Perro", Raza = "Bulldog", Edad = 3, Sintoma = "Alergia cutánea" });
            servicio.ModificarTelefono(1, "3009990000");
            servicio.EliminarPaciente(6);

            var paciente2 = servicio.ObtenerPorId(2);
            Console.WriteLine($"Consulta rápida Diccionario [ID 2]: {paciente2?.NombreMascota} ({paciente2?.Especie}) - Dueño: {paciente2?.NombreDuenio}");

            // TASK 2: Operadores Básicos LINQ
            Console.WriteLine("\n--- TASK 2: Operadores Básicos LINQ ---");
            Console.WriteLine($"Pacientes con mascota mayor a 3 años: {servicio.FiltrarPorEdadMinima(3).Count()}");
            
            Console.WriteLine("Agrupación por especies:");
            foreach (var grupo in servicio.AgruparPorEspecie())
            {
                Console.WriteLine($" - Especie [{grupo.Key}]: {grupo.Count()} paciente(s)");
            }

            // TASK 4: Consultas Encadenadas
            Console.WriteLine("\n--- TASK 4: Consultas Encadenadas ---");
            var infoContactoPerros = servicio.ObtenerContactoDueniosDeEspecie("Perro");
            foreach (var info in infoContactoPerros)
            {
                Console.WriteLine($" - Dueño: {info.Propietario} | Contacto: {info.Contacto} | Mascota: {info.Mascota} ({info.EdadMascota} años)");
            }

            // TASK 5: Problemas Prácticos
            Console.WriteLine("\n--- TASK 5: Problemas Prácticos ---");
            var (masJoven, masViejo) = servicio.ObtenerPacienteExtremosEdad();
            Console.WriteLine($"1. Mascota más joven: {masJoven?.NombreMascota} ({masJoven?.Edad} años)");
            Console.WriteLine($"   Mascota más vieja: {masViejo?.NombreMascota} ({masViejo?.Edad} años)");

            Console.WriteLine("\n2. Conteo por especie:");
            foreach (var kvp in servicio.ContarMascotasPorEspecie())
            {
                Console.WriteLine($"   - {kvp.Key}: {kvp.Value}");
            }

            Console.WriteLine($"\n3. ¿Existe alguna mascota sin raza definida?: {servicio.ExisteMascotaSinRaza()}");

            Console.WriteLine("\n4. Nombres de dueños en mayúsculas ordenados:");
            foreach (var nombre in servicio.ObtenerDueniosEnMayusculasOrdenados())
            {
                Console.WriteLine($"   - {nombre}");
            }

            Console.WriteLine("\n====================================================");
        }
    }
}