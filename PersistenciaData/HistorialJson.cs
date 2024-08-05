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

         // Método para mostrar el historial de ganadores desde archivos JSON en la carpeta "Data"
        /*public static void MostrarHistorialGanadores()
        {
            string carpetaDatos = "Data";
            var archivos = Directory.GetFiles(carpetaDatos, "*.json");

            if (archivos.Length == 0)
            {
                Console.WriteLine("No hay historial de ganadores disponible.");
                return;
            }

            foreach (var archivo in archivos)
            {
                try
                {
                    // Leer y deserializar el archivo JSON
                    string contenidoJson = File.ReadAllText(archivo);
                    var datosGanador = JsonSerializer.Deserialize<JsonElement>(contenidoJson);

                    // Obtener información del ganador
                    var ganador = JsonSerializer.Deserialize<Personaje>(datosGanador.GetProperty("Ganador").GetRawText());
                    var infoPartida = datosGanador.GetProperty("InfoPartida").GetString();

                    // Mostrar la información
                    Console.WriteLine("Nombre del Ganador: " + ganador.Nombre);
                    Console.WriteLine("Tipo de Hechicero: " + ganador.TipoHechicero); // Asegúrate de que esta propiedad exista en la clase Personaje
                    Console.WriteLine("Características:");
                    Console.WriteLine($"  Salud: {ganador.Salud}");
                    Console.WriteLine($"  Destreza: {ganador.Destreza}");
                    Console.WriteLine($"  Fuerza: {ganador.Fuerza}");
                    Console.WriteLine($"  Nivel: {ganador.Nivel}");
                    Console.WriteLine($"  Armadura: {ganador.Armadura}");
                    Console.WriteLine($"  Velocidad: {ganador.Velocidad}");
                    Console.WriteLine("Detalles de la Partida: " + infoPartida);
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al leer el archivo " + archivo + ": " + ex.Message);
                }
            }

            Console.WriteLine("Presione una tecla para regresar al menú.");
            Console.ReadKey();
        } */
    
    }
}
