using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Personajes;

namespace Proyecto
{
    public class Combatee
    {
        private static Random random = new Random();

        // Método principal de combate
        public static void IniciarCombate(List<Personaje> personajes)
        {
            Console.Clear();
            
            // Seleccionar el planeta
            Result planeta = SeleccionarPlaneta();
            MostrarDetallesPlaneta(planeta);

            // Seleccionar el personaje del jugador
            Personaje jugador = SeleccionarPersonaje(personajes);
            Personaje rival = SeleccionarRival(personajes, jugador);

            // Aplicar efectos del planeta a los personajes
            AplicarEfectosPlaneta(planeta, jugador);
            AplicarEfectosPlaneta(planeta, rival);

            // Comenzar el combate
            bool jugadorGano = RealizarCombate(jugador, rival);

            // Mostrar resultado del combate
            MostrarResultado(jugadorGano);

            // Guardar el ganador en el historial JSON si el jugador ganó
            if (jugadorGano)
            {
                GuardarGanador(jugador);
            }
        }

        private static Result SeleccionarPlaneta()
        {
            Planetas planetas = PlanetasAPI.PlanetaObtenidoDeApi();
            if (planetas != null && planetas.Results.Count > 0)
            {
                return planetas.Results[random.Next(planetas.Results.Count)];
            }
            throw new Exception("No se pudieron obtener los datos de los planetas.");
        }

        private static void MostrarDetallesPlaneta(Result planeta)
        {
            Console.Clear();
            // COLOR A LA INFO DEL PLANETA 
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Inicio.CentrarTexto($"¡La batalla se llevará a cabo en el planeta {planeta.Name}!");
            Console.WriteLine($"Clima: {planeta.Climate}");
            Console.WriteLine($"Terreno: {planeta.Terrain}");
            Console.WriteLine($"Gravedad: {planeta.Gravity}");
            Console.WriteLine();
        }

        private static Personaje SeleccionarPersonaje(List<Personaje> personajes)
        {
            Console.WriteLine("---SELECCIONE SU PERSONAJE---");
            // Muestra los personajes para que el jugador elija
            var personajesAleatorios = personajes.OrderBy(x => random.Next()).Take(5).ToList();
            for (int i = 0; i < personajesAleatorios.Count; i++)
            {
                Console.WriteLine($"{i + 1}. HECHICERO {personajesAleatorios[i].Datos.Nombre}");
                Console.WriteLine($"-- Tipo: {personajesAleatorios[i].Datos.Tipo}");
            }

            // Selección del personaje
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

            Console.Clear();
            Console.WriteLine($"---Elegiste a: {jugadorElegido.Datos.Nombre}, {jugadorElegido.Datos.Tipo}---");
            Console.WriteLine($"DESTREZA | FUERZA | VELOCIDAD| PROTECCION| SALUD | NIVEL");
            Console.WriteLine($" {jugadorElegido.Caracteristicas.Destreza} | {jugadorElegido.Caracteristicas.Fuerza} | {jugadorElegido.Caracteristicas.Velocidad} | {jugadorElegido.Caracteristicas.Proteccion} | {jugadorElegido.Caracteristicas.Salud} | {jugadorElegido.Caracteristicas.Nivel}");
            Console.WriteLine();

            return jugadorElegido;
        }

        private static Personaje SeleccionarRival(List<Personaje> personajes, Personaje jugador)
        {
            // Selecciona un rival aleatorio que no sea el jugador
            var rivales = personajes.Where(p => p != jugador).OrderBy(x => random.Next()).Take(1).ToList();
            return rivales.First();
        }

        private static void AplicarEfectosPlaneta(Result planeta, Personaje personaje)
        {
            // Aplica los efectos del planeta en las características del personaje
            switch (planeta.Climate.ToLower())
            {
                case "arid":
                    personaje.Caracteristicas.Salud -= 10; // Ejemplo de efecto
                    break;
                case "tropical":
                    personaje.Caracteristicas.Velocidad += 5; // Ejemplo de efecto
                    break;
                // Agrega más casos según el clima
            }

            // Ajustes según el terreno y la gravedad pueden ser añadidos aquí
        }

        private static bool RealizarCombate(Personaje jugador, Personaje rival)
        {
            while (jugador.Caracteristicas.Salud > 0 && rival.Caracteristicas.Salud > 0)
            {
                // Turno del jugador
                Atacar(jugador, rival);

                // Verificar si el rival está derrotado
                if (rival.Caracteristicas.Salud <= 0)
                {
                    return true;
                }

                // Turno del rival
                Atacar(rival, jugador);

                // Verificar si el jugador está derrotado
                if (jugador.Caracteristicas.Salud <= 0)
                {
                    return false;
                }
            }

            return false;
        }

        private static void Atacar(Personaje atacante, Personaje defensor)
        {
            // Calcular daño
            int ataque = atacante.Caracteristicas.Destreza * atacante.Caracteristicas.Fuerza * atacante.Caracteristicas.Nivel;
            int efectividad = random.Next(1, 101); // Valor aleatorio entre 1 y 100
            int defensa = defensor.Caracteristicas.Proteccion * defensor.Caracteristicas.Velocidad;
            int constanteAjuste = 500;
            int danoProvocado = (ataque * efectividad - defensa) / constanteAjuste;

            // Aplicar daño
            defensor.Caracteristicas.Salud -= danoProvocado;
        }

        private static void MostrarResultado(bool jugadorGano)
        {
            Console.Clear();
            if (jugadorGano)
            {
                Console.WriteLine("¡Felicidades! Has ganado el combate.");
            }
            else
            {
                Console.WriteLine("Has sido derrotado. ¡Mejor suerte la próxima vez!");
            }
        }

        private static void GuardarGanador(Personaje ganador)
        {
            // Implementae la lógica para guardar el personaje ganador en el historial JSON
            

        }
    }
}
