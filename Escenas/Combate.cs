using Personajes;

namespace Proyecto
{
    public class CombateDesarrollo
    {
        
        // Funcion que recibe el jugador elegido y la lista de enemigos para trabajar la pelea con las rondas, maneja el control de toda la partida
        public static Personaje DesarrolloCombate(Personaje jugadorElegido, List<Personaje> listaEnemigos)
        {
            // La cantidad de rondas seran de acuerdo a la cantidad de enemigos que tenga a vencer de la lista enemigos
            int cantidadRondas = listaEnemigos.Count;
            Personaje ganador = jugadorElegido; // Por defecto , se modificara si pierde

            // Cada vez que le gane a un competidor pasara de ronda(peleara con el otro personaje de los que queden en la lista, no con el mismo ) y sus caracteristicas mejoraran.
            int i = 0;
            foreach (var enemigo in listaEnemigos)
            // Iterar a través de cada enemigo en la lista
            {
                i++;
                Console.Clear();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Inicio.CentrarTexto($"RONDA NRO {i}/ {cantidadRondas}");
                Console.ResetColor();
                Console.WriteLine("");
                 Titulo.EncabezadoArriba();
                Inicio.CentrarTexto($"--- {jugadorElegido.Datos.Nombre}         VS         {enemigo.Datos.Nombre} ---");
                
               Titulo.EncabezadoArriba();
                Console.WriteLine("");
                 Console.ForegroundColor = ConsoleColor.Blue;
                Inicio.CentrarTexto("CARACTERISTICAS DE PERSONAJES A COMPETIR ");
                Console.ResetColor();
                Console.WriteLine("");
                Combate.MostrarComparacionPersonajes(jugadorElegido, enemigo);
                Thread.Sleep(7000);

                // Uso funcion de copiar personaje
                Personaje jugadorSinModificaciones = DiseñoCombate.CopiarPersonaje(jugadorElegido);
                Personaje enemigoSinModificaciones = DiseñoCombate.CopiarPersonaje(enemigo);

                // Limpio consola 
                Console.Clear();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Inicio.CentrarTexto($"RONDA NRO {i}/ {cantidadRondas}");
                Console.ResetColor();
                Titulo.EncabezadoAbajo();
                Console.WriteLine("");
                Inicio.CentrarTexto($"--- {jugadorElegido.Datos.Nombre}         VS         {enemigo.Datos.Nombre} ---");
                Titulo.EncabezadoAbajo();
                Console.WriteLine("");

                Inicio.CentrarTexto(" Cargando el planeta de combate... ¡Prepárate para descubrir el escenario de tu próximo enfrentamiento!");
                Console.WriteLine("");
                Console.WriteLine("");
                Thread.Sleep(1000);

                // Obtener un planeta aleatorio y mostrar sus características
                Result planeta = Combate.ObtenerYMostrarPlanetaAsync().Result;
                // Muestro el planeta 
                //MostrarCaracteristicasPlaneta(planeta);
                Thread.Sleep(2000);
                Titulo.PresionaParaContinuar();

                Console.Clear();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Inicio.CentrarTexto($"RONDA NRO {i}/ {cantidadRondas}");
                Console.ResetColor();
                Titulo.EncabezadoAbajo();
            
                Console.WriteLine("");
                Inicio.CentrarTexto($"--- {jugadorElegido.Datos.Nombre}         VS         {enemigo.Datos.Nombre} ---");
                Titulo.EncabezadoAbajo();
                Console.WriteLine("");

                // Modificar las características del jugador y el enemigo según el planeta
                Combate.ModificarCaracteristicasPorPlaneta(planeta, jugadorElegido);
                Combate.ModificarCaracteristicasPorPlaneta(planeta, enemigo);

                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Inicio.CentrarTexto("CARACTERISTICAS DE PERSONAJES MODIFICADAS");
                Console.ResetColor();


                DiseñoCombate.MostrarComparacionPersonajesCambios(jugadorSinModificaciones, jugadorElegido, enemigoSinModificaciones, enemigo);
                Console.WriteLine("");
                Thread.Sleep(4000); // Esperar para que el jugador lea el mensaje
                Titulo.PresionaParaContinuar();
                
                //EFECTO CONTADOR DE PELEA
                Console.Clear();
                Titulo.ContadorPelea();
                Thread.Sleep(1000);
                Console.Clear();

                // Realizar el combate entre el jugador y el enemigo
                bool jugadorGano = Combate.RealizarCombate(jugadorElegido, enemigo, cantidadRondas, i);

                if (jugadorGano) // Siempre que haya ganado 
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Personaje jugadorFinRonda = DiseñoCombate.CopiarPersonaje(jugadorElegido);
                    // El jugador gana la ronda, aumenta su nivel
                    jugadorElegido = Combate.AumentarNivel(jugadorElegido);
                    Titulo.EncabezadoArriba();
                    Inicio.CentrarTexto($"{jugadorElegido.Datos.Nombre} ha ganado la ronda!");
                    Titulo.EncabezadoAbajo();
                    Thread.Sleep(2000);

                    if (cantidadRondas != i) //siempre que no sea su ultima ronda
                    {
                        Combate.RestaurarSalud(jugadorElegido); // Se restauara siempre que no sea su ultima ronda jugada
                        Titulo.MensajeMejoraPersonaje();
                        DiseñoCombate.MostrarMejoraPersonaje(jugadorFinRonda, jugadorElegido);
                    }
                    Thread.Sleep(6000); // Esperar para que el jugador lea el mensaje
                    Console.ResetColor();
                }
                else
                {
                    // El jugador pierde la ronda
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"{enemigo.Datos.Nombre} ha ganado la ronda. Fin del combate.");
                    Console.ResetColor();
                    return enemigo; // El enemigo gana y se convierte en el ganador
                }
            }

            // El jugador gana todas las rondas
            Console.WriteLine("");
            Inicio.CentrarTexto($"{jugadorElegido.Datos.Nombre} HA GANADO EL TRONO DEL GRAN HECHICERO!");
            Console.WriteLine("");
            Inicio.CentrarTexto("_____________________    .    ______________________");
            return ganador;
        }
    }

}