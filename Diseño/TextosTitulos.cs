using System;
using System.Threading;
using Fabrica;
using Personajes;

namespace Proyecto
{
  public class Titulo
  {
    public static void TextoBienvenida(string nombreJugador)
    {
      Inicio.CentrarTexto($"\n¡Bienvenido, {nombreJugador}, a ARCANUM: TORNEO DE MAGIA!");
      Thread.Sleep(500);
      Inicio.CentrarTexto("______________________   .    _____________________");
      Console.WriteLine("");
      Thread.Sleep(500);

      Inicio.CentrarTexto(" Cada cuatro años, los hechiceros de la ciudad de Eldoria se enfrentan en el Torneo Arcanum, una competencia mágica por el trono del Gran Hechicero. ");
      Thread.Sleep(300);
      Inicio.CentrarTexto("Esta edición es especial: los duelos se llevan a cabo en planetas diversos, cada uno con sus propios desafíos únicos. Desde mundos ardientes hasta frías tierras heladas, los hechiceros deben adaptarse a condiciones cambiantes para demostrar su dominio en la magia.");
      Thread.Sleep(1000);
      Inicio.CentrarTexto("");
      Thread.Sleep(300);
      Inicio.CentrarTexto("  ★ ⡀ . • ☆ • . ★  ¿Estás al nivel de este desafío interplanetario?  ★ ⡀ . • ☆ • . ★ ");

      Thread.Sleep(1000);
      MostrarTextoProgresivo("\nPRESIONA CUALQUIER TECLA PARA COMENZAR.", 10);
      //Console.Write("\nPresiona cualquier tecla para empezar");
      Console.ReadKey();
    }

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

    }

    public static void TituloGanador()
    {

      Console.ForegroundColor = ConsoleColor.Cyan;
      string tituloGanador = @"

 •   ☆   ★ ⡀   .  •  ☆  •  .  ★   ★  ⡀  .  •  ☆   •  .   ★  .  ★  ⡀  .  •   ☆  •  .     ★     ★ ⡀  •   ☆  

       _______      ___      .__   __.      ___           _______..___________. _______  __  
      /  _____|    /   \     |  \ |  |     /   \         /       ||           ||   ____||  | 
     |  |  __     /  ^  \    |   \|  |    /  ^  \       |   (----``---|  |----`|  |__   |  | 
     |  | |_ |   /  /_\  \   |  . `  |   /  /_\  \       \   \        |  |     |   __|  |  | 
     |  |__| |  /  _____  \  |  |\   |  /  _____  \  .----)   |       |  |     |  |____ |__| 
      \______|  /__/     \__\ |__| \__| /__/     \__\ |_______/       |__|     |_______|(__)   
    
";
      Inicio.CentrarTexto(tituloGanador);
      Thread.Sleep(2000);

      string textoTrono = @"
  _____   _                                   _     _____                                 _         _ 
 |_   _| (_)  ___   _ _    ___   ___    ___  | |   |_   _|  _ _   ___   _ _    ___     __| |  ___  | |
   | |   | | / -_) | ' \  / -_) (_-<   / -_) | |     | |   | '_| / _ \ | ' \  / _ \   / _` | / -_) | |
   |_|   |_| \___| |_||_| \___| /__/   \___| |_|     |_|   |_|   \___/ |_||_| \___/   \__,_| \___| |_|
                                                                                                          
            ";
      Inicio.CentrarTexto(textoTrono);
      Thread.Sleep(1000);

      string textoTrono2 = @"
   ___   ___     _     _  _     _  _   ___    ___   _  _   ___    ___   ___   ___    ___  
  / __| | _ \   /_\   | \| |   | || | | __|  / __| | || | |_ _|  / __| | __| | _ \  / _ \ 
 | (_ | |   /  / _ \  | .` |   | __ | | _|  | (__  | __ |  | |  | (__  | _|  |   / | (_) |
  \___| |_|_\ /_/ \_\ |_|\_|   |_||_| |___|  \___| |_||_| |___|  \___| |___| |_|_\  \___/ 

 •   ☆   ★ ⡀   .  •  ☆  •  .  ★   ★  ⡀  .  •  ☆   •  .   ★  .  ★  ⡀  .  •   ☆  •  .     ★     ★ ⡀  •   ☆  
                ";
      Inicio.CentrarTexto(textoTrono2);
      Thread.Sleep(1000);
      // TRABAJO EFECTO DE TITILEO
      int titilarDuracion = 700; // Tiempo en milisegundos para titilar
      int totalTitilaciones = 10; // Cantidad de veces que se titilará

      for (int i = 0; i < totalTitilaciones; i++)
      {
        Console.Clear(); // Limpia la consola para mostrar el título en un nuevo estado
        Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.Cyan : ConsoleColor.Gray;
        Inicio.CentrarTexto(tituloGanador);
        Inicio.CentrarTexto(textoTrono);
        Inicio.CentrarTexto(textoTrono2);
        Thread.Sleep(titilarDuracion); // Espera antes de cambiar el estado
      }

      // Restablecer el color de la consola y mostrar el título de forma estática

      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Cyan;
      Inicio.CentrarTexto(tituloGanador);
      Inicio.CentrarTexto(textoTrono);
      Inicio.CentrarTexto(textoTrono2);


      Console.ResetColor();

    }
    public static void TituloPerdedor()
    {
      Console.ForegroundColor = ConsoleColor.Red;
      string tituloPerdedor = @"
 •   ☆   ★ ⡀   .  •  ☆  •  .  ★   ★  ⡀  .  •  ☆   •  .   ★  .  ★  ⡀  .  •   ☆  •  .     ★     ★ ⡀  •   ☆ 
 
.______    _______ .______       _______   __       _______..___________. _______  __  
|   _  \  |   ____||   _  \     |       \ |  |     /       ||           ||   ____||  | 
|  |_)  | |  |__   |  |_)  |    |  .--.  ||  |    |   (----``---|  |----`|  |__   |  | 
|   ___/  |   __|  |      /     |  |  |  ||  |     \   \        |  |     |   __|  |  | 
|  |      |  |____ |  |\  \----.|  '--'  ||  | .----)   |       |  |     |  |____ |__| 
| _|      |_______|| _| `._____||_______/ |__| |_______/        |__|     |_______|(__) 
                                                                                       
 •   ☆   ★ ⡀   .  •  ☆  •  .  ★   ★  ⡀  .  •  ☆   •  .   ★  .  ★  ⡀  .  •   ☆  •  .     ★     ★ ⡀  •   ☆ 
";
      Inicio.CentrarTexto(tituloPerdedor);
      Thread.Sleep(1000);

      // TRABAJO EFECTO DE TITILEO
      int titilarDuracion = 400; // Tiempo en milisegundos para titilar
      int totalTitilaciones = 10; // Cantidad de veces que se titilará

      for (int i = 0; i < totalTitilaciones; i++)
      {
        Console.Clear(); // Limpia la consola para mostrar el título en un nuevo estado
        Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.Gray : ConsoleColor.Gray;
        Inicio.CentrarTexto(tituloPerdedor);

        Thread.Sleep(titilarDuracion); // Espera antes de cambiar el estado
      }

      // Restablecer el color de la consola y mostrar el título de forma estática

      Console.Clear();
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Inicio.CentrarTexto(tituloPerdedor);
      Console.ResetColor();

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
        Console.WriteLine("");
        Inicio.CentrarTexto("_____________________    .    ______________________");
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
      Inicio.CentrarTexto("_____________________    .    ______________________");
      Console.WriteLine("");
      Inicio.CentrarTexto("QUE LOS HECHIZOS HABLEN ¡COMIENZA LA BATALLA!");
      Console.WriteLine("");
      Inicio.CentrarTexto("_____________________    .    ______________________");
      Thread.Sleep(1500);
      LimpiarBuffer();
    }

    public static void MostrarResultadoLetras(Personaje jugador, Personaje ganador)
    {
      //Console.WriteLine($"Nombre del Jugador: {jugador.Datos.Nombre}");
      //Console.WriteLine($"Nombre del Ganador: {ganador.Datos.Nombre}");
      Console.Clear();
      if (jugador.Datos.Nombre == ganador.Datos.Nombre)
      {
        TituloGanador();
      }
      else
      {
        TituloPerdedor();
      }
      Thread.Sleep(2000);
    }

    public static void TextoDespedida()
    {
      Console.Clear();
      Inicio.CentrarTexto("_____________________       .        _________________________");
      Console.WriteLine("");

      Inicio.CentrarTexto("  ★ ¸ . • ☆ • . ¸ ★    Te despedimos con gratitud por haber sido parte del Torneo Arcanum. ¡Que tus futuros caminos estén llenos de magia y éxito!     ★ ¸ . • ☆ • . ¸ ★ ");
      Console.WriteLine("");
      Inicio.CentrarTexto("_____________________       .        _________________________");
      Thread.Sleep(2000);

      Console.ForegroundColor = ConsoleColor.Cyan;
      Inicio.CentrarTexto(" •   ☆   ★ ⡀   .  •  ☆  •  .  ★   ★  ⡀  .  •  ☆   •  .   ★  .  ★  ⡀  .  •   ☆  •  .     ★     ★ ⡀  •   ☆  •   ☆   ★ ⡀   .  •  ☆ ");
      string dibujoMago = @"
                    $
                   $$$                         *                                                                                            *
                  $$$$$                      * * *                         _  _               _                _                          * * * 
                 $$$$$$$                       *                          | || |  __ _   ___ | |_             | |  __ _                     * 
                $$$$$$$$$                                                 | __ | / _` | (_-< |  _| / _` |     | | / _` |
               $$$$$$$$$$$                                                |_||_| \__,_| /__/  \__| \__,_|     |_| \__,_| 
              $$$$$$$$$$$$$
             $$$$$$$$$$$$$$$  
            $$$$$$$$$$$$$$$$$                   *                                                  _                  _                                  *
           $$$$$$$$$$$$$$$$$$$                * * *                       _ __   _ _   ___  __ __ (_)  _ __    __ _  | |                               * * *
         $$$$$$$$$$$$$$$$$$$$$$$                *                        | '_ \ | '_| / _ \ \ \ / | | | '  \  / _` | |_|                                 *
        $                       $                                        | .__/ |_|   \___/ /_\_\ |_| |_|_|_| \__,_| (_)
       $_________________________$                                       |_|                                        
       $                          $
$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
     $$$$$$__$$___________$$__$$$$$
    $$$$$___$$$$_________$$$$__$$$$_ $_$_$_$_$_$                                                         *                                             *
    $$$$$____$$___________$$____$$$_ $$$$$$$$$$                              *                         * * *                                         * * *
     $$$$_______________________$$$ _$_$__$__$                             * * *                         *                                         * * * * *
      $$$$____$$______$$______$$$__  $_$_$__$                            * * * * *                                                               * * * * * * *  
          $$$____$$$$$$$_____$$______$_$$_$                                * * *                                        *                          * * * * *   
             $$$___________$$$_______$$$$                                    *                                        * * *                          * * *
            $$$$$$$$$$$$$$$$$$______$$$$                                                        *                       *                              *
          $$$$$$$$$$$$$$$$$$$$$$$___$$$              *                                        * * *
        $$$$$$$$$$$$$$$$$$$$$$$$$$$$$              * * *                                    * * * * *
       $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$                *                                    * * * * * * *                 
       $$$$$$$$$$$$$$$$$$$$$$ $$  $$$                                                       * * * * *   
       $   $$$$$$$$$$$$$$$$$$   $$$$                                                          * * *                                            *
        $$  $$$$$$$$$$$$$$$$$$   $$                                    *                        *                                            * * *
         $$$$$$$$$$$$$$$$$$$$$   $$                                  * * *                                           *                         *
           $$$$$$$$$$$$$$$$$$$   $$                                    *                                           * * * 
           $$$$$$$$$$$$$$$$$$$  $$                                                                               * * * * *
            $$$$$$$$$$$$$$$$$$$_$$                                                                                 * * *
            $$$___$$$$$___$$$__$$                                                                                    *
               $$$     $$$    $$
";
      Console.WriteLine(dibujoMago);
      Inicio.CentrarTexto(" •   ☆   ★ ⡀   .  •  ☆  •  .  ★   ★  ⡀  .  •  ☆   •  .   ★  .  ★  ⡀  .  •   ☆  •  .     ★     ★ ⡀  •   ☆ •   ☆   ★ ⡀   .  •  ☆  ");
      Thread.Sleep(3000);
      // Efecto para titilar
      int titilarDuracion = 700; // Tiempo en milisegundos para titilar
      int totalTitilaciones = 10; // Cantidad de veces que se titilará

      for (int i = 0; i < totalTitilaciones; i++)
      {
        Console.Clear(); // Limpia la consola para mostrar el título en un nuevo estado
        Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.Cyan : ConsoleColor.Black;
        Console.WriteLine(dibujoMago);
        Thread.Sleep(titilarDuracion); // Espera antes de cambiar el estado
      }

      // Restablecer el color de la consola y mostrar el título de forma estática
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine(dibujoMago);
      Console.ResetColor();
    }

    public static void PresionaParaContinuar()
    {
      MostrarTextoProgresivo("\nPRESIONE CUALQUIER TECLA PARA CONTINUAR.", 10);
      //Console.Write("\nPRESIONE CUALQUIER TECLA PARA CONTINUAR.");
      Console.ReadKey();
    }
    public static void PresionaParaMenuPrincipal()
    {
      //Console.Write("\nPresiona cualquier tecla para REGRESAR AL MENU PRINCIPAL");
      MostrarTextoProgresivo("\nPresiona cualquier tecla para REGRESAR AL MENU PRINCIPAL", 10);
      Console.ReadKey();
    }

    public static void MensajeMejoraPersonaje()
    {
      Console.Clear();
      Console.WriteLine("");
      Console.WriteLine("");
      Console.WriteLine("");
      Inicio.CentrarTexto("✬  ✬  ✬  ✬  ✬  ✬   ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬");
      Console.WriteLine("");
      Inicio.CentrarTexto("TU MAGIA HA EVOLUCIONADO. ¡Estás preparado para enfrentarte a tu próximo oponente con habilidades mejoradas!");
      Console.WriteLine("");
      Inicio.CentrarTexto("✬  ✬  ✬  ✬  ✬  ✬   ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬  ✬");
      Console.WriteLine("");
      Console.WriteLine("");
    }

    public static void EncabezadoArriba()
    {
      Inicio.CentrarTexto("_____________________    .    ______________________");
      Console.WriteLine("");
    }
    public static void EncabezadoAbajo()
    {
      Console.WriteLine("");
      Inicio.CentrarTexto("_____________________    .    ______________________");
    }

    public static void MostrarTextoProgresivo(string texto, int retraso = 50)
    {
      // Obtén el tamaño de la consola
      int anchoConsola = Console.WindowWidth;

      // Alinea el texto en el centro de la consola
      int espacioIzquierda = (anchoConsola - texto.Length) / 2;

      // Configura la posición del cursor
      Console.SetCursorPosition(espacioIzquierda, Console.CursorTop);

      // Muestra el texto caracter por caracter
      foreach (char c in texto)
      {
        Console.Write(c);
        Thread.Sleep(retraso); // Retraso en milisegundos
      }

      // Mueve el cursor a la siguiente línea después de terminar
      Console.WriteLine();
    }


  }
}

