using System;
using System.IO;
using System.Media;
using System.Threading;

namespace Proyecto
{
    public class Sonido
    {
        // Rutas de los sonidos        
        public static string SonidoMensajeGanador = @"Sonidos\SonidoMensajeGanador.wav";
        public static string SonidoMensajePerdedor = @"Sonidos\SonidoMensajePerdedor.wav";
        public static string CuentaRegresiva = @"Sonidos\CuentaRegresiva321.wav";
        public static string SonidoAmbientalPelea = @"Sonidos\SonidoAmbientalPelea.wav";
        public static string PasoDeMensaje = @"Sonidos\PasoDeMensaje.wav";
        public static string SonidoInicio = @"Sonidos\MusicaEntrada.wav";
        public static string MejorasRealizadas = @"Sonidos\MejorasRealizadas.wav";
        public static string EleccionRealizada = @"Sonidos\Eleccionrealizada.wav";
        public static string HechiceroDerrotado = @"Sonidos\HechiceroDerrotado.wav";

       
        private static SoundPlayer sonidoLargo = null; // control de sonido largo

        // Método para reproducir música de inicio en bucle
        public static void ReproducirSonidoLargoBucle(string ruta)
        {
            if (File.Exists(ruta))
            {
                SoundPlayer sonido = new SoundPlayer(ruta);
                sonido.PlayLooping(); // Reproduce en bucle
                //Thread.Sleep(9000);
            }
        }

        // Método para detener la música de inicio

        public static void DetenerSonidoLargo(string ruta)
        {
            if (File.Exists(ruta))
            {
                SoundPlayer sonidoLargo = new SoundPlayer(ruta);

                if (sonidoLargo != null)
                {
                    sonidoLargo.Stop();
                    sonidoLargo = null;
                }
            }
        }
        public static void ReproducirSonido(string rutaSonido)
        {
            if (File.Exists(rutaSonido))
            {
                using (SoundPlayer sonido = new SoundPlayer(rutaSonido))
                {
                    sonido.Play(); // Asincrono, el código sigue ejecutándose sin esperar que el sonido termine.
                }
            }
        }
        public static void DetenerSonido(string rutaSonido)
        {
            SoundPlayer musica = new(rutaSonido);

            if (File.Exists(rutaSonido))
            {
                musica.Stop();
                musica = null;
            }

        }
        
    }
}
