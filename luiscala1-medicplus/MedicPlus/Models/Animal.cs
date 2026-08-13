using System;

namespace MedicPlus.Models
{
    /// <summary>
    /// Clase abstracta que representa un animal genérico en el sistema.
    /// Sirve como base para todas las mascotas en la clínica.
    /// </summary>
    public abstract class Animal
    {
        private string _nombre;
        private int _edad;
        private string _especie;

        /// <summary>
        /// Constructor que inicializa los atributos del animal.
        /// </summary>
        protected Animal(string nombre, int edad, string especie)
        {
            _nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            _edad = edad >= 0 ? edad : throw new ArgumentException("La edad no puede ser negativa", nameof(edad));
            _especie = especie ?? throw new ArgumentNullException(nameof(especie));
        }

        /// <summary>
        /// Nombre del animal.
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        /// <summary>
        /// Edad del animal en años.
        /// </summary>
        public int Edad
        {
            get { return _edad; }
            set { _edad = value >= 0 ? value : throw new ArgumentException("La edad no puede ser negativa"); }
        }

        /// <summary>
        /// Especie del animal (Perro, Gato, Ave, etc.).
        /// </summary>
        public string Especie
        {
            get { return _especie; }
            set { _especie = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        /// <summary>
        /// Método abstracto que debe ser implementado por cada subclase.
        /// Cada especie emite un sonido diferente.
        /// </summary>
        public abstract string EmitirSonido();

        /// <summary>
        /// Simula que el animal duerme.
        /// </summary>
        public virtual void Dormir()
        {
            Console.WriteLine($"{Nombre} está durmiendo... 😴");
        }

        /// <summary>
        /// Simula que el animal come.
        /// </summary>
        public virtual void Comer()
        {
            Console.WriteLine($"{Nombre} está comiendo... 🍖");
        }

        /// <summary>
        /// Simula que el animal juega.
        /// </summary>
        public virtual void Jugar()
        {
            Console.WriteLine($"{Nombre} está jugando... 🎾");
        }

        /// <summary>
        /// Retorna información general del animal.
        /// </summary>
        public virtual string ObtenerInfo()
        {
            return $"[{Especie}] {Nombre} - {Edad} años";
        }

        /// <summary>
        /// Representación en texto del animal.
        /// </summary>
        public override string ToString()
        {
            return $"{ObtenerInfo()} - Sonido: {EmitirSonido()}";
        }
    }
}
