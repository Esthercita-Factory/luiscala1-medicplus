
using MedicPlus.Models;
using MedicPlus.Services;

namespace MedicPlus
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Paciente> pacientes = new List<Paciente>();
            bool salir = false;

            
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("       SISTEMA CLÍNICA SALUD+          ");
                Console.WriteLine("=======================================");
                Console.WriteLine("1. Registrar paciente");
                Console.WriteLine("2. Listar pacientes");
                Console.WriteLine("3. Buscar paciente por nombre");
                Console.WriteLine("4. Salir");
                Console.WriteLine("=======================================");
                Console.Write("Seleccione una opción (1-4): ");

                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        PacienteService.RegistrarPaciente(pacientes);
                        break;
                    case "2":
                        PacienteService.ListarPacientes(pacientes);
                        break;
                    case "3":
                        Console.Clear();
                        Console.Write("Ingrese el nombre del paciente a buscar: ");
                        string criterio = Console.ReadLine() ?? "";
                        PacienteService.BuscarPacientePorNombre(pacientes, criterio);
                        break;
                    case "4":
                        salir = true;
                        Console.WriteLine("\nGracias por usar el sistema de Clínica Salud+. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("\n❌ Opción no válida. Intente con un número del 1 al 4.");
                        Console.WriteLine("Presione cualquier tecla para reintentar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
