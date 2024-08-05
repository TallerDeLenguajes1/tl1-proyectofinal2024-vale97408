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

       


       // Funcion que obtenga un planeta aleatorio de mi API , muestre sus caracteristicas y me devuelva el planeta generado
       public  async Task<Result> ObtenerYMostrarPlanetaAsync()
        {
            // Obtener datos de planetas
            Planetas planetaElegido = await PlanetasAPI.GetWeatherAsync();
            if (planetaElegido != null && planetaElegido.Results.Count > 0)
            {
                // Mostrar un planeta aleatorio de la API
                Random random = new Random();
                Result planeta = planetaElegido.Results[random.Next(planetaElegido.Results.Count)];
                MostrarCaracteristicasPlaneta(planeta);
                return planeta; 
            }
            else
            {
                Console.WriteLine("\nNo se pudieron obtener los datos de los planetas.");
                return null; // Si no encontro un planeta
            }
        }

        

        // Función para mostrar las características del planeta
         private static void MostrarCaracteristicasPlaneta(Result planeta)
        {
            Inicio.CentrarTexto($"-------PLANETA {planeta.Name}--------");
            Console.WriteLine($"Clima: {planeta.Climate}");
            Console.WriteLine($"Terreno: {planeta.Terrain}");
            Console.WriteLine($"Gravedad: {planeta.Gravity}");
            Console.WriteLine($"Creación: {planeta.Created}");
            Console.WriteLine(); // Línea en blanco para separación
        }

           // Modifica caracteristicas de acuerdo al planeta seleccionado en la ronda-chat
          public static void ModificarCaracteristicasPorPlaneta(Result planeta, Personaje personaje)
          {
          // Ajustes basados en el clima del planeta
            if (planeta.Climate.Contains("arid") || planeta.Climate.Contains("desert"))
             {
            // Clima árido o desértico
            switch (personaje.Datos.Tipo)
            {  
            case TipoPersonaje.HechiceroDeFuego:
                personaje.Caracteristicas.Fuerza += 10; // Ejemplo de aumento
                break;
            case TipoPersonaje.HechiceroDeHielo:
                personaje.Caracteristicas.Salud -= 10; // Ejemplo de decremento
                break;
            case TipoPersonaje.HechiceroDeLaNaturaleza:
                personaje.Caracteristicas.Velocidad -= 5; // Ejemplo de decremento
                break;
            case TipoPersonaje.HechiceroDeLasSombras:
                personaje.Caracteristicas.Proteccion -= 5; // Ejemplo de decremento
                break;
            case TipoPersonaje.HechiceroDeLuz:
                personaje.Caracteristicas.Destreza += 5; // Ejemplo de aumento
                break;
            }
           }
              else if (planeta.Climate.Contains("temperate") || planeta.Climate.Contains("tropical"))
                 {
                  // Clima templado o tropical
                  switch (personaje.Datos.Tipo)
                 {
                 case TipoPersonaje.HechiceroDeFuego:
                 personaje.Caracteristicas.Salud -= 10; // Ejemplo de decremento
                  break;
                 case TipoPersonaje.HechiceroDeHielo:
                 personaje.Caracteristicas.Fuerza += 10; // Ejemplo de aumento
                  break;
                 case TipoPersonaje.HechiceroDeLaNaturaleza:
                  personaje.Caracteristicas.Destreza += 5; // Ejemplo de aumento
                  break;
                 case TipoPersonaje.HechiceroDeLasSombras:
                  personaje.Caracteristicas.Velocidad += 5; // Ejemplo de aumento
                 break;
                 case TipoPersonaje.HechiceroDeLuz:
                 personaje.Caracteristicas.Proteccion += 10; // Ejemplo de aumento
                 break;
                  }
                }
                else if (planeta.Climate.Contains("frozen") || planeta.Climate.Contains("murky"))
                  {
                    // Clima congelado o turbio
                   switch (personaje.Datos.Tipo)
                  {
                  case TipoPersonaje.HechiceroDeFuego:
                   personaje.Caracteristicas.Fuerza -= 10; // Ejemplo de decremento
                   break;
                  case TipoPersonaje.HechiceroDeHielo:
                    personaje.Caracteristicas.Salud += 10; // Ejemplo de aumento
                   break;
                   case TipoPersonaje.HechiceroDeLaNaturaleza:
                   personaje.Caracteristicas.Proteccion += 5; // Ejemplo de aumento
                   break;
                   case TipoPersonaje.HechiceroDeLasSombras:
                    personaje.Caracteristicas.Velocidad -= 5; // Ejemplo de decremento
                    break;
                   case TipoPersonaje.HechiceroDeLuz:
                    personaje.Caracteristicas.Destreza -= 5; // Ejemplo de decremento
                     break;
                }
                 }
    
                // Ajustes basados en el terreno del planeta
                if (planeta.Terrain.Contains("desert") || planeta.Terrain.Contains("tundra"))
                   {
                      // Terreno desértico o tundra
                       switch (personaje.Datos.Tipo)
                      {
                          case TipoPersonaje.HechiceroDeFuego:
                          personaje.Caracteristicas.Velocidad += 5; // Ejemplo de aumento
                          break;
                          case TipoPersonaje.HechiceroDeHielo:
                          personaje.Caracteristicas.Fuerza -= 5; // Ejemplo de decremento
                          break;
                          case TipoPersonaje.HechiceroDeLaNaturaleza:
                           personaje.Caracteristicas.Salud -= 5; // Ejemplo de decremento
                           break;
                          case TipoPersonaje.HechiceroDeLasSombras:
                           personaje.Caracteristicas.Destreza -= 5; // Ejemplo de decremento
                          break;
                          case TipoPersonaje.HechiceroDeLuz:
                            personaje.Caracteristicas.Proteccion += 5; // Ejemplo de aumento
                           break;
                        }
                         }
                             else if (planeta.Terrain.Contains("jungle") || planeta.Terrain.Contains("swamp"))
                                {
                                    // Terreno de jungla o pantano
                                    switch (personaje.Datos.Tipo)
                                    {
                                        case TipoPersonaje.HechiceroDeFuego:
                                         personaje.Caracteristicas.Proteccion -= 5; // Ejemplo de decremento
                                         break;
                                      case TipoPersonaje.HechiceroDeHielo:
                                          personaje.Caracteristicas.Velocidad += 5; // Ejemplo de aumento
                                          break;
                                      case TipoPersonaje.HechiceroDeLaNaturaleza:
                                          personaje.Caracteristicas.Fuerza += 5; // Ejemplo de aumento
                                          break;
                                      case TipoPersonaje.HechiceroDeLasSombras:
                                          personaje.Caracteristicas.Salud += 5; // Ejemplo de aumento
                                          break;
                                      case TipoPersonaje.HechiceroDeLuz:
                                          personaje.Caracteristicas.Destreza += 5; // Ejemplo de aumento
                                          break;
                                      }
                                     }

    
           }

           // FUNCION QUE MUESTRA LAS CARACTERISTICAS MODIFICADAS, comparando al jugador y al rival
         
          public static void MostrarComparacionPersonajes(Personaje personaje1, Personaje personaje2)
          {
             // Inicio.CentrarTexto("---- CARACTERISTICAS DE COMPETIDORES-----:");

              // Formato del versus
              Inicio.CentrarTexto("  " + personaje1.Datos.Nombre + " VS" +  personaje2.Datos.Nombre + "  ");

              Console.WriteLine(new string('-', 80));

              // Encabezados
              Console.WriteLine($"{ "Característica",-15} | {personaje1.Datos.Nombre,-25} | {personaje2.Datos.Nombre,-25}");
              Console.WriteLine(new string('-', 80));

              // Mostrar características
              Console.WriteLine($"{ "Velocidad",-15} | {personaje1.Caracteristicas.Velocidad,-25} | {personaje2.Caracteristicas.Velocidad,-25}");
              Console.WriteLine($"{ "Destreza",-15} | {personaje1.Caracteristicas.Destreza,-25} | {personaje2.Caracteristicas.Destreza,-25}");
              Console.WriteLine($"{ "Fuerza",-15} | {personaje1.Caracteristicas.Fuerza,-25} | {personaje2.Caracteristicas.Fuerza,-25}");
              Console.WriteLine($"{ "Nivel",-15} | {personaje1.Caracteristicas.Nivel,-25} | {personaje2.Caracteristicas.Nivel,-25}");
              Console.WriteLine($"{ "Protección",-15} | {personaje1.Caracteristicas.Proteccion,-25} | {personaje2.Caracteristicas.Proteccion,-25}");
              Console.WriteLine($"{ "Salud",-15} | {personaje1.Caracteristicas.Salud,-25} | {personaje2.Caracteristicas.Salud,-25}");

              Console.WriteLine(new string('-', 80));
            }



           



        





         // Funcion que recibe el jugador elegido y la lista de enemigos para trabajar la pelea y devuelve el ganador del torneo 
         public static Personaje desarrolloCombate (Personaje jugadorElegido, List<Personaje> listaEnemigos)
         {
          // La cantidad de rondas seran de acuerdo a la cantidad de enemigos que tenga a vencer de la lista enemigos
          int cantidadRondas = listaEnemigos.Count;
          Personaje ganador;
          ganador= jugadorElegido;
        // Trabajo logica

          return  ganador;
         }
        






        


    }
    
}