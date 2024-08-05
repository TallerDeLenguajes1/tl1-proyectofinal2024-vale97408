using System;
using System.Threading;

namespace Proyecto
{
    public class Titulo
    {
        public static void MostrarTituloDelJuego()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            string titulo = @"
     ___      .______        ______      ___      .__   __.  __    __  .___  ___. 
    /   \     |   _  \      /      |    /   \     |  \ |  | |  |  |  | |   \/   | 
   /  ^  \    |  |_)  |    |  ,----'   /  ^  \    |   \|  | |  |  |  | |  \  /  | 
  /  /_\  \   |      /     |  |       /  /_\  \   |  . `  | |  |  |  | |  |\/|  | 
 /  _____  \  |  |\  \----.|  `----. /  _____  \  |  |\   | |  `--'  | |  |  |  | 
/__/     \__\ | _| `._____| \______|/__/     \__\ |__| \__|  \______/  |__|  |__|
            
 _____                                   ______        ___  ___               _        
|_   _|                                  |  _  \       |  \/  |              (_)       
  | |    ___   _ __  _ __    ___   ___   | | | |  ___  | .  . |  __ _   __ _  _   __ _ 
  | |   / _ \ | '__|| '_ \  / _ \ / _ \  | | | | / _ \ | |\/| | / _` | / _` || | / _` |
  | |  | (_) || |   | | | ||  __/| (_) | | |/ / |  __/ | |  | || (_| || (_| || || (_| |
  \_/   \___/ |_|   |_| |_| \___| \___/  |___/   \___| \_|  |_/ \__,_| \__, ||_| \__,_|
                                                                        __/ |          
                                                                       |___/
____________________$
___________________$$$
__________________$$$$$
_________________$$$$$$$
________________$$$$$$$$$
_______________$$$$$$$$$$$
______________$$$$$$$$$$$$$
_____________$$$$$$$$$$$$$$$
____________$$$$$$$$$$$$$$$$$
___________$$$$$$$$$$$$$$$$$$$
_________$$$$$$$$$$$$$$$$$$$$$$$
________$_______________________$
_______$_________________________$
_______$_________________________$
$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
_____$$$$$$__$$___________$$__$$$$$
____$$$$$___$$$$_________$$$$__$$$$_$_$_$_$_$_$
____$$$$$____$$___________$$____$$$_$$$$$$$$$$
_____$$$$_______________________$$$_$_$__$__$
_______$$$$____$$______$$______$$$__$_$_$__$
__________$$$____$$$$$$$_____$$______$_$$_$
____________$$$___________$$$________$$$$$
_____________$$$$$$$$$$$$$$$$$$______$$$$
___________$$$$$$$$$$$$$$$$$$$$$$$___$$$
__________$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
_________$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
________$$$$$$$$$$$$$$$$$$$$$$_$$__$$$
________$___$$$$$$$$$$$$$$$$$$___$$$$
________$$__$$$$$$$$$$$$$$$$$$____$$
_________$$$$$$$$$$$$$$$$$$$$$___$$
___________$$$$$$$$$$$$$$$$$$$___$$
___________$$$$$$$$$$$$$$$$$$$__$$
___________$$$$$$$$$$$$$$$$$$$_$$
____________$$$___$$$$$___$$$__$$
_______________$$$_____$$$____$$


 ";
               
            Console.WriteLine(titulo);
            Console.ResetColor();
           // Console.WriteLine("\n ----PRESIONE UNA TECLA PARA COMENZAR------");
            //Console.ReadKey();
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
                Console.WriteLine("Que el poder se acumule y la magia se despierte. PREPARATE!");
                Console.WriteLine($" La batalla comienza en {i}");
                Thread.Sleep(1500);
            }

            Console.Clear();
            Console.WriteLine("Que los hechizo hablen ¡COMIENZA LA BATALLA!");
            LimpiarBuffer(); 
        }
    }

    
}

