using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Personajes;

namespace Juego
{
    public class PersonajesJson
    {
        // Método para obtener la ruta completa del archivo
        private string ObtenerRuta(string nombreArchivo)
        {
            return Path.Combine("Data", nombreArchivo);
        }

        // Método para guardar una lista de personajes en un archivo JSON
        public void GuardarPersonajes(List<Personaje> listadoDePersonajes, string nombreArchivo)
        {
            string ruta = ObtenerRuta(nombreArchivo);
            // Asegúrate de que la carpeta "Data" exista
            Directory.CreateDirectory(Path.GetDirectoryName(ruta));

            string personajesJson = JsonSerializer.Serialize(listadoDePersonajes, new JsonSerializerOptions { WriteIndented = true });

            try
            {
                using (var archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write))
                {
                    using (var strWriter = new StreamWriter(archivo))
                    {
                        strWriter.Write(personajesJson);
                    }
                }
                Console.WriteLine("Personajes guardados exitosamente en " + ruta);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar los personajes: " + ex.Message);
            }
        }

        // Método para leer una lista de personajes desde un archivo JSON
        public List<Personaje> LeerPersonajes(string nombreArchivo)
        {
            string ruta = ObtenerRuta(nombreArchivo);

            if (!Existe(nombreArchivo))
            {
                Console.WriteLine("El archivo no existe.");
                return new List<Personaje>();
            }

            try
            {
                string cadenaPersonajes;
                using (var archivoOpen = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                {
                    using (var strReader = new StreamReader(archivoOpen))
                    {
                        cadenaPersonajes = strReader.ReadToEnd();
                    }
                }
                var listadoPersonajes = JsonSerializer.Deserialize<List<Personaje>>(cadenaPersonajes);
                return listadoPersonajes ?? new List<Personaje>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer los personajes: " + ex.Message);
                return new List<Personaje>();
            }
        }

        // Método para verificar si un archivo existe y tiene datos
        public bool Existe(string nombreArchivo)
        {
            string ruta = ObtenerRuta(nombreArchivo);
              if(File.Exists(ruta))
            {
                return true;
            }else
            {
                return false;
            }
        }

        
    }
}
