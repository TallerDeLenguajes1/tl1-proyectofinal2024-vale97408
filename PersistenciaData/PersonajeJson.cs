using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Fabrica;
using Personajes;

namespace Proyecto
{
    public class PersonajesJson
    {
        // Método para obtener la ruta completa del archivo
        private string ObtenerRuta(string nombreArchivo)
        {
            return "Data/" + nombreArchivo;
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
                using (var archivoOpen = new FileStream(ruta, FileMode.Open))
                {
                    using (var strReader = new StreamReader(archivoOpen))
                    {
                        cadenaPersonajes = strReader.ReadToEnd();
                        archivoOpen.Close();
                    }
                }
                var listadoPersonajes = JsonSerializer.Deserialize<List<Personaje>>(cadenaPersonajes);

                return listadoPersonajes;
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


        //-------------CONTROL DE PERSISTENCIA PERSONAJES

        public static List<Personaje> PersitenciaPersonajes()
        {
            // Crear instancias necesarias
            FabricaDePersonajes fabrica = new FabricaDePersonajes();
            PersonajesJson persistPerJson = new PersonajesJson();
           
            // Nombre del archivo de personajes
            string nombreArchivoPersonajes = "personajes.json";
          
            List<Personaje> personajes; // Lista  generada de la FABRICA DE PERSONAJES

            // Verificar si el archivo de personajes existe
            if (persistPerJson.Existe(nombreArchivoPersonajes))
            {
                // Leer los personajes del archivo
                personajes = persistPerJson.LeerPersonajes(nombreArchivoPersonajes);

                if (personajes.Count > 0)
                {
                    Console.WriteLine("Personajes cargados exitosamente:");
                }
                else
                {
                    Console.WriteLine("El archivo de personajes está vacío. Generando nuevos personajes.");
                    personajes = GenerarPersonajes(fabrica);
                    persistPerJson.GuardarPersonajes(personajes, nombreArchivoPersonajes);
                }
            }
            else
            { // SI NO EXISTE EL ARCHIVO DE PERSONAJES
                Console.WriteLine("Archivo de personajes no encontrado. Generando nuevos personajes.");

                // genero los 10 personajes (10 por la cantidad de nombres que tengo )
                personajes = GenerarPersonajes(fabrica);
                persistPerJson.GuardarPersonajes(personajes, nombreArchivoPersonajes);
            }
            return personajes;

        }

        public static List<Personaje> GenerarPersonajes(FabricaDePersonajes fabrica)
        {
            var nombres = new List<string>
            {
                "Aegis", "Bran", "Eldric", "Darius",  "Fenwick","Fionn", "Gwen", "Thorne", "Ivar", "Jasper"
            };

            return fabrica.GeneradorDePersonajes(nombres);
        }

        
    }
}
