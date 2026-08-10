namespace Medicplus.Services
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
                    Console.WriteLine("❌ El nombre no puede estar vacío. Inténtelo de nuevo.");
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
                        Console.WriteLine("❌ Ingrese una edad realista (entre 1 y 120 años).");
                    }
                    else
                    {
                        edadValida = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("❌ Error: La edad debe ser un número entero válido.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("❌ Error: El número ingresado es demasiado grande.");
                }
            }

            string sintoma = "";
            while (string.IsNullOrWhiteSpace(sintoma))
            {
                Console.Write("Ingrese el síntoma o motivo de consulta: ");
                sintoma = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(sintoma))
                {
                    Console.WriteLine("❌ El síntoma no puede estar vacío. Inténtelo de nuevo.");
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
            Console.WriteLine("\n✅ Paciente registrado con éxito.");
            Console.WriteLine(nuevoPaciente.ToString());
            PresionarParaContinuar();
        }

        public static void ListarPacientes(List<Paciente> lista)
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE PACIENTES REGISTRADOS ===");

            if (lista.Count == 0)
            {
                Console.WriteLine("No hay ningún paciente registrado en el sistema actualmente.");
            }
            else
            {
                foreach (var Paciente in lista)
                {
                    Console.WriteLine(Paciente);
                }
            }
            PresionarParaContinuar();
        }

        public static void BuscarPacientePorNombre(List<Paciente> lista, string nombre)
        {
            Console.Clear();
            Console.WriteLine($"=== RESULTADOS DE BÚSQUEDA PARA: '{nombre}' ===");

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("❌ No se ingresó un criterio de búsqueda válido.");
                PresionarParaContinuar();
                return;
            }

            var resultados = lista.Where(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("🔍 No se encontraron pacientes que coincidan con ese nombre.");
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
            Console.WriteLine("\nPresione cualquier tecla para regresar al menú...");
            Console.ReadKey();
        }
    }
}
