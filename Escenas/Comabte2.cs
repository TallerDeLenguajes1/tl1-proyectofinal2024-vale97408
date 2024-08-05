using Personajes;

namespace Proyecto
{
    public class Combate
    {
       // private static Random random = new Random();

        // Funcion que reciba una cantidad de enemigos a generar aleatoriamente y la lista de personajes de la cual elegira aleatoriamente. Genera la cantidad de enemigos y muestra sus caracteristicas, devolviendo la lista con los enemigos cargados
       public static List<Personaje> GenerarEnemigosYMostrar(int cantidad, List<Personaje> listaPersonajes, Personaje personajeJugador)
      {
         Random random = new Random();
          List<Personaje> enemigos = new List<Personaje>();

          // Crear una lista sin el personaje del jugador
          List<Personaje> listaSinJugador = listaPersonajes.Where(p => p != personajeJugador).ToList();

          for (int i = 0; i < cantidad; i++)
         {
           if (listaSinJugador.Count == 0)
           {
            Console.WriteLine("No hay suficientes personajes para generar enemigos.");
            break;
           }

           Personaje personajeSeleccionado;

           // Asegurarse de que el personaje seleccionado no sea el mismo que el del jugador
          do
          {
             int aleatorio = random.Next(0, listaSinJugador.Count);
            personajeSeleccionado = listaSinJugador[aleatorio];
           } 
          while (personajeSeleccionado == personajeJugador);  // Asegurarse de que no sea el personaje del jugador

          // Agregar el personaje a la lista de enemigos
          enemigos.Add(personajeSeleccionado);

           // Mostrar las características del enemigo
          Inicio.CentrarTexto($"-ENEMIGO {i + 1}: {personajeSeleccionado.Datos.Nombre}, {personajeSeleccionado.Datos.Tipo}. Conocido como '{personajeSeleccionado.Datos.Apodo}'");
          Console.WriteLine("DESTREZA | FUERZA | VELOCIDAD | PROTECCION | SALUD | NIVEL");
          Console.WriteLine($" {personajeSeleccionado.Caracteristicas.Destreza} | {personajeSeleccionado.Caracteristicas.Fuerza} | {personajeSeleccionado.Caracteristicas.Velocidad} | {personajeSeleccionado.Caracteristicas.Proteccion} | {personajeSeleccionado.Caracteristicas.Salud} | {personajeSeleccionado.Caracteristicas.Nivel}");

          // Eliminar el personaje seleccionado de la lista para evitar duplicados
          listaSinJugador.Remove(personajeSeleccionado);
         }
          // Retornar la lista de enemigos generados
          return enemigos;
       }

       // Funcion que recibe el jugador elegido y la lista de enemigos para trabajar la pelea y devuelve el ganador del torneo 

       public static Personaje desarrolloCombate (Personaje jugadorElegido, List<Personaje> listaEnemigos)
       {
        Personaje ganador;
        ganador= jugadorElegido;
        // Trabajo logica

          return  ganador;
       }

       public 


        


    }
    
}