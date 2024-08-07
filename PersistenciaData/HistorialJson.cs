using System.ComponentModel;
using System.Text.Json;
using Personajes;
using Proyecto;

namespace Juego
{
    public class HistorialJson
    {
        // Datos de los ganadores 
        // Método para obtener la ruta completa del archivo
        private string obtenerRuta(string nombreArchivo)
        {
            return "Data/" + nombreArchivo;
        }


        // Método para verificar si un archivo existe y tiene datos
        public bool Existe(string nombreArchivo)
        {
            string ruta = obtenerRuta(nombreArchivo);

            return File.Exists(ruta) && new FileInfo(ruta).Length > 0;
        }

        // Método para guardar la información de los ganadores en un archivo JSON
        public void GuardarGanador(Personaje ganador, string nombreArchivo, string nombreJugador, int dificultad)
        {
            string ruta = obtenerRuta(nombreArchivo);
            // Asegúrate de que la carpeta "Data" donde se guardara el archivo Json exista 
            Directory.CreateDirectory(Path.GetDirectoryName(ruta));

            InfoGanadores infoGanador = new InfoGanadores(ganador, nombreJugador, dificultad);

            // Mi lista de ganadores
            List<InfoGanadores> historialGanadores = new List<InfoGanadores>();

            if (Existe(nombreArchivo))
            {
                // Si existe, leo el archivo de los ganadores que ya tenia almacenados 
                historialGanadores = LeerGanadores(nombreArchivo);
            }
            // Agrego el ganador a mi lista de ganadores (ya sea la que ya tenia o si estba vacia)
            historialGanadores.Add(infoGanador);

            // Guardo la lista de ganadores en el archivo Json, serializo, muestro mensajes de si se guardo o no
            string historialG = JsonSerializer.Serialize(historialGanadores);

            try
            {
                using (var archivo = new FileStream(ruta, FileMode.OpenOrCreate))
                {
                    using (var strWriter = new StreamWriter(archivo))
                    {
                        strWriter.WriteLine("{0}", historialG);
                        strWriter.Close();
                    }
                }
               // Console.WriteLine("Ganador y detalles de la partida guardados exitosamente en " + ruta);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el ganador: " + ex.Message);
            }
        }

        // Método para leer la información de los ganadores desde un archivo JSON
        public List<InfoGanadores> LeerGanadores(string nombreArchivo)
        {
            string ruta = obtenerRuta(nombreArchivo);

            if (!Existe(nombreArchivo))
            {
                Console.WriteLine("El archivo no existe.");
                return null;
            }

            // Control para corroborar que si fue leido
            try
            {
                string textoGanadores;
                List<InfoGanadores> historialGanadores;

                using (var archivoOpen = new FileStream(ruta, FileMode.Open))
                {
                    using (var strReader = new StreamReader(archivoOpen))
                    {
                        textoGanadores = strReader.ReadToEnd();
                        archivoOpen.Close();
                    }
                }

                historialGanadores = JsonSerializer.Deserialize<List<InfoGanadores>>(textoGanadores);

                return historialGanadores;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el ganador: " + ex.Message);
                return null;
            }
        }

        // FUNCION para Guardar al ganador en el listado de ganadores
        public  void  AgregoGanador(Personaje ganador, string archivoGanadoresJson, string nombreJugador, int dificultad)
        {
            HistorialJson archivoGanadores = new HistorialJson();
            archivoGanadores.GuardarGanador(ganador, archivoGanadoresJson, nombreJugador, dificultad);
        }

        // FUNCION para mostrar el listado de ganadores
        public  void MostrarListadoGanadores(string nombreArchivo)
        {
            Console.Clear();
            List<InfoGanadores> ganadores = LeerGanadores(nombreArchivo);

            if (ganadores == null || ganadores.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No hay ganadores para mostrar.");
                Console.ResetColor();
                return;
            }

            // Si hay ganadores los muestro  
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Inicio.CentrarTexto("LISTADO DE GANADORES");
            Console.ResetColor();
            Inicio.CentrarTexto("________________________________________________");
            Console.WriteLine("");
            int i = 1;
            foreach (var ganador in ganadores)
            {
               string dificultadTexto="DESCONOCIDA";
                switch (ganador.Dificultad)
              {
                case 1:
                dificultadTexto = "FACIL";
                break;
                case 2:
                dificultadTexto = "MEDIO";
                break;
                case 3:
                dificultadTexto = "DIFICIL";
                break;
                default:
                dificultadTexto="DESCONOCIDA";
                break;
                
               }

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Inicio.CentrarTexto($" {i}- HECHICERO GANADOR");
                Console.WriteLine("");
                Inicio.CentrarTexto($"Nombre del Jugador: {ganador.NombreJugador}");
                Inicio.CentrarTexto($"Nombre del Personaje: {ganador.NombrePersonaje}");
                Inicio.CentrarTexto($"Tipo: {ganador.Tipo}");
                Inicio.CentrarTexto($"Apodo: {ganador.Apodo}");
                Inicio.CentrarTexto($"Salud: {ganador.Salud}");
                Inicio.CentrarTexto($"Dificultad: {dificultadTexto}");
                Inicio.CentrarTexto("");
                Console.ResetColor();
                Inicio.CentrarTexto("________________ . _________________");
                Console.WriteLine("");
                Thread.Sleep(1000);
                i++;
            }
        }

    }

    // Como trabajo con lo mismo, hago la clase con los datos aca 
    public class InfoGanadores
    {
        private string nombreJugador;
        private string nombrePersonaje;
        private TipoPersonaje tipo;

        private string apodo;
        private int salud;
        private int dificultad;
        //private int ataquesRealizados;
        //private int mejorAtaque;


        public string NombreJugador { get => nombreJugador; set => nombreJugador = value; }
        public string NombrePersonaje { get => nombrePersonaje; set => nombrePersonaje = value; }
        public TipoPersonaje Tipo { get => tipo; set => tipo = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Dificultad { get => dificultad; set => dificultad = value; }

         // Constructor predeterminado
        public InfoGanadores()
         {
           }


        public InfoGanadores(Personaje ganador, string nombreJugador, int dificultad)
        {
            NombreJugador = nombreJugador;
            NombrePersonaje = ganador.Datos.Nombre;
            Tipo = ganador.Datos.Tipo;
            Apodo =ganador.Datos.Apodo;
            Salud = ganador.Caracteristicas.Salud;
            Dificultad = dificultad;
        }

        public InfoGanadores(string nombreJugador, string nombrePersonaje, TipoPersonaje tipo, string apodo, int salud, int dificultad)
        {
            this.nombreJugador = nombreJugador;
            this.nombrePersonaje = nombrePersonaje;
            this.tipo = tipo;
            this.apodo =apodo; 
            this.salud = salud;
            this.dificultad = dificultad;
        }
    }
}
