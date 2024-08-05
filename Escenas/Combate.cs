using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personajes;
using Juego;


namespace Proyecto
{
    public class Combate
    {
        private static Random random = new Random();

        // Función para calcular el daño
        private static int CalcularDanio(Personaje atacante, Personaje defensor)
        {
            // Ataque del atacante
            int ataque = atacante.Caracteristicas.Destreza * atacante.Caracteristicas.Fuerza * atacante.Caracteristicas.Nivel;
            // Efectividad aleatoria entre 1 y 100
            int efectividad = random.Next(1, 101);
            // Defensa del defensor
            int defensa = defensor.Caracteristicas.Proteccion * defensor.Caracteristicas.Velocidad;
            // Constante de ajuste
            const int constanteAjuste = 500;
            // Cálculo del daño
            int danio = (ataque * efectividad - defensa) / constanteAjuste;
            // Asegurarse de que el daño no sea negativo
            return Math.Max(danio, 0);
        }

        // Función para realizar un combate entre dos personajes
        public static async Task RealizarCombate(Personaje jugador, Personaje enemigo)
        {
            Console.Clear();
            Console.WriteLine($"¡El combate entre {jugador.Datos.Nombre} y {enemigo.Datos.Nombre} ha comenzado!");
            while (jugador.Caracteristicas.Salud > 0 && enemigo.Caracteristicas.Salud > 0)
            {
                // Turno del jugador
                Console.WriteLine($"\n{jugador.Datos.Nombre} ataca a {enemigo.Datos.Nombre}!");
                int danio = CalcularDanio(jugador, enemigo);
                enemigo.Caracteristicas.Salud -= danio;
                Console.WriteLine($"{jugador.Datos.Nombre} inflige {danio} puntos de daño a {enemigo.Datos.Nombre}.");
                
                // Verificar si el enemigo ha sido derrotado
                if (enemigo.Caracteristicas.Salud <= 0)
                {
                    Console.WriteLine($"\n{enemigo.Datos.Nombre} ha sido derrotado. ¡{jugador.Datos.Nombre} es el ganador!");
                    // Mejora de habilidades para el ganador
                    jugador.Caracteristicas.Salud += 10; // Ejemplo de mejora en salud
                    jugador.Caracteristicas.Proteccion += 5; // Ejemplo de mejora en protección
                    return;
                }

                // Turno del enemigo
                Console.WriteLine($"\n{enemigo.Datos.Nombre} ataca a {jugador.Datos.Nombre}!");
                danio = CalcularDanio(enemigo, jugador);
                jugador.Caracteristicas.Salud -= danio;
                Console.WriteLine($"{enemigo.Datos.Nombre} inflige {danio} puntos de daño a {jugador.Datos.Nombre}.");

                // Verificar si el jugador ha sido derrotado
                if (jugador.Caracteristicas.Salud <= 0)
                {
                    Console.WriteLine($"\n{jugador.Datos.Nombre} ha sido derrotado. {enemigo.Datos.Nombre} es el ganador.");
                    return;
                }
            }
        }

        // Función para determinar el resultado del combate
        public static void MostrarResultado(Personaje jugador, Personaje enemigo)
        {
            if (jugador.Caracteristicas.Salud > 0)
            {
                // Mensaje de victoria
                Console.WriteLine($"\n¡{jugador.Datos.Nombre} ha ganado el combate contra {enemigo.Datos.Nombre}!");
            }
            else
            {
                // Mensaje de derrota
                Console.WriteLine($"\n{jugador.Datos.Nombre} ha perdido el combate contra {enemigo.Datos.Nombre}.");
            }
        }

        // Función para guardar el personaje ganador en el historial JSON
        /*public static void GuardarGanador(Personaje ganador, HistorialJson historial)
        {
            // Obtener la lista de ganadores actuales
            List<Personaje> ganadores = historial.LeerGanadores("ganadores.json");
            // Agregar el nuevo ganador
            ganadores.Add(ganador);
            // Guardar la lista actualizada
            historial.GuardarGanadores(ganadores, "ganadores.json");
        } */
    }
}
