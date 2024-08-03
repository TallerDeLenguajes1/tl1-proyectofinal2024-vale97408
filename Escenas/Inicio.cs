using System;
using System.Collections.Generic;
using Fabrica;
using Juego;
using Personajes;

namespace Proyecto
{
    public class Inicio
    {
        public static void InicioJuego()
        {
            // Mostrar la pantalla de inicio
            Titulo.MostrarTituloDelJuego();

            // Solicitar nombre del jugador
            Console.WriteLine("Por favor, ingrese su nombre:");
            string nombreJugador = Console.ReadLine();

            // Dar la bienvenida al jugador
            Console.WriteLine($"\n¡Bienvenido, {nombreJugador}, al ARCANUM: TORNEO DE MAGIA!");

            // Crear instancias necesarias
            var fabrica = new FabricaDePersonajes();
            var persistencia = new PersonajesJson();

            // Nombre del archivo de personajes
            string nombreArchivo = "personajes.json";
            
            List<Personaje> personajes;

            // Verificar si el archivo de personajes existe
            if (persistencia.Existe(nombreArchivo))
            {
                // Leer los personajes del archivo
                personajes = persistencia.LeerPersonajes(nombreArchivo);
                
                if (personajes.Count > 0)
                {
                    Console.WriteLine("Personajes cargados exitosamente:");
                }
                else
                {
                    Console.WriteLine("El archivo de personajes está vacío. Generando nuevos personajes.");
                    personajes = GenerarPersonajes(fabrica);
                    persistencia.GuardarPersonajes(personajes, nombreArchivo);
                }
            }
            else
            {
                Console.WriteLine("Archivo de personajes no encontrado. Generando nuevos personajes.");
                personajes = GenerarPersonajes(fabrica);
                persistencia.GuardarPersonajes(personajes, nombreArchivo);
            }

            // Mostrar los datos y características de los personajes cargados
            MostrarPersonajes(personajes);
        }

        private static List<Personaje> GenerarPersonajes(FabricaDePersonajes fabrica)
        {
            var nombres = new List<string>
            {
                "Aegis", "Bran", "Eldric", "Darius",  "Fenwick","Fionn", "Gwen", "Thorne", "Ivar", "Jasper"
            };

            return fabrica.GeneradorDePersonajes(nombres);
        }

        private static void MostrarPersonajes(List<Personaje> personajes)
        {
            foreach (var personaje in personajes)
            {
                // Mostrar características del personaje
                Console.WriteLine($"Nombre: {personaje.Datos.Nombre}");
                Console.WriteLine($"Apodo: {personaje.Datos.Apodo}");
                Console.WriteLine($"Fecha de Nacimiento: {personaje.Datos.FechaDeNacimiento.ToShortDateString()}");
                Console.WriteLine($"Edad: {personaje.Datos.Edad}");
                Console.WriteLine($"Tipo: {personaje.Datos.Tipo}");
                Console.WriteLine($"Salud: {personaje.Caracteristicas.Salud}");
                Console.WriteLine($"Velocidad: {personaje.Caracteristicas.Velocidad}");
                Console.WriteLine($"Destreza: {personaje.Caracteristicas.Destreza}");
                Console.WriteLine($"Fuerza: {personaje.Caracteristicas.Fuerza}");
                Console.WriteLine($"Nivel: {personaje.Caracteristicas.Nivel}");
                Console.WriteLine($"Proteccion: {personaje.Caracteristicas.Proteccion}");
                Console.WriteLine();
            }
        }
    }
}
