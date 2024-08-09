using Fabrica;
using Personajes;

namespace Proyecto
{
    public class Juego
    {
        public static void ComenzarJuego(List<Personaje> personajes, string NombreJugador)
        {
            Inicio.CentrarTexto("---SELECCIONE UN PERSONAJE---");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("");

            // De la lista de personajes cargada muestro solo 5 aleatorios para que elija el jugador con cual quedarse
            Random random = new Random();
            List<Personaje> personajesAleatorios = personajes.OrderBy(x => random.Next()).Take(5).ToList();
            for (int i = 0; i < personajesAleatorios.Count; i++)
            {
                Inicio.CentrarTexto($"{i + 1}. HECHICERO {personajesAleatorios[i].Datos.Nombre}");
                Inicio.CentrarTexto($"-- Tipo: {personajesAleatorios[i].Datos.Tipo}");
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
            InicioExtras.TablaCaracteristicasPersonajeElegido(jugadorElegido);
            Titulo.PresionaParaContinuar();


            // ANALIZO nivel de dificultad para crear la cantidad de contricantes/ Rondas a jugar
            Console.Clear();
            int dificultad = 0, opcionD = 0;

            Inicio.CentrarTexto("_____________________    .    ______________________");
            Console.WriteLine("");
            Inicio.CentrarTexto("SELECCIONE EL NIVEL DE DIFICULTAD");
            Console.WriteLine("");
            Inicio.CentrarTexto("_____________________    .    ______________________");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Inicio.CentrarTexto("1. FÁCIL"); // 3 enemigos
            Console.WriteLine("");
            Inicio.CentrarTexto("2. MEDIO"); // 6 enemigos
            Console.WriteLine("");
            Inicio.CentrarTexto("3. DIFICIL"); // 9 enemigos
            Console.ResetColor();

            // Guardo la respuesta en una variable y controlo que esa respuesta  este dentro del rango dado
            while (dificultad < 1 || dificultad > 3)
            {
                if (int.TryParse(Console.ReadLine(), out opcionD) && opcionD >= 1 && opcionD <= 3)
                {
                    // -------Implemento SONIDO 
                    Sonido.DetenerSonidoLargo(Sonido.SonidoInicio);
                    Sonido.ReproducirSonido(Sonido.EleccionRealizada);

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
            // Segun la dificultad elegida mostrara la cantidad de enemigos a combatir, caracteristicas, se desarrollara el combate. Si el jugador gana, ese ganador se guardara en el json , mostrara un mensaje y volvera al menu principal
            switch (dificultad)
            {
                case 1:// FÁCIL

                    InicioExtras.DesarrolloDificultad(2, "FACIL", jugadorElegido, personajes, NombreJugador, dificultad);
                    break;

                case 2:// MEDIO
                    InicioExtras.DesarrolloDificultad(4, "MEDIO", jugadorElegido, personajes, NombreJugador, dificultad);

                    break;
                case 3:// DIFICIL
                    InicioExtras.DesarrolloDificultad(6, "DIFICIL", jugadorElegido, personajes, NombreJugador, dificultad);
                    break;
            }
            Console.Clear();
        }
    }
}