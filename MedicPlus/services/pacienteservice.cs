
using MedicPlus.Models;

namespace MedicPlus.Services
{
    public static class PacienteService
    {
        private static int _idContador = 1;

        public static void RegistrarPaciente(List<Paciente> lista)
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRAR NUEVO PACIENTE ===");

            
            string nombre = "";
            while (string.IsNullOrWhiteSpace(nombre))
            {
                Console.Write("Ingrese el nombre del paciente: ");
                nombre = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("❌ El nombre no puede estar vacío.");
                }
            }

            int edad = 0;
            bool edadValida = false;
            while (!edadValida)
            {
                Console.Write("Ingrese la edad del paciente: ");
                try
                {
                    edad = int.Parse(Console.ReadLine() ?? "0");
                    if (edad <= 0 || edad > 120)
                    {
                        Console.WriteLine("❌ Por favor, ingrese una edad válida (1 - 120).");
                    }
                    else
                    {
                        edadValida = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("❌ Error: Debe ingresar un número entero para la edad.");
                }
            }

            string sintoma = "";
            while (string.IsNullOrWhiteSpace(sintoma))
            {
                Console.Write("Ingrese el síntoma o motivo de consulta: ");
                sintoma = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(sintoma))
                {
                    Console.WriteLine("❌ El síntoma no puede estar vacío.");
                }
            }

            Paciente nuevoPaciente = new Paciente
            {
                Id = _idContador++,
                Nombre = nombre.Trim(),
                Edad = edad,
                Sintoma = sintoma.Trim()
            };

            lista.Add(nuevoPaciente);
            Console.WriteLine("\n✅ Paciente registrado exitosamente.");
            Console.WriteLine(nuevoPaciente);
            PresionarParaContinuar();
        }

        public static void ListarPacientes(List<Paciente> lista)
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE PACIENTES REGISTRADOS ===");

            if (lista.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados en el sistema.");
            }
            else
            {
                foreach (var paciente in lista)
                {
                    Console.WriteLine(paciente);
                }
            }
            PresionarParaContinuar();
        }

        public static void BuscarPacientePorNombre(List<Paciente> lista, string nombre)
        {
            Console.Clear();
            Console.WriteLine($"=== BÚSQUEDA DE PACIENTES: '{nombre}' ===");

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("❌ No ingresó un nombre válido para buscar.");
                PresionarParaContinuar();
                return;
            }

            var resultados = lista.Where(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("🔍 No se encontraron pacientes con ese nombre.");
            }
            else
            {
                foreach (var paciente in resultados)
                {
                    Console.WriteLine(paciente);
                }
            }
            PresionarParaContinuar();
        }

        private static void PresionarParaContinuar()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
