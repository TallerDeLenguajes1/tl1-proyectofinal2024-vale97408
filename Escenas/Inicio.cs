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
        public void InicioJuego()
        {
            // Mostrar la pantalla de inicio
            Titulo.MostrarTituloDelJuego();

            // Solicitar nombre del jugador
            Console.WriteLine("Por favor, ingrese su nombre:");
            string nombreJugador = Console.ReadLine();


            Console.Clear();
            // Dar la bienvenida al jugador y contexto del juego
            CentrarTexto($"\n¡Bienvenido, {nombreJugador}, a ARCANUM: TORNEO DE MAGIA!");
            Thread.Sleep(500);
            CentrarTexto("______________________   .    _____________________");
            Console.WriteLine("");
            Thread.Sleep(500);
            CentrarTexto("     Cada cuatro años, los hechiceros de la ciudad de Eldoria se enfrentan en el Torneo Arcanum, una competencia mágica por el trono del Gran Hechicero. Esta edición es especial: los duelos se llevan a cabo en planetas diversos, cada uno con sus propios desafíos únicos. Desde mundos ardientes hasta frías tierras heladas, los hechiceros deben adaptarse a condiciones cambiantes para demostrar su dominio en la magia.");
            Thread.Sleep(1000);
            CentrarTexto("  ★ ⡀ . • ☆ • . ★  ¿Estás al nivel de este desafío interplanetario?  ★ ⡀ . • ☆ • . ★ ");

            Thread.Sleep(1000);
            Console.Write("\nPresiona cualquier tecla para empezar");
            Console.ReadKey();


            // ------CONTROL DE PERSISTENCIA DE PERSONAJES 

            // Crear instancias necesarias
            FabricaDePersonajes fabrica = new FabricaDePersonajes();
            PersonajesJson persistPerJson = new PersonajesJson();
            HistorialJson persistHistJson = new HistorialJson();

            // Nombre del archivo de personajes
            string nombreArchivoPersonajes = "personajes.json";
            string nombreArchivoGanadores = "ganadores.json";

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
            bool continuar = true;

            while (continuar)
            {
                // REPITE EL MENU HASTA EL JUGADOR DECIDA SALIR 

                string[] opciones = ["Jugar", "Historial de Ganadores", "Info Personajes", "Salir"];

                MenuPrincipal menu = new MenuPrincipal(opciones);
                int opcionElegida = menu.Display();
                switch (opcionElegida)
                {
                    case 0:
                        // JUGAR
                        Console.Clear();
                        int opcionJuego;
                        bool opcionValida = false;
                        while (!opcionValida)
                        {
                            CentrarTexto("¿DESEA JUGAR CON PERSONAJES PRECARGADOS O GENERAR NUEVOS?");
                            Console.WriteLine("1. Jugar con personajes precargados");
                            Console.WriteLine("2. Generar nuevos personajes");
                            Console.WriteLine("- Cualquier otra tecla: Volver al MENU PRINCIPAL");

                            string entrada = Console.ReadLine();
                            if (int.TryParse(entrada, out opcionJuego) && (opcionJuego == 1 || opcionJuego == 2))
                            {
                                opcionValida = true;
                                if (opcionJuego == 1)
                                {
                                    Console.Clear();
                                    Juego(personajes);
                                }
                                else
                                {
                                    if (opcionJuego == 2)
                                    {
                                        personajes.Clear();  // Limpio la lista antes de generar nuevos personajes
                                                             // Genero los 10 personajes (10 por la cantidad de nombres que tengo)
                                        personajes = GenerarPersonajes(fabrica);
                                        persistPerJson.GuardarPersonajes(personajes, nombreArchivoPersonajes);
                                        Console.Clear();
                                        Juego(personajes);
                                    }
                                }

                            }
                            else
                            {
                                break;// Vuelve al menu principal
                            }
                        }
                        break;

                    case 1:
                        // Historial Json
                        if (persistHistJson.Existe(nombreArchivoGanadores))
                        {
                            // Leer los ganadores del archivo
                            //  MostrarGanadores(persistHistJson.LeerGanadores(nombreArchivoGanadores));
                        }
                        else
                        {
                            Console.WriteLine("No hay ganadores registrados.");
                        }
                        //InicioJuego();
                        break;
                    case 2:
                        // Info personajes
                        MostrarPersonajes(personajes);
                        Console.Write("\nPresiona cualquier tecla para volver al MENU PRINCIPAL");
                        Console.ReadKey();
                        //InicioJuego();
                        break;
                    case 3:
                        // salir
                        continuar = false;
                       Titulo.TextoDespedida();
                        //Console.ResetColor();
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
            CentrarTexto($"----------- HECHICEROS PRECARGADOS -----------");
            Console.WriteLine("");
            foreach (var personaje in personajes)
            {
                // Mostrar características del personaje
                CentrarTexto($"----------------HECHICERO {personaje.Datos.Nombre} -------------------");
                CentrarTexto($"Apodo: {personaje.Datos.Apodo}");
                CentrarTexto($"Fecha de Nacimiento: {personaje.Datos.FechaDeNacimiento.ToShortDateString()}");
                CentrarTexto($"Edad: {personaje.Datos.Edad}");
                CentrarTexto($"Tipo: {personaje.Datos.Tipo}");
                Console.WriteLine("");
                CentrarTexto($"------Características------");
                CentrarTexto($"Salud: {personaje.Caracteristicas.Salud}");
                CentrarTexto($"Velocidad: {personaje.Caracteristicas.Velocidad}");
                CentrarTexto($"Destreza: {personaje.Caracteristicas.Destreza}");
                CentrarTexto($"Fuerza: {personaje.Caracteristicas.Fuerza}");
                CentrarTexto($"Nivel: {personaje.Caracteristicas.Nivel}");
                CentrarTexto($"Protección: {personaje.Caracteristicas.Proteccion}");
                CentrarTexto($"-------------------------------------------------------");
                Console.WriteLine();
                Thread.Sleep(1000);
            }
            Console.ResetColor();
        }

        /* public static void CentrarTexto(string texto)
         {
             string[] lineas = texto.Split("\n");
             foreach (var linea in lineas)
             {
                 int padding = (Console.BufferWidth - linea.Length)/2;
                 Console.SetCursorPosition(padding, Console.CursorTop);
                 Console.WriteLine(linea);
             }
         } */
        public static void CentrarTexto(string texto)
        {
            string[] lineas = texto.Split("\n");
            int consoleWidth = Console.BufferWidth;

            foreach (var linea in lineas)
            {
                int padding = (consoleWidth - linea.Length) / 2;

                // Asegúrate de que el padding no sea negativo
                if (padding < 0)
                {
                    padding = 0;
                }

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


        public void Juego(List<Personaje> personajes)
        {
            CentrarTexto("---SELECCIONE UN PERSONAJE---");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("");

            // De la lista de personajes cargada muestro solo 5 aleatorios para que elija el jugador con cual quedarse
            Random random = new Random();
            List<Personaje> personajesAleatorios = personajes.OrderBy(x => random.Next()).Take(5).ToList();
            for (int i = 0; i < personajesAleatorios.Count; i++)
            {
                CentrarTexto($"{i + 1}. HECHICERO {personajesAleatorios[i].Datos.Nombre}");
                CentrarTexto($"-- Tipo: {personajesAleatorios[i].Datos.Tipo}");
                Console.WriteLine("");
                Thread.Sleep(1000);
            }
            Console.ResetColor();

            // Controlo que elija un personaje dentro del rango 
            Personaje jugadorElegido = null;
            while (jugadorElegido == null)
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
            CentrarTexto("_____________________    .    ______________________");
            Console.WriteLine("");
            CentrarTexto($"--Elegiste  a: {jugadorElegido.Datos.Nombre}, {jugadorElegido.Datos.Tipo}. Tambien llamado '{jugadorElegido.Datos.Apodo}'");
            Console.WriteLine("");
            CentrarTexto("_____________________    .    ______________________");

            /*CentrarTexto("Caracteristicas");
            Console.Write("");
             CentrarTexto("DESTREZA | FUERZA | VELOCIDAD| PROTECCION|SALUD|NIVEL");
             CentrarTexto($" {jugadorElegido.Caracteristicas.Destreza}| {jugadorElegido.Caracteristicas.Fuerza}| {jugadorElegido.Caracteristicas.Velocidad}|{jugadorElegido.Caracteristicas.Proteccion}| {jugadorElegido.Caracteristicas.Salud}|{jugadorElegido.Caracteristicas.Nivel}");
              Console.ResetColor(); */

            // Define el ancho de cada columna
            int anchoColumna = 15; // Puedes ajustar este valor según el tamaño de tus datos
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            // Imprime el encabezado de la tabla
            Console.WriteLine("");
            CentrarTexto("Características");
            Console.WriteLine("");
            CentrarTexto($"{"DESTREZA".PadRight(anchoColumna)}| {"FUERZA".PadRight(anchoColumna)}| {"VELOCIDAD".PadRight(anchoColumna)}| {"PROTECCIÓN".PadRight(anchoColumna)}| {"SALUD".PadRight(anchoColumna)}| {"NIVEL".PadRight(anchoColumna)}");
            // Imprime los datos del jugador
            CentrarTexto($"{jugadorElegido.Caracteristicas.Destreza.ToString().PadRight(anchoColumna)}| {jugadorElegido.Caracteristicas.Fuerza.ToString().PadRight(anchoColumna)}| {jugadorElegido.Caracteristicas.Velocidad.ToString().PadRight(anchoColumna)}| {jugadorElegido.Caracteristicas.Proteccion.ToString().PadRight(anchoColumna)}| {jugadorElegido.Caracteristicas.Salud.ToString().PadRight(anchoColumna)}| {jugadorElegido.Caracteristicas.Nivel.ToString().PadRight(anchoColumna)}");
            // Restablece el color de la consola
            Console.ResetColor();
            Thread.Sleep(4000);
            Console.Write("\nPresiona cualquier tecla para continuar");
            Console.ReadKey();

            // ANALIZO nivel de dificultad para crear la cantidad de contricantes/ Rondas a jugar
            // Limpio consola y pregunto 
            Console.Clear();
            int dificultad = 0, opcionD = 0;
            CentrarTexto("_____________________    .    ______________________");
            Console.WriteLine("");
            CentrarTexto("SELECCIONE EL NIVEL DE DIFICULTAD");
            Console.WriteLine("");
            CentrarTexto("_____________________    .    ______________________");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentrarTexto("1. FÁCIL"); // 3 enemigos
            Console.WriteLine("");
            CentrarTexto("2. MEDIO"); // 6 enemigos
            Console.WriteLine("");
            CentrarTexto("3. DIFICIL"); // 9 enemigos
            Console.ResetColor();

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
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n OPCION INVALIDA! ELIJA UN NUMERO ENTRE 1 Y 3.\n");
                    Console.ResetColor();
                }
            }

            // UNA VEZ ELEGIDA LA DIFICULTAD EMPIEZA EL JUEGO

            // Segun la dificultad elegida mostrara la cantidad de enemigos a combatir y sus caracteristicas

            List<Personaje> listaEnemigos;
            // Crear una instancia de la clase Combate
            Combate combate = new Combate();
            Personaje ganadorFinal;
            switch (dificultad)
            {
                case 1:// FÁCIL
                    Console.Clear();
                    CentrarTexto("_____________________    .    ______________________");
                    Console.WriteLine("");
                    CentrarTexto("SELECCIONASTE EL NIVEL DE DIFICULTAD [FÁCIL]");
                    CentrarTexto(" 2 ENEMIGOS A DERROTAR");
                    Console.WriteLine("");
                    CentrarTexto("_____________________    .    ______________________");
                    Console.WriteLine("");
                    CentrarTexto("---- CARACTERISTICAS DE SUS ENEMIGOS---- ");
                    Console.WriteLine("");
                    // Uso de funcion que genera, muestra y devuelve la lista con los enemigos generados
                    listaEnemigos = Combate.GenerarEnemigosYMostrar(2, personajes, jugadorElegido);
                    Console.Write("\nPresiona cualquier tecla para CONTINUAR");
                    Console.ReadKey();
                    ganadorFinal = combate.desarrolloCombate(jugadorElegido, listaEnemigos);
                    Console.Write("\nPresiona cualquier tecla para CONTINUAR");
                    Console.ReadKey();

                    Console.Clear();
                    Titulo.MostrarResultadoLetras(jugadorElegido, ganadorFinal);

                    Console.Write("\nPresiona cualquier tecla para REGRESAR AL MENU PRINCIPAL");
                    Console.ReadKey();

                    break;

                case 2:// MEDIO
                    Console.Clear();
                    CentrarTexto("_____________________    .    ______________________");
                    Console.WriteLine("");
                    CentrarTexto("SELECCIONASTE EL NIVEL DE DIFICULTAD [MEDIO]");
                    CentrarTexto(" 4 ENEMIGOS A DERROTAR");
                    Console.WriteLine("");
                    CentrarTexto("_____________________    .    ______________________");
                    Console.WriteLine("");
                    CentrarTexto("---- CARACTERISTICAS DE SUS ENEMIGOS---- ");
                    Console.WriteLine("");
                    // Uso de funcion para mostrar los enemigos generados aleatoriomente en combate 
                    listaEnemigos = Combate.GenerarEnemigosYMostrar(4, personajes, jugadorElegido);
                    Console.Write("\nPresiona cualquier tecla para CONTINUAR");
                    Console.ReadKey();
                    ganadorFinal = combate.desarrolloCombate(jugadorElegido, listaEnemigos);
                    Console.Write("\nPresiona cualquier tecla para CONTINUAR");
                    Console.ReadKey();

                    Console.Clear();
                    Titulo.MostrarResultadoLetras(jugadorElegido, ganadorFinal);

                    Console.Write("\nPresiona cualquier tecla para REGRESAR AL MENU PRINCIPAL");
                    Console.ReadKey();


                    break;
                case 3:// DIFICIL
                    Console.Clear();
                    CentrarTexto("_____________________    .    ______________________");
                    Console.WriteLine("");
                    CentrarTexto("SELECCIONASTE EL NIVEL DE DIFICULTAD [DIFICIL]");
                    CentrarTexto("  6 ENEMIGOS A DERROTAR");
                    Console.WriteLine("");
                    CentrarTexto("_____________________    .    ______________________");
                    CentrarTexto("---- CARACTERISTICAS DE SUS ENEMIGOS---- ");
                    Console.WriteLine("");
                    // Uso de funcion para mostrar los enemigos generados aleatoriomente en combate 
                    listaEnemigos = Combate.GenerarEnemigosYMostrar(6, personajes, jugadorElegido);
                    Console.Write("\nPresiona cualquier tecla para CONTINUAR");
                    Console.ReadKey();
                    // Desarrollo de combate
                    ganadorFinal = combate.desarrolloCombate(jugadorElegido, listaEnemigos);
                    Console.Write("\nPresiona cualquier tecla para CONTINUAR");
                    Console.ReadKey();

                    Console.Clear();
                    Titulo.MostrarResultadoLetras(jugadorElegido, ganadorFinal);

                    Console.Write("\nPresiona cualquier tecla para REGRESAR AL MENU PRINCIPAL");
                    Console.ReadKey();
                    break;
            }

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
