using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Personajes;

namespace Juego
{
    public class HistorialJson
    {
        // Método para obtener la ruta completa del archivo
        private string ObtenerRuta(string nombreArchivo)
        {
            return Path.Combine("Data", nombreArchivo);
        }

        // Método para guardar la información de los ganadores en un archivo JSON
        public void GuardarGanador(Personaje ganador, string infoPartida, string nombreArchivo)
        {
            string ruta = ObtenerRuta(nombreArchivo);
            // Asegúrate de que la carpeta "Data" exista
            Directory.CreateDirectory(Path.GetDirectoryName(ruta));

            var datosGanador = new
            {
                Ganador = ganador,
                InfoPartida = infoPartida
            };

            string ganadorJson = JsonSerializer.Serialize(datosGanador, new JsonSerializerOptions { WriteIndented = true });

            try
            {
                using (var archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write))
                {
                    using (var strWriter = new StreamWriter(archivo))
                    {
                        strWriter.Write(ganadorJson);
                    }
                }
                Console.WriteLine("Ganador y detalles de la partida guardados exitosamente en " + ruta);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el ganador: " + ex.Message);
            }
        }

        // Método para leer la información de los ganadores desde un archivo JSON
        public (Personaje Ganador, string InfoPartida) LeerGanadores(string nombreArchivo)
        {
            string ruta = ObtenerRuta(nombreArchivo);

            if (!Existe(nombreArchivo))
            {
                Console.WriteLine("El archivo no existe.");
                return (null, string.Empty);
            }

            try
            {
                string cadenaGanador;
                using (var archivoOpen = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                {
                    using (var strReader = new StreamReader(archivoOpen))
                    {
                        cadenaGanador = strReader.ReadToEnd();
                    }
                }

                var datosGanador = JsonSerializer.Deserialize<dynamic>(cadenaGanador);
                var ganador = JsonSerializer.Deserialize<Personaje>(datosGanador["Ganador"].ToString());
                var infoPartida = datosGanador["InfoPartida"].ToString();

                return (ganador, infoPartida);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el ganador: " + ex.Message);
                return (null, string.Empty);
            }
        }

        // Método para verificar si un archivo existe y tiene datos
        public bool Existe(string nombreArchivo)
        {
            string ruta = ObtenerRuta(nombreArchivo);
            return File.Exists(ruta) && new FileInfo(ruta).Length > 0;
        }
    }
}
