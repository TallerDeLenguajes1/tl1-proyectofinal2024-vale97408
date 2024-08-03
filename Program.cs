using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto;
using Personajes;

namespace Proyecto
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Mostrar título del juego
            Titulo.MostrarTituloDelJuego();

            // Solicitar nombre del jugador
            Console.WriteLine("Por favor, ingrese su nombre:");
            string nombreJugador = Console.ReadLine();

            // Dar la bienvenida al jugador
            Console.WriteLine($"\n¡Bienvenido, {nombreJugador}, al ARCANUM: TORNEO DE MAGIA!");

            // Generar personajes
            List<string> nombres = new List<string> { "Vesper", "Fenwick", "Thorne", "Eldric", "Draven" };
            FabricaDePersonajes fabrica = new FabricaDePersonajes();
            List<Personaje> personajes = fabrica.GeneradorDePersonajes(nombres);

            // Mostrar personajes generados
            Console.WriteLine("\nPersonajes disponibles para elegir:");
            for (int i = 0; i < personajes.Count; i++)
            {
                var personaje = personajes[i];
                Console.WriteLine($"{i + 1}. Nombre: {personaje.Nombre}, Apodo: {personaje.Apodo}, Tipo: {personaje.Tipo}, Edad: {personaje.Edad}, Salud: {personaje.Salud}");
                Console.WriteLine($"   Características -> Velocidad: {personaje.Velocidad}, Destreza: {personaje.Destreza}, Fuerza: {personaje.Fuerza}, Nivel: {personaje.Nivel}, Armadura: {personaje.Armadura}");
                Console.WriteLine();
            }

            // Solicitar al jugador que elija un personaje
            Console.WriteLine("Ingrese el número del personaje que desea elegir:");
            int eleccion;
            while (!int.TryParse(Console.ReadLine(), out eleccion) || eleccion < 1 || eleccion > personajes.Count)
            {
                Console.WriteLine("Selección no válida. Por favor, ingrese un número válido:");
            }

            Personaje personajeElegido = personajes[eleccion - 1];
            Console.WriteLine($"\nHas elegido a {personajeElegido.Nombre}, el {personajeElegido.Tipo}.");

            // Obtener datos de planetas
            Planetas planetas = await PlanetasAPI.GetWeatherAsync();
            if (planetas != null && planetas.Results.Count > 0)
            {
                // Mostrar un planeta aleatorio de la API
                Random random = new Random();
                Result planeta = planetas.Results[random.Next(planetas.Results.Count)];

                Console.WriteLine("\nPlaneta de combate:");
                Console.WriteLine($"Nombre: {planeta.Name}, Clima: {planeta.Climate}, Gravedad: {planeta.Gravity}, Terreno: {planeta.Terrain}");
            }
            else
            {
                Console.WriteLine("\nNo se pudieron obtener los datos de los planetas.");
            }

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}