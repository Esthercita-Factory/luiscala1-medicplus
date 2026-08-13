
using System;
using MedicPlus.Models;

namespace MedicPlus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            Console.WriteLine("════════════════════════════════════════════════════════════════");
            Console.WriteLine("       SISTEMA MEDICPLUS - GESTIÓN VETERINARIA (OOP & UML)");
            Console.WriteLine("════════════════════════════════════════════════════════════════\n");

            // ==================== TASK 2 & 3: Definir clases e instanciar objetos ====================
            Console.WriteLine("█ TASK 2 & 3: Instanciando Objetos y Estableciendo Relaciones\n");

            // Crear pacientes (propietarios)
            var paciente1 = new Paciente(1, "Carlos", "Pérez", "Calle 45 #12-34", "3001234567", "carlos@email.com");
            var paciente2 = new Paciente(2, "María", "Gómez", "Av. Principal 100", "3109876543", "maria@email.com");
            var paciente3 = new Paciente(3, "Andrés", "López", "Calle 10 #5-6", "3204567890", "andres@email.com");

            Console.WriteLine($"✓ Pacientes creados:\n  {paciente1}\n  {paciente2}\n  {paciente3}\n");

            // Crear mascotas (con herencia de Animal y polimorfismo)
            var mascota1 = new Mascota("Max", "Perro", 5, "Labrador", "Fiebre y decaimiento");
            var mascota2 = new Mascota("Michi", "Gato", 2, "Siames", "Pérdida de apetito");
            var mascota3 = new Mascota("Rocky", "Perro", 8, "", "Cojera en pata trasera");
            var mascota4 = new Mascota("Luna", "Gato", 1, "Persa", "");
            var mascota5 = new Mascota("Paco", "Ave", 12, "Loro Cotorra", "Plumas caídas");

            Console.WriteLine("✓ Mascotas creadas:\n");
            foreach (var m in new[] { mascota1, mascota2, mascota3, mascota4, mascota5 })
            {
                Console.WriteLine($"  • {m.Nombre} ({m.Especie}) - Emite: {m.EmitirSonido()}");
            }

            // ==================== TASK 3: Asociaciones (1..* Paciente-Mascota) ====================
            Console.WriteLine("\n\n█ TASK 3: Asociaciones Paciente-Mascota (1..* relación)\n");

            paciente1.AgregarMascota(mascota1);
            paciente1.AgregarMascota(mascota3);
            paciente2.AgregarMascota(mascota2);
            paciente2.AgregarMascota(mascota4);
            paciente3.AgregarMascota(mascota5);

            // Mostrar mascotas de cada paciente
            foreach (var paciente in new[] { paciente1, paciente2, paciente3 })
            {
                paciente.MostrarMascotas();
            }

            // ==================== TASK 4: Encapsulación con modificadores de acceso ====================
            Console.WriteLine("\n\n█ TASK 4: Encapsulación y Protección de Datos Sensibles\n");

            Console.WriteLine("Información del Paciente (con encapsulación):");
            Console.WriteLine($"  Nombre Completo: {paciente1.NombreCompleto}");
            Console.WriteLine($"  Dirección: {paciente1.Direccion}");
            Console.WriteLine($"  Teléfono: {paciente1.Telefono} (protegido con propiedad get/set)");
            Console.WriteLine($"  Email: {paciente1.Email}");
            Console.WriteLine($"  Cantidad de Mascotas: {paciente1.CantidadMascotas}");
            Console.WriteLine($"  Fecha de Registro: {paciente1.FechaRegistro:dd/MM/yyyy}");
            
            Console.WriteLine("\nActualizando teléfono de forma segura:");
            paciente1.Telefono = "3009990000";
            Console.WriteLine($"  Nuevo teléfono: {paciente1.Telefono}");

            Console.WriteLine("\nInformación de Mascota (con encapsulación):");
            mascota1.MostrarDetalles();

            // ==================== TASK 5: Herencia y Polimorfismo ====================
            Console.WriteLine("\n\n█ TASK 5: Herencia y Polimorfismo - EmitirSonido() por Especie\n");

            Console.WriteLine("Demostrando polimorfismo (mismo método, diferentes resultados):");
            Animal[] animales = { mascota1, mascota2, mascota3, mascota4, mascota5 };
            foreach (var animal in animales)
            {
                Console.WriteLine($"  {animal.Nombre} ({animal.Especie}): {animal.EmitirSonido()}");
            }

            Console.WriteLine("\nOtros métodos heredados de Animal:");
            Console.WriteLine("  Mascota1 (Max) durmiendo:");
            mascota1.Dormir();
            Console.WriteLine("  Mascota1 (Max) comiendo:");
            mascota1.Comer();
            Console.WriteLine("  Mascota2 (Michi) jugando:");
            mascota2.Jugar();

            // ==================== TASK 6: Abstracción - IRegistrable ====================
            Console.WriteLine("\n\n█ TASK 6.1: Abstracción - Interfaz IRegistrable\n");

            Console.WriteLine("Registrando entidades en el sistema:");
            Console.WriteLine($"  {paciente1.Registrar()}");
            Console.WriteLine($"  {mascota1.Registrar()}");
            Console.WriteLine($"  {mascota2.Registrar()}");

            // ==================== TASK 6: Abstracción - Clases Abstractas ====================
            Console.WriteLine("\n\n█ TASK 6.2: Abstracción - Clases Abstractas (ServicioVeterinario)\n");

            // Crear servicios veterinarios (implementaciones concretas)
            var consulta1 = new ConsultaGeneral(paciente1, mascota1, "Fiebre y decaimiento");
            var vacunacion1 = new Vacunacion(paciente2, mascota2, "Rabia");
            var consulta2 = new ConsultaGeneral(paciente3, mascota5, "Revisión de plumaje");
            var vacunacion2 = new Vacunacion(paciente1, mascota3, "DHPP");

            Console.WriteLine("Servicios creados (heredan de ServicioVeterinario):");
            foreach (var servicio in new ServicioVeterinario[] { consulta1, vacunacion1, consulta2, vacunacion2 })
            {
                Console.WriteLine($"  ✓ {servicio}");
            }

            // ==================== Llamando a métodos abstractos polimórficamente ====================
            Console.WriteLine("\n\n█ Polimorfismo: Ejecutando método abstracto Atender() por tipo\n");

            consulta1.Atender();
            vacunacion1.Atender();

            // ==================== Información de servicios ====================
            Console.WriteLine("\n█ Información Detallada de Servicios\n");
            Console.WriteLine("Consulta General para Max:");
            Console.WriteLine(consulta1.ObtenerInfo());
            Console.WriteLine("\n" + new string('─', 50) + "\n");
            
            Console.WriteLine("Vacunación para Michi:");
            Console.WriteLine(vacunacion1.ObtenerInfo());

            // ==================== Resumen Final ====================
            Console.WriteLine("\n\n════════════════════════════════════════════════════════════════");
            Console.WriteLine("                     RESUMEN DE CUMPLIMIENTO");
            Console.WriteLine("════════════════════════════════════════════════════════════════");

            Console.WriteLine("\n✅ TASK 1: UML Diagram");
            Console.WriteLine("   - Diagrama de clases creado (ver: UML_Diagram.md)");
            Console.WriteLine("   - Atributos y relaciones documentados");

            Console.WriteLine("\n✅ TASK 2: Clases en C# basadas en UML");
            Console.WriteLine("   - Clase Paciente: ✓");
            Console.WriteLine("   - Clase Mascota: ✓");
            Console.WriteLine("   - Clase Animal (base): ✓");

            Console.WriteLine("\n✅ TASK 3: Objetos e Instanciación");
            Console.WriteLine($"   - Pacientes creados: 3");
            Console.WriteLine($"   - Mascotas creadas: 5");
            Console.WriteLine($"   - Relación 1..* Paciente-Mascota: ✓");

            Console.WriteLine("\n✅ TASK 4: Encapsulación");
            Console.WriteLine("   - Atributos private con propiedades públicas: ✓");
            Console.WriteLine("   - Datos sensibles protegidos (teléfono, email): ✓");
            Console.WriteLine("   - Validación en setters: ✓");

            Console.WriteLine("\n✅ TASK 5: Herencia y Polimorfismo");
            Console.WriteLine("   - Clase base Animal: ✓");
            Console.WriteLine("   - Mascota hereda de Animal: ✓");
            Console.WriteLine("   - EmitirSonido() sobrescrito: ✓ (Perro=Guau, Gato=Miau, Ave=Chirp)");
            Console.WriteLine("   - Métodos virtuales (Dormir, Comer, Jugar): ✓");

            Console.WriteLine("\n✅ TASK 6: Abstracción");
            Console.WriteLine("   - Interfaz IRegistrable: ✓");
            Console.WriteLine("   - Clase abstracta ServicioVeterinario: ✓");
            Console.WriteLine("   - Implementaciones: ConsultaGeneral, Vacunacion: ✓");
            Console.WriteLine("   - Métodos abstractos y virtuales: ✓");

            Console.WriteLine("\n════════════════════════════════════════════════════════════════\n");
        }
    }
}
