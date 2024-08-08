using Fabrica;
using Personajes;

namespace Proyecto
{

    public class InicioExtras
    {
        public static void MostrarPersonajes(List<Personaje> personajes)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Inicio.CentrarTexto($"HECHICEROS PRECARGADOS");
            Console.ResetColor();
            Inicio.CentrarTexto("________________________________________________");
            Console.WriteLine("");
            foreach (var personaje in personajes)
            {
                // Mostrar características del personaje
                Console.ForegroundColor = ConsoleColor.Blue;
                Inicio.CentrarTexto($"HECHICERO {personaje.Datos.Nombre}");
                Console.ResetColor();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Blue;
                Inicio.CentrarTexto($"Apodo: {personaje.Datos.Apodo}");
                Inicio.CentrarTexto($"Fecha de Nacimiento: {personaje.Datos.FechaDeNacimiento.ToShortDateString()}");
                Inicio.CentrarTexto($"Edad: {personaje.Datos.Edad}");
                Inicio.CentrarTexto($"Tipo: {personaje.Datos.Tipo}");
                Console.WriteLine("");
                Inicio.CentrarTexto($"  .......Características.......");
                Inicio.CentrarTexto($"Salud: {personaje.Caracteristicas.Salud}");
                Inicio.CentrarTexto($"Velocidad: {personaje.Caracteristicas.Velocidad}");
                Inicio.CentrarTexto($"Destreza: {personaje.Caracteristicas.Destreza}");
                Inicio.CentrarTexto($"Fuerza: {personaje.Caracteristicas.Fuerza}");
                Inicio.CentrarTexto($"Nivel: {personaje.Caracteristicas.Nivel}");
                Inicio.CentrarTexto($"Protección: {personaje.Caracteristicas.Proteccion}");
                Console.ResetColor();
                Inicio.CentrarTexto($"________________ . _________________");
                Console.WriteLine();
                Thread.Sleep(1000);
            }
            Console.ResetColor();
        }

        public static void TablaCaracteristicasPersonajeElegido(Personaje jugadorElegido)
        {
            Console.Clear();
            Inicio.CentrarTexto("_____________________    .    ______________________");
            Console.WriteLine("");
            Inicio.CentrarTexto($"--Elegiste  a: {jugadorElegido.Datos.Nombre}, {jugadorElegido.Datos.Tipo}. Tambien llamado '{jugadorElegido.Datos.Apodo}'");
            Console.WriteLine("");
            Inicio.CentrarTexto("_____________________    .    ______________________");

            // Define el ancho de cada columna
            int anchoColumna = 15; // Puedes ajustar este valor según el tamaño de tus datos
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            // Imprime el encabezado de la tabla
            Console.WriteLine("");
            Inicio.CentrarTexto("Características");
            Console.WriteLine("");
            Inicio.CentrarTexto($"{"DESTREZA".PadRight(anchoColumna)}| {"FUERZA".PadRight(anchoColumna)}| {"VELOCIDAD".PadRight(anchoColumna)}| {"PROTECCIÓN".PadRight(anchoColumna)}| {"SALUD".PadRight(anchoColumna)}| {"NIVEL".PadRight(anchoColumna)}");
            // Imprime los datos del jugador
            Inicio.CentrarTexto($"{jugadorElegido.Caracteristicas.Destreza.ToString().PadRight(anchoColumna)}| {jugadorElegido.Caracteristicas.Fuerza.ToString().PadRight(anchoColumna)}| {jugadorElegido.Caracteristicas.Velocidad.ToString().PadRight(anchoColumna)}| {jugadorElegido.Caracteristicas.Proteccion.ToString().PadRight(anchoColumna)}| {jugadorElegido.Caracteristicas.Salud.ToString().PadRight(anchoColumna)}| {jugadorElegido.Caracteristicas.Nivel.ToString().PadRight(anchoColumna)}");
            // Restablece el color de la consola
            Console.ResetColor();
            Thread.Sleep(4000);
        }

        public static void DesarrolloDificultad(int enemigos, string TextoDificultad, Personaje jugadorElegido, List<Personaje> personajes, string NombreJugador, int dificultad)
        {
            List<Personaje> listaEnemigos;
            // Crear una instancia de la clase Combate
            Combate combate = new Combate();
            Personaje ganadorFinal;
            HistorialJson persistHistJson = new HistorialJson();
            string nombreArchivoGanadores = "historialGanadores.json";

            Console.Clear();
            Inicio.CentrarTexto("_____________________    .    ______________________");
            Console.WriteLine("");
            Inicio.CentrarTexto($"SELECCIONASTE EL NIVEL DE DIFICULTAD [{TextoDificultad}]");
            Inicio.CentrarTexto($" {enemigos} ENEMIGOS A DERROTAR");
            Console.WriteLine("");
            Inicio.CentrarTexto("_____________________    .    ______________________");
            Console.WriteLine("");
            Inicio.CentrarTexto("---- CARACTERISTICAS DE SUS ENEMIGOS---- ");
            Console.WriteLine("");

            // Uso de funcion que genera, muestra y devuelve la lista con los enemigos generados
            listaEnemigos = Combate.GenerarEnemigosYMostrar(enemigos, personajes, jugadorElegido);
            Titulo.PresionaParaContinuar();

            ganadorFinal = CombateDesarrollo.DesarrolloCombate(jugadorElegido, listaEnemigos);

            //-------------- Guardo al ganador en el Json (si es que el jugador gana )
            if (jugadorElegido.Datos.Nombre == ganadorFinal.Datos.Nombre)
            {
                persistHistJson.AgregoGanador(ganadorFinal, nombreArchivoGanadores, NombreJugador, dificultad);
            }

            Titulo.PresionaParaContinuar();
            Console.Clear();
            Titulo.MostrarResultadoLetras(jugadorElegido, ganadorFinal);
            Titulo.PresionaParaMenuPrincipal();
        }


    }
}