using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Fabrica;
using Juego;
using Personajes;

namespace Proyecto
{
    public class Inicio
    {
        public static void InicioJuego()
        {
            // Mostrar la pantalla de inicio
            Titulo.MostrarTituloDelJuego();

            // Solicitar nombre del jugador
            Console.WriteLine("Por favor, ingrese su nombre:");
            string nombreJugador = Console.ReadLine();


              Console.Clear();
            // Dar la bienvenida al jugador y contexto del juego
            CentrarTexto($"\n¡Bienvenido, {nombreJugador}, a ARCANUM: TORNEO DE MAGIA!");
            Thread.Sleep(1000);
            CentrarTexto("Cada cuatro años, los hechiceros de la ciudad de Eldoria se enfrentan en el Torneo Arcanum, una competencia mágica por el trono del Gran Hechicero. Esta edición es especial: los duelos se llevan a cabo en planetas diversos, cada uno con sus propios desafíos únicos. Desde mundos ardientes hasta frías tierras heladas, los hechiceros deben adaptarse a condiciones cambiantes para demostrar su dominio en la magia.");
            Thread.Sleep(3000);
            CentrarTexto(" ¿Estás al nivel de este desafío interplanetario?");

             Thread.Sleep(3000);
            Console.Write("\nPresiona cualquier tecla para empezar");
            Console.ReadKey();


  // ------CONTROL DE PERSISTENCIA DE PERSONAJES 

            // Crear instancias necesarias
            var fabrica = new FabricaDePersonajes();
            PersonajesJson persistPerJson = new PersonajesJson();
            HistorialJson persistHistJson= new HistorialJson();

            // Nombre del archivo de personajes
            string nombreArchivoPersonajes = "personajes.json";
           string nombreArchivoGanadores= "ganadores.json";

            List<Personaje> personajes; // Lista ya generada de la FABRICA DE PERSONAJES
            

            // Verificar si el archivo de personajes existe
            if (persistHistJson.Existe(nombreArchivoPersonajes))
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

            // Mostrar los datos y características de los personajes cargados
            //MostrarPersonajes(personajes);

            // Mostrar información del planeta
            //await MostrarPlanetas();

        // ------------------MENU DEL JUEGO--------------------
        bool continuar= true; 
        
        while (continuar)
        {
            // REPITE EL MENU HASTA EL JUGADOR DECIDA SALIR 

            string[] opciones= ["Jugar", "Historial de Ganadores",  "Info Personajes", "Salir"];
            MenuPrincipal menu= new MenuPrincipal(opciones);
            int opcionElegida= menu.Display(); 
            switch (opcionElegida)
            {
                case 0: 
                 // JUGAR
                  Console.Clear();
                 personajes.Clear();  // Limpio la lista antes de generar nuevos personajes
                 // Generar personajes
        
                 // genero los 10 personajes (10 por la cantidad de nombres que tengo )
                 personajes = GenerarPersonajes(fabrica);
                 persistPerJson.GuardarPersonajes(personajes, nombreArchivoPersonajes);

                 Juego(personajes);
                  break;
                case 1: 
                 // Historial Json
                 if(persistHistJson.Existe(nombreArchivoGanadores))
                 {
                    // Leer los ganadores del archivo
                  //  MostrarGanadores(persistHistJson.LeerGanadores(nombreArchivoGanadores));
                 } else
                 {
                    Console.WriteLine("No hay ganadores registrados.");
                 }
                 //InicioJuego();
                  break;
                case 2: 
                 // Info personajes
                  MostrarPersonajes(personajes);
                  //InicioJuego();
                  break;
                case 3: 
                 // salir
                 continuar = false;
                CentrarTexto("\n ------¡Hasta la proxima!  ------\n");
                Console.ResetColor();
                  break;
                default: 
                 //Opcion no valida 
                Console.WriteLine("\n OPCION INVALIDA. ELIGE UNA DEL MENU. \n");
               
                  break;
            }

        }


        }



        //------------FUNCIONES UTILIZADAS------------------

        private static List<Personaje> GenerarPersonajes(FabricaDePersonajes fabrica)
        {
            var nombres = new List<string>
            {
                "Aegis", "Bran", "Eldric", "Darius",  "Fenwick","Fionn", "Gwen", "Thorne", "Ivar", "Jasper"
            };

            return fabrica.GeneradorDePersonajes(nombres);
        }

        private static void MostrarPersonajes(List<Personaje> personajes)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"-----------LISTA DE HECHICEROS -----------");
            foreach (var personaje in personajes)
            {
                // Mostrar características del personaje
                Console.WriteLine($"----------------HECHICERO {personaje.Datos.Nombre} -------------------");
                Console.WriteLine($"Apodo: {personaje.Datos.Apodo}");
                Console.WriteLine($"Fecha de Nacimiento: {personaje.Datos.FechaDeNacimiento.ToShortDateString()}");
                Console.WriteLine($"Edad: {personaje.Datos.Edad}");
                Console.WriteLine($"Tipo: {personaje.Datos.Tipo}");
                Console.WriteLine($"------Características------");
                Console.WriteLine($"Salud: {personaje.Caracteristicas.Salud}");
                Console.WriteLine($"Velocidad: {personaje.Caracteristicas.Velocidad}");
                Console.WriteLine($"Destreza: {personaje.Caracteristicas.Destreza}");
                Console.WriteLine($"Fuerza: {personaje.Caracteristicas.Fuerza}");
                Console.WriteLine($"Nivel: {personaje.Caracteristicas.Nivel}");
                Console.WriteLine($"Protección: {personaje.Caracteristicas.Proteccion}");
                Console.WriteLine($"-------------------------------------------------------");
                Console.WriteLine();
            }
            Console.ResetColor();
        }   

        public static void CentrarTexto(string texto)
        {
            string[] lineas = texto.Split("\n");
            foreach (var linea in lineas)
            {
                int padding = (Console.BufferWidth - linea.Length)/2;
                Console.SetCursorPosition(padding, Console.CursorTop);
                Console.WriteLine(linea);
            }
        }

         private static void MostrarGanadores(List<Personaje> personajes)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            CentrarTexto($"-----------LISTA DE HECHICEROS GANADORES -----------");
            foreach (var personaje in personajes)
            {
                // Mostrar características del personaje
                Console.WriteLine($"----------------HECHICERO GANADOR : {personaje.Datos.Nombre} -------------------");
                Console.WriteLine($"Apodo: {personaje.Datos.Apodo}");
                Console.WriteLine($"Tipo: {personaje.Datos.Tipo}");
                Console.WriteLine($"------Características------");
                Console.WriteLine($"Salud: {personaje.Caracteristicas.Salud}");
                Console.WriteLine($"Velocidad: {personaje.Caracteristicas.Velocidad}");
                Console.WriteLine($"Destreza: {personaje.Caracteristicas.Destreza}");
                Console.WriteLine($"Fuerza: {personaje.Caracteristicas.Fuerza}");
                Console.WriteLine($"Nivel: {personaje.Caracteristicas.Nivel}");
                Console.WriteLine($"Protección: {personaje.Caracteristicas.Proteccion}");
                Console.WriteLine($"-------------------------------------------------------");
                Console.WriteLine();
            }
            Console.ResetColor();
        } 

        // Obtener datos de planetas
       /* private static void MostrarPlanetas()
        {
            try
            {
                Planetas planetas = await PlanetasAPI.GetWeatherAsync();
                if (planetas != null && planetas.Results.Count > 0)
                {
                    // Mostrar un planeta aleatorio de la API
                    Random random = new Random();
                    Result planeta = planetas.Results[random.Next(planetas.Results.Count)];

                    Console.WriteLine("\nPlaneta de combate:");
                    Console.WriteLine($"Nombre: {planeta.Name}");
                    Console.WriteLine($"Clima: {planeta.Climate}");
                    Console.WriteLine($"Gravedad: {planeta.Gravity}");
                    Console.WriteLine($"Terreno: {planeta.Terrain}");
                }
                else
                {
                    Console.WriteLine("\nNo se pudieron obtener los datos de los planetas.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los datos del planeta: " + ex.Message);
            }
        }*/

         

        private static void Juego (List<Personaje> personajes)
        {
            CentrarTexto("---SELECCIONE UN PERSONAJE---");
            
            // De la lista de personajes cargada muestro solo 5 aleatorios para que elija el jugador con cual quedarse
            Random random = new Random();
            List<Personaje> personajesAleatorios = personajes.OrderBy(x => random.Next()).Take(5).ToList();
            for (int i = 0; i < personajesAleatorios.Count; i++)
            {
                Console.WriteLine($"{i + 1}. HECHICERO {personajesAleatorios[i].Datos.Nombre}");
                Console.WriteLine($"-- Tipo: {personajesAleatorios[i].Datos.Tipo}");
            }

            // Controlo que elija un personaje dentro del rango 
             Personaje jugadorElegido=null;
             while(jugadorElegido== null)
             {
                if (int.TryParse(Console.ReadLine(), out int opcionPersonaje) && opcionPersonaje >= 1 && opcionPersonaje <= 5)
             {
                jugadorElegido = personajesAleatorios[opcionPersonaje - 1];
             }
             else
             {
                Console.WriteLine("\n OPCION INVALIDA! ELIJA UN NUMERO ENTRE 1 Y 5.\n");   
             }
             }
          // Una vez elegido el jugador limpio la consola para  Mostrar al jugador seleccionado y  sus caracteristicas 
         Console.Clear();
        CentrarTexto($"--Elegiste  a: {jugadorElegido.Datos.Nombre}, {jugadorElegido.Datos.Tipo}. Tambien llamado '{jugadorElegido.Datos.Apodo}'");
         Console.ForegroundColor = ConsoleColor.DarkMagenta;
        CentrarTexto("Caracteristicas");
        Console.WriteLine("DESTREZA | FUERZA | VELOCIDAD| PROTECCION|SALUD|NIVEL");
        Console.WriteLine($" {jugadorElegido.Caracteristicas.Destreza}| {jugadorElegido.Caracteristicas.Fuerza}| {jugadorElegido.Caracteristicas.Velocidad}|{jugadorElegido.Caracteristicas.Proteccion}| {jugadorElegido.Caracteristicas.Salud}|{jugadorElegido.Caracteristicas.Nivel}");
        Console.ResetColor();

        // ANALIZO nivel de dificultad para crear la cantidad de contricantes/ Rondas a jugar
        // Limpio consola y pregunto 
        Console.Clear();
        int dificultad = 0, opcionD=0;
        CentrarTexto("SELECCIONE EL NIVEL DE DIFICULTAD");
        Console.WriteLine("1. FÁCIL"); // 3 enemigos
        Console.WriteLine("2. MEDIO"); // 6 enemigos
        Console.WriteLine("3. DIFICIL"); // 9 enemigos
        // Guardo la respuesta en una variable y controlo que esa respuesta  este dentro del rango dado
        while (dificultad < 1 || dificultad > 3)
        {
            if (int.TryParse(Console.ReadLine(), out opcionD) && opcionD >= 1 && opcionD <= 3)
            {
                // Guardo el valor de dificultad  en la variable dificultad
                dificultad = opcionD;
            }
             else
             {
                Console.WriteLine("\n OPCION INVALIDA! ELIJA UN NUMERO ENTRE 1 Y 3.\n");   
             }
        }

        // UNA VEZ EELEGIDA LA DIFICULTAD EMPIEZA EL JUEGO
         Console.Clear();
        // Segun la dificultad elegida mostrara la cantidad de enemigos a combatir y sus caracteristicas

        List<Personaje> listaEnemigos;
        switch (dificultad)
        {
            case 1:// FÁCIL
            Console.WriteLine("SELECCIONASTE EL NIVEL DE DIFICULTAD [FÁCIL]");
            Console.WriteLine("-- Cantidad de hechiceros a derrotar: 2 enemigos");
            CentrarTexto("---- CARACTERISTICAS DE SUS ENEMIGOS---- ");
            // Uso de funcion que genera, muestra y devuelve la lista con los enemigos generados
            listaEnemigos= Combate.GenerarEnemigosYMostrar(2,personajesAleatorios,jugadorElegido );            


            
            break;

            case 2:// MEDIO
            Console.WriteLine("SELECCIONASTE EL NIVEL DE DIFICULTAD [MEDIO]");
            Console.WriteLine("-- Cantidad de hechiceros a derrotar: 4 ENEMIGOS");
            CentrarTexto("---- CARACTERISTICAS DE SUS ENEMIGOS---- ");
            // Uso de funcion para mostrar los enemigos generados aleatoriomente en combate 
            listaEnemigos= Combate.GenerarEnemigosYMostrar(4,personajesAleatorios,jugadorElegido ); 
            
            
            break;
            case 3:// DIFICIL
            Console.WriteLine("SELECCIONASTE EL NIVEL DE DIFICULTAD [DIFICIL]");
            Console.WriteLine("-- Cantidad de hechiceros a derrotar: 6 ENEMIGOS");
            CentrarTexto("---- CARACTERISTICAS DE SUS ENEMIGOS---- ");
            // Uso de funcion para mostrar los enemigos generados aleatoriomente en combate 
            listaEnemigos= Combate.GenerarEnemigosYMostrar(4,personajesAleatorios,jugadorElegido ); 

            // Desarrollo de combate
            //Combate.desarrolloCombate(jugadorElegido,listaEnemigos); 
            
            
            break;
        }

        // Intro antes de comenzar la batalla 
         Console.Clear();
         Titulo.ContadorPelea();

         // Se disputa la pelea aleatoriamente , trabajo con las funciones de COMBATE


         // De acuerdo a los resultados obtenidos Si es ganador, lo guardo en el archivo de ganadores del Json

         // Vuelvo al menu principal
         Console.Clear();

        }

        // Falta trabajar con la opcion del json del historil de ganadores
        /*private static void MostrarGanadores(HistorialJson persistHistJson, string nombreArchivoGanadores )
        {
             //Leo la lista de gandores desde el archivo Json.
        List<Personaje> ganadoresjson = persistHistJson.LeerGanadores(nombreArchivoGanadores);

        if (ganadoresjson.Count == 0 || ganadoresjson == null)
        {
            Console.WriteLine("\nNo hay ganadores registrados aun.\n");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            CentrarTexto("\n-----HISTORIAL DE GANADORES-------:\n");
            Console.ResetColor();
        
             
            foreach (var ganador in ganadoresjson)
            {
                Console.WriteLine("NOMBRE | TIPO | VELOCIDAD| PROTECCION| DESTREZA | FUERZA ");
                Console.WriteLine($" {ganadoresjson.Datos.Nombre}| {ganadoresjson.Datos.Tipo}| {ganadoresjson.Caracteristicas.Velocidad}|{ganadoresjson.Caracteristicas.Proteccion}| {ganadoresjson.Caracteristicas.Destreza}|{ganadoresjson.Caracteristicas.Fuerza}");
                Console.WriteLine("\n--------------------\n");
            }
          }

        }*/
    }
}
