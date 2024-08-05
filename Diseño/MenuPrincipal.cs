using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Json;

namespace Proyecto
{
    public class MenuPrincipal
    {
        string [] opciones; 
        int eleccion;
        public MenuPrincipal(string [] Opciones)
        {
            opciones = Opciones;
            eleccion=0; 
        }


        /* public static void MostrarMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string titulo = @"
                              ---𝕄𝕖𝕟𝕦 ℙ𝕣𝕚𝕟𝕔𝕚𝕡𝕒𝕝---
";
            string[] opciones = {
                "1. Cᴏᴍᴇɴᴢᴀʀ ᴀ Jᴜɢᴀʀ",
                "2. Vᴇʀ Hɪsᴛᴏʀɪᴀʟ ᴅᴇ Gᴀɴᴀᴅᴏʀᴇs",
                "3. Vᴇʀ Iɴғᴏʀᴍᴀᴄɪᴏ́ɴ ᴅᴇ Pᴇʀsᴏɴᴀᴊᴇs",
                "4. Cᴀʀᴀᴄᴛᴇʀɪ́sᴛɪᴄᴀs ᴅᴇ ʟᴏs Pʟᴀɴᴇᴛᴀs",
                "5. Sᴀʟɪʀ"
            };

            Console.Clear();
            Console.WriteLine(titulo);
            Console.WriteLine("\n---- MENÚ PRINCIPAL ----");
            MostrarOpciones(opciones);

            while (true)
            {
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                switch (tecla.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        ComenzarJuego();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        MostrarHistorialDeGanadores();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        MostrarInformacionPersonajes();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        MostrarCaracteristicasPlanetas();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        SalirDelJuego();
                        return; // Salir del bucle y terminar el programa
                }
            }
        } */

        private  void MostrarOpciones(string[] opciones)
        {
             Console.ResetColor();
             for (int i = 0; i < opciones.Length; i++)
             {
                if(i == eleccion)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"{i + 1}. {opciones[i]}");
             }
             Console.ResetColor();
        }
         public int Display()
        {
            ConsoleKeyInfo teclaPresionada;
            do
            {
                Console.Clear();
                MostrarOpciones(opciones);
                teclaPresionada = Console.ReadKey(true);

                switch (teclaPresionada.Key)
                {
                    case ConsoleKey.DownArrow:
                        eleccion = eleccion == opciones.Length-1 ? 0: eleccion+1;
                        break;
                    case ConsoleKey.UpArrow:
                        eleccion = eleccion == 0 ? opciones.Length-1: eleccion-1;
                        break;
                }

            } while (teclaPresionada.Key != ConsoleKey.Enter);
            return eleccion;
        }



        private static void ComenzarJuego()
        {
            Console.Clear();
            Console.WriteLine("Comenzando el juego...");
            // Aquí llamas a la función que inicia el juego
            // Ejemplo: Juego.Iniciar();
        }

        private static void MostrarHistorialDeGanadores()
        {
            Console.Clear();
            string historialArchivo = "historial.json";
            if (File.Exists(historialArchivo))
            {
                var historialJson = File.ReadAllText(historialArchivo);
              //  var historial = JsonContent<List<HistorialGanador>>(historialJson);
               // foreach (var ganador in historial)
                // {
                //     Console.WriteLine($"Nombre: {ganador.Nombre}");
                //     Console.WriteLine($"Fecha: {ganador.Fecha}");
                //     Console.WriteLine($"Título: {ganador.Titulo}");
                //     Console.WriteLine();
                // }
            }
            else
            {
                Console.WriteLine("No hay historial de ganadores disponible.");
            }
            Console.WriteLine("Presione una tecla para regresar al menú.");
            Console.ReadKey();
        }

        private static void MostrarInformacionPersonajes()
        {
            Console.Clear();
            Console.WriteLine("Información de Personajes:");
            // Aquí llamas a la función que muestra la información de los personajes
            // Ejemplo: Personajes.MostrarInformacion();
            // Implementar la lógica para mostrar información de personajes
            Console.WriteLine("Información de personajes aún no implementada.");
            Console.WriteLine("Presione una tecla para regresar al menú.");
            Console.ReadKey();
        }

        private static void MostrarCaracteristicasPlanetas()
        {
            Console.Clear();
            Console.WriteLine("Características de los Planetas:");
            // Aquí llamas a la función que muestra las características de los planetas
            // Ejemplo: Planetas.MostrarCaracteristicas();
            // Implementar la lógica para mostrar características de los planetas
            Console.WriteLine("Características de los planetas aún no implementadas.");
            Console.WriteLine("Presione una tecla para regresar al menú.");
            Console.ReadKey();
        }

        private static void SalirDelJuego()
        {
            Console.Clear();
            Console.WriteLine("Saliendo del juego...");
            System.Threading.Thread.Sleep(2000);
            Environment.Exit(0);
        }
    }

    public class HistorialGanador
    {
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public string Titulo { get; set; }
    }
}
