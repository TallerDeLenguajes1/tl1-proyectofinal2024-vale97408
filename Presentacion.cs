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
";
            Console.WriteLine(titulo);
            Console.ResetColor();
            Console.WriteLine("\nPresione una tecla para continuar");
            Console.ReadKey();
        }
    }
}
