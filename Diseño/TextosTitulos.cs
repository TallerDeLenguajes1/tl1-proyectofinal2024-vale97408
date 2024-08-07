using System;
using System.Threading;

namespace Proyecto
{
    public class Titulo
    {
        public static void MostrarTituloDelJuego()
        {
            Console.Clear();
            //Console.ForegroundColor = ConsoleColor.Cyan;
            string titulo = @"

                                           *                *               *                *              *                *
                                         * * *            * * *           * * *            * * *          * * *            * * *
                                           *                *               *                *              *                *
                                *                                                                                                      *
                              * * *             ___      .______        ______      ___      .__   __.  __    __  .___  ___.         * * * 
                                *              /   \     |   _  \      /      |    /   \     |  \ |  | |  |  |  | |   \/   |           *
                                              /  ^  \    |  |_)  |    |  ,----'   /  ^  \    |   \|  | |  |  |  | |  \  /  | 
                                    *        /  /_\  \   |      /     |  |       /  /_\  \   |  . `  | |  |  |  | |  |\/|  |      *
                                  * * *     /  _____  \  |  |\  \----.|  `----. /  _____  \  |  |\   | |  `--'  | |  |  |  |    * * * 
                                    *      /__/     \__\ | _| `._____| \______|/__/     \__\ |__| \__|  \______/  |__|  |__|      *
                                 
                                   *       _____                                   ______        ___  ___               _           *     
                                 * * *    |_   _|                                  |  _  \       |  \/  |              (_)        * * *
                                   *        | |    ___   _ __  _ __    ___   ___   | | | |  ___  | .  . |  __ _   __ _  _   __ _    *
                               *            | |   / _ \ | '__|| '_ \  / _ \ / _ \  | | | | / _ \ | |\/| | / _` | / _` || | / _` |         *
                             * * *          | |  | (_) || |   | | | ||  __/| (_) | | |/ / |  __/ | |  | || (_| || (_| || || (_| |       * * *
                               *            \_/   \___/ |_|   |_| |_| \___| \___/  |___/   \___| \_|  |_/ \__,_| \__, ||_| \__,_|         *
                                                                                                                  __/ |          
                                                                                                                 |___/
                                           *                *               *                *              *                *
                                         * * *            * * *           * * *            * * *          * * *            * * *
                                           *                *               *                *              *                *
 ";
               
            //Inicio.CentrarTexto(titulo);
           // Console.WriteLine(titulo);


         int titilarDuracion = 700; // Tiempo en milisegundos para titilar
        int totalTitilaciones = 10; // Cantidad de veces que se titilará

        for (int i = 0; i < totalTitilaciones; i++)
        {
            Console.Clear(); // Limpia la consola para mostrar el título en un nuevo estado
            Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.Cyan : ConsoleColor.Black;
            Console.WriteLine(titulo);
            Thread.Sleep(titilarDuracion); // Espera antes de cambiar el estado
        }

        // Restablecer el color de la consola y mostrar el título de forma estática
        
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(titulo);



            Console.ResetColor();
            //Console.WriteLine("\n ----PRESIONE UNA TECLA PARA COMENZAR------");
           // Console.ReadKey();
        }

        public static void MostrarTituloGanadorPerdedor(string ganador)
        {
            // SI GANA
            if (ganador != null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                string tituloGanador = @"
  _______      ___      .__   __.      ___       _______    ______   .______       __  
 /  _____|    /   \     |  \ |  |     /   \     |       \  /  __  \  |   _  \     |  | 
|  |  __     /  ^  \    |   \|  |    /  ^  \    |  .--.  ||  |  |  | |  |_)  |    |  | 
|  | |_ |   /  /_\  \   |  . `  |   /  /_\  \   |  |  |  ||  |  |  | |      /     |  | 
|  |__| |  /  _____  \  |  |\   |  /  _____  \  |  '--'  ||  `--'  | |  |\  \----.|__| 
 \______| /__/     \__\ |__| \__| /__/     \__\ |_______/  \______/  | _| `._____|(__) 


";
                Console.WriteLine(tituloGanador);
                Console.ResetColor();
            }
            else
            {
                // SI NO GANA
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                string tituloPerdedor = @"
.______    _______ .______       _______   __    ______    __  
|   _  \  |   ____||   _  \     |       \ |  |  /  __  \  |  | 
|  |_)  | |  |__   |  |_)  |    |  .--.  ||  | |  |  |  | |  | 
|   ___/  |   __|  |      /     |  |  |  ||  | |  |  |  | |  | 
|  |      |  |____ |  |\  \----.|  '--'  ||  | |  `--'  | |__| 
| _|      |_______|| _| `._____||_______/ |__|  \______/  (__) 

";
                Console.WriteLine(tituloPerdedor);
                Console.ResetColor();
            }
            Console.WriteLine("Iniciando pausa de 5 segundos...");
            Thread.Sleep(5000);  // Pausa de 5 segundos (5000 milisegundos)
            Console.WriteLine("Pausa terminada.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();  // Espera a que el usuario presione una tecla
            Console.WriteLine("Continuando...");
            Console.Clear();
        }

        public static void Salir()
        {
            Console.WriteLine("Abandonando el juego...");
            Environment.Exit(0);
        }
     public static void LimpiarBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }

     public static void ContadorPelea()
        {
          
            for (int i = 3; i > 0; i--)
            {
                Console.Clear();
                Inicio. CentrarTexto("_____________________    .    ______________________");
                Console.WriteLine("");
                Inicio.CentrarTexto("Que el poder se acumule y la magia se despierte. PREPARATE!");
                 Console.WriteLine("");
                 Console.WriteLine("");
                  Console.ForegroundColor = ConsoleColor.DarkYellow;
                Inicio.CentrarTexto($" La batalla comienza en {i}");
                Thread.Sleep(1500);
                 Console.ResetColor();
                
            }

            Console.Clear();
            Inicio. CentrarTexto("_____________________    .    ______________________");
            Console.WriteLine("");
            Inicio.CentrarTexto("Que los hechizos hablen ¡COMIENZA LA BATALLA!");
            Console.WriteLine("");
            Inicio. CentrarTexto("_____________________    .    ______________________");
            Thread.Sleep(1500);
            LimpiarBuffer(); 
        }   
    }
}

