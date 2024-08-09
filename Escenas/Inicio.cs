using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Media;
using Fabrica;
using Personajes;


namespace Proyecto
{
    public class Inicio
    {
        public void InicioJuego()
        {
            //Sonido.ReproducirSonidoLargoBucle(Sonido.SonidoInicio);

            // Mostrar la pantalla de inicio
            Titulo.MostrarTituloDelJuego();

            // Solicitar nombre del jugador
            //Console.WriteLine("POR FAVOR, INGRESE SU NOMBRE:");
            Titulo.MostrarTextoProgresivo("POR FAVOR, INGRESE SU NOMBRE:",10);
            string nombreJugador = Console.ReadLine();
            Console.Clear();

            // Dar la bienvenida al jugador y contexto del juego
            Titulo.TextoBienvenida(nombreJugador);

            // ------CONTROL DE PERSISTENCIA DE PERSONAJES 

            // Crear instancias necesarias
            FabricaDePersonajes fabrica = new FabricaDePersonajes();
            PersonajesJson persistPerJson = new PersonajesJson();
            HistorialJson persistHistJson = new HistorialJson();

            // Nombre del archivo de personajes
            string nombreArchivoPersonajes = "personajes.json";
            string nombreArchivoGanadores = "historialGanadores.json";


            List<Personaje> personajes = PersonajesJson.PersitenciaPersonajes(); // Lista ya generada de la FABRICA DE PERSONAJEScon el debido control


            // ------------------MENU DEL JUEGO--------------------
            bool continuar = true;

            // REPITE EL MENU HASTA EL JUGADOR DECIDA SALIR 
            while (continuar)
            {
                string[] opciones = ["Jugar", "Historial de Ganadores", "Info Personajes", "Salir"];
                MenuPrincipal menu = new MenuPrincipal(opciones);
                int opcionElegida = menu.Display();
                //Sonido.ReproducirSonido(Sonido.EleccionRealizada);

                switch (opcionElegida)
                {
                    case 0:
                        // JUGAR
                        Console.Clear();
                        int opcionJuego;
                        bool opcionValida = false;
                        while (!opcionValida)
                        {
                            CentrarTexto("¿DESEA JUGAR CON PERSONAJES PRECARGADOS O GENERAR NUEVOS?");
                            Console.WriteLine("1. Jugar con personajes precargados");
                            Console.WriteLine("2. Generar nuevos personajes");
                            Console.WriteLine("- Presiona cualquier otra tecla para: Volver al MENÚ PRINCIPAL");

                            string entrada = Console.ReadLine();
                            if (int.TryParse(entrada, out opcionJuego) && (opcionJuego == 1 || opcionJuego == 2))
                            {
                                opcionValida = true;
                                if (opcionJuego == 1)
                                {
                                    Console.Clear();
                                    Juego.ComenzarJuego(personajes, nombreJugador);
                                }
                                else
                                {
                                    if (opcionJuego == 2)
                                    {
                                        personajes.Clear();  // Limpio la lista antes de generar nuevos personajes
                                                             // Genero los 10 personajes (10 por la cantidad de nombres que tengo)
                                        personajes = PersonajesJson.GenerarPersonajes(fabrica);
                                        persistPerJson.GuardarPersonajes(personajes, nombreArchivoPersonajes);
                                        Console.Clear();
                                        Juego.ComenzarJuego(personajes, nombreJugador);
                                    }
                                }

                            }
                            else
                            {
                                break;// Vuelve al menu principal
                            }
                        }
                        break;

                    case 1:
                        // Historial Json
                        persistHistJson.MostrarListadoGanadores(nombreArchivoGanadores);
                        Titulo.MostrarTextoProgresivo("Presiona cualquier tecla para volver al MENÚ PRINCIPAL.", 10);
                        //Console.Write("\nPresiona cualquier tecla para volver al MENU PRINCIPAL");
                        Console.ReadKey();

                        break;
                    case 2:
                        // Info personajes
                        InicioExtras.MostrarPersonajes(personajes);
                        Titulo.MostrarTextoProgresivo("Presiona cualquier tecla para volver al MENÚ PRINCIPAL.", 10);
                        //Console.Write("\nPresiona cualquier tecla para volver al MENU PRINCIPAL");
                        Console.ReadKey();

                        break;
                    case 3:
                        // Salir
                        continuar = false;
                        Titulo.TextoDespedida();
                        break;
                }
            }
        }

        //------------FUNCIONES UTILIZADAS------------------
        public static void CentrarTexto(string texto)
        {
            string[] lineas = texto.Split("\n");
            int consoleWidth = Console.BufferWidth;

            foreach (var linea in lineas)
            {
                int padding = (consoleWidth - linea.Length) / 2;

                // Asegúrate de que el padding no sea negativo
                if (padding < 0)
                {
                    padding = 0;
                }
                Console.SetCursorPosition(padding, Console.CursorTop);
                Console.WriteLine(linea);
            }
        }

    }
}
