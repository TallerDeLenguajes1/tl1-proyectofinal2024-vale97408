using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Personajes;

namespace Juego
{
    public class PersonajesJson
    {
        private string ObtenerRuta(string nombreArchivo)
        {
            return Path.Combine("Data", nombreArchivo);
        }

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

        public bool Existe(string nombreArchivo)
        {
            string ruta = ObtenerRuta(nombreArchivo);
            return File.Exists(ruta);
        }

        // // Método para eliminar un archivo
        // public void EliminarArchivo(string nombreArchivo)
        // {
        //     string ruta = ObtenerRuta(nombreArchivo);

        //     if (File.Exists(ruta))
        //     {
        //         try
        //         {
        //             File.Delete(ruta);
        //             Console.WriteLine("Archivo eliminado exitosamente: " + ruta);
        //         }
        //         catch (Exception ex)
        //         {
        //             Console.WriteLine("Error al eliminar el archivo: " + ex.Message);
        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine("El archivo no existe.");
        //     }
        // }
    }
}
