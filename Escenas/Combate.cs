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
          ////////////////////////////////////////
          // Verificar si hay suficientes personajes para cumplir con la cantidad requerida
          if (listaSinJugador.Count < cantidad)
           {
           Console.WriteLine($"No hay suficientes personajes para generar la cantidad deseada de enemigos.{listaSinJugador.Count}");
           return enemigos; // Retornar lista vacía si no hay suficientes personajes
          }
          ////////////////////////////////////////

          for (int i = 0; i < cantidad; i++)
         {
            /*if (listaSinJugador.Count == 0)
           {
            Console.WriteLine("No hay suficientes personajes para generar enemigos");
            break;
           }*/

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
           Console.WriteLine("");
           Console.ForegroundColor = ConsoleColor.Blue;
          Inicio.CentrarTexto($"-ENEMIGO {i + 1}: {personajeSeleccionado.Datos.Nombre}, {personajeSeleccionado.Datos.Tipo}. Conocido como '{personajeSeleccionado.Datos.Apodo}'");
          Console.WriteLine("");
           Console.ResetColor();

          // Define el ancho de cada columna
         int anchoColumna = 15; // Ajusta este valor según el tamaño máximo de tus datos

         // Alinea el encabezado de la tabla
         Inicio.CentrarTexto($"{"DESTREZA".PadRight(anchoColumna)}| {"FUERZA".PadRight(anchoColumna)}| {"VELOCIDAD".PadRight(anchoColumna)}| {"PROTECCIÓN".PadRight(anchoColumna)}| {"SALUD".PadRight(anchoColumna)}| {"NIVEL".PadRight(anchoColumna)}");

         // Alinea los datos del personaje seleccionado
         Inicio.CentrarTexto($"{personajeSeleccionado.Caracteristicas.Destreza.ToString().PadRight(anchoColumna)}| {personajeSeleccionado.Caracteristicas.Fuerza.ToString().PadRight(anchoColumna)}| {personajeSeleccionado.Caracteristicas.Velocidad.ToString().PadRight(anchoColumna)}| {personajeSeleccionado.Caracteristicas.Proteccion.ToString().PadRight(anchoColumna)}| {personajeSeleccionado.Caracteristicas.Salud.ToString().PadRight(anchoColumna)}| {personajeSeleccionado.Caracteristicas.Nivel.ToString().PadRight(anchoColumna)}");
            Console.WriteLine("");
            Console.WriteLine("");


         /* Inicio.CentrarTexto("DESTREZA | FUERZA | VELOCIDAD | PROTECCION | SALUD | NIVEL");
          Inicio.CentrarTexto($" {personajeSeleccionado.Caracteristicas.Destreza} | {personajeSeleccionado.Caracteristicas.Fuerza} | {personajeSeleccionado.Caracteristicas.Velocidad} | {personajeSeleccionado.Caracteristicas.Proteccion} | {personajeSeleccionado.Caracteristicas.Salud} | {personajeSeleccionado.Caracteristicas.Nivel}");
          */
           Thread.Sleep(1000);

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
             Inicio. CentrarTexto("_____________________    .    ______________________");
          Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("");
            Inicio.CentrarTexto($"   PLANETA {planeta.Name}    ");
          Console.WriteLine("");
            Console.ResetColor();
             Inicio. CentrarTexto("_____________________    .    ______________________");
             Console.WriteLine("");
            //  Console.ForegroundColor = ConsoleColor.Blue;
            Inicio.CentrarTexto($"CLIMA : {planeta.Climate}");
            Inicio.CentrarTexto($"TERRENO: {planeta.Terrain}");
            Inicio.CentrarTexto($"GRAVEDAD: {planeta.Gravity}");
            Inicio.CentrarTexto($"CREACION: {planeta.Created}");
            //  Console.ResetColor();
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
         
          public  void MostrarComparacionPersonajes(Personaje personaje1, Personaje personaje2)
          {
             // Inicio.CentrarTexto("---- CARACTERISTICAS DE COMPETIDORES-----:");

              // Formato del versus
             // Inicio.CentrarTexto("  " + personaje1.Datos.Nombre + " VS" +  personaje2.Datos.Nombre + "  ");

              Inicio.CentrarTexto(new string('-', 80));

              // Encabezados
               Inicio.CentrarTexto($"{ "Característica",-15} | {personaje1.Datos.Nombre,-25} | {personaje2.Datos.Nombre,-25}");
               Inicio.CentrarTexto(new string('-', 80));

              // Mostrar características
              Inicio.CentrarTexto($"{ "Tipo",-15} | {personaje1.Datos.Tipo,-25} | {personaje2.Datos.Tipo,-25}");
              Inicio.CentrarTexto($"{ "Velocidad",-15} | {personaje1.Caracteristicas.Velocidad,-25} | {personaje2.Caracteristicas.Velocidad,-25}");
              Inicio.CentrarTexto($"{ "Destreza",-15} | {personaje1.Caracteristicas.Destreza,-25} | {personaje2.Caracteristicas.Destreza,-25}");
              Inicio.CentrarTexto($"{ "Fuerza",-15} | {personaje1.Caracteristicas.Fuerza,-25} | {personaje2.Caracteristicas.Fuerza,-25}");
              Inicio.CentrarTexto($"{ "Nivel",-15} | {personaje1.Caracteristicas.Nivel,-25} | {personaje2.Caracteristicas.Nivel,-25}");
              Inicio.CentrarTexto($"{ "Protección",-15} | {personaje1.Caracteristicas.Proteccion,-25} | {personaje2.Caracteristicas.Proteccion,-25}");
              Inicio.CentrarTexto($"{ "Salud",-15} | {personaje1.Caracteristicas.Salud,-25} | {personaje2.Caracteristicas.Salud,-25}");

              Inicio.CentrarTexto(new string('-', 80));
            }

            // FUNCION QUE CADA AUMENTA EL NIVEL DEL PERSONAJE- Se usa cuando el jugador gana una ronda. Devuelve el personaje modificado 
            public static Personaje AumentarNivel(Personaje personaje)
           {
              if (personaje == null)
               {
                  throw new ArgumentNullException(nameof(personaje), "El personaje no puede ser nulo.");
               }

               // Obtener las características actuales del personaje
               var caracteristicas = personaje.Caracteristicas;

               // Definir el aumento por nivel
               int aumentoVelocidad = 2;
               int aumentoDestreza = 2;
               int aumentoFuerza = 3;
               int aumentoNivel = 1;
               int aumentoProteccion = 2;
               int aumentoSalud = 5;

               // Aumentar las características del personaje
               caracteristicas.Velocidad += aumentoVelocidad;
               caracteristicas.Destreza += aumentoDestreza;
               caracteristicas.Fuerza += aumentoFuerza;
               caracteristicas.Nivel += aumentoNivel;
               caracteristicas.Proteccion += aumentoProteccion;
               caracteristicas.Salud += aumentoSalud;

               // Actualizar las características del personaje
               personaje.Caracteristicas = caracteristicas;

               return personaje;
             }
         
         // FUNCION A APLICAR ENTRE EL ATAQUE DE TURNOS 
          private  void Atacar(Personaje atacante, Personaje defensor)
        {
            Random random = new Random();
            // Calcular daño
            int ataque = atacante.Caracteristicas.Destreza * atacante.Caracteristicas.Fuerza * atacante.Caracteristicas.Nivel;
            int efectividad = random.Next(1, 101); // Valor aleatorio entre 1 y 100
            int defensa = defensor.Caracteristicas.Proteccion * defensor.Caracteristicas.Velocidad;
            int constanteAjuste = 500;
            int danoProvocado = (ataque * efectividad - defensa) / constanteAjuste;

            // Aplicar daño
            defensor.Caracteristicas.Salud -= danoProvocado;

            // Muestro mensajes 
            // Mostrar mensaje de ataque
            Inicio.CentrarTexto("____________________________________________________");
           Inicio.CentrarTexto($"{atacante.Datos.Nombre} ataca a {defensor.Datos.Nombre}.");
           Inicio.CentrarTexto($"{atacante.Datos.Nombre} inflige {danoProvocado} de daño a {defensor.Datos.Nombre}.");
           Inicio.CentrarTexto("____________________________________________________");
            Thread.Sleep(2000); // Esperar 2 segundos para que el jugador lea el mensaje

        }


        // FUNCION PARA IR MOSTRANDO LA SALUD DE MI PERSONAJE
        private  void MostrarSalud(Personaje jugador, Personaje rival, int cantRonda, int nro)
         {
               // Muestra la salud de cada personaje alineada
              int nombreLength = 20; // Ajusta este valor según el largo máximo de los nombres
             int saludLength = 10;  // Ajusta este valor según el largo máximo de los valores de salud
    
              // Espacios entre columnas para alineación
            string espacioNombre = new string(' ', nombreLength);
              string espacioSalud = new string(' ', saludLength);
             Console.Clear(); // Limpiar consola
            // Muestra encabezado de la pelea
            
         Inicio. CentrarTexto("_____________________    .    ______________________");
          Console.WriteLine("");
          Console.ForegroundColor = ConsoleColor.DarkYellow;
          Inicio.CentrarTexto($"RONDA NRO {nro}/ {cantRonda}");
          Console.WriteLine("");
          Console.ResetColor();
          Inicio. CentrarTexto("_____________________    .    ______________________");
         
          // Console.WriteLine("");
          //  Inicio.CentrarTexto($"--- { jugador.Datos.Nombre}         VS         {rival.Datos.Nombre} ---");
          //  Console.WriteLine("");
          //   Inicio. CentrarTexto("_____________________    .    ______________________");
           
    // Encabezado de la tabla
    Console.WriteLine("");
      Console.WriteLine("");
        Console.WriteLine("");

    Inicio.CentrarTexto("SALUD");
    Inicio. CentrarTexto("_____________________    .    ______________________");
    Inicio.CentrarTexto($"{jugador.Datos.Nombre,-20} | {rival.Datos.Nombre,-20}");
    Inicio.CentrarTexto(new string('-', nombreLength + 3 + nombreLength));
      //Inicio. CentrarTexto("___________________________________________");
    // Valores de salud
    Inicio.CentrarTexto($"{jugador.Caracteristicas.Salud,-20} | {rival.Caracteristicas.Salud,-20}");
            
           /* Console.Clear(); // Limpiar consola
            Console.WriteLine($"{"Nombre", -20} | {"Salud", -10}");
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"{jugador.Datos.Nombre, -20}(Tú) | {jugador.Caracteristicas.Salud, -10}");
            Console.WriteLine($"{rival.Datos.Nombre, -20} | {rival.Caracteristicas.Salud, -10}");*/
         }



         // FUNCION QUE REALIZA TODO EL COMBATE DE UNA RONDA- UNO SALE VICTORIOSO
         private  bool RealizarCombate(Personaje jugador, Personaje rival, int cantRonda, int nro)
          {
            while (jugador.Caracteristicas.Salud > 0 && rival.Caracteristicas.Salud > 0)
            {
               Inicio. CentrarTexto("_____________________    .    ______________________");
          Console.WriteLine("");
          Console.ForegroundColor = ConsoleColor.DarkYellow;
          Inicio.CentrarTexto($"RONDA NRO {nro}/ {cantRonda}");
          Console.WriteLine("");
          Console.ResetColor();
          Inicio. CentrarTexto("_____________________    .    ______________________");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                // Turno del jugador
                Atacar(jugador, rival);
                Console.ResetColor();
                // Mostrar la salud actualizada
                MostrarSalud(jugador, rival, cantRonda, nro);
        
                // Verificar si el rival está derrotado
                if (rival.Caracteristicas.Salud <= 0)
                {
                    Console.Clear(); // Limpiar consola para mostrar el mensaje final
                    Inicio.CentrarTexto($"{jugador.Datos.Nombre} ha ganado la ronda!");
                    return true;
                }
                
                 Console.ForegroundColor = ConsoleColor.DarkRed;
                  // Turno del rival
                 Atacar(rival, jugador);
                 Console.ResetColor();
        
                // Mostrar la salud actualizada
                MostrarSalud(jugador, rival, cantRonda,nro);

                // Verificar si el jugador está derrotado
                if (jugador.Caracteristicas.Salud <= 0)
                {
                    Console.Clear(); // Limpiar consola para mostrar el mensaje final
                    Inicio.CentrarTexto($"{rival.Datos.Nombre} ha ganado la ronda!");
                    return false;
                }
            }

            return false;
        } 


         // Funcion que recibe el jugador elegido y la lista de enemigos para trabajar la pelea con las rondas, maneja el control de toda la partida
         public  Personaje desarrolloCombate (Personaje jugadorElegido, List<Personaje> listaEnemigos)
         {
          // La cantidad de rondas seran de acuerdo a la cantidad de enemigos que tenga a vencer de la lista enemigos
          int cantidadRondas = listaEnemigos.Count;
           Personaje ganador= jugadorElegido; // Por defecto , se modificara si pierde

          // Cada vez que le gane a un competidor pasara de ronda(peleara con el otro personaje de los que queden en la lista, no con el mismo ) y sus caracteristicas mejoraran.
          int i=0; 
          foreach (var enemigo in listaEnemigos)
          // Iterar a través de cada enemigo en la lista
         { i++; 
            Console.Clear();
           Inicio. CentrarTexto("_____________________    .    ______________________");
          Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Inicio.CentrarTexto($"RONDA NRO {i}/ {cantidadRondas}");
             Console.ResetColor();
            Console.WriteLine("");
            Inicio. CentrarTexto("_____________________    .    ______________________");
            Console.WriteLine("");
            Inicio.CentrarTexto($"--- { jugadorElegido.Datos.Nombre}         VS         {enemigo.Datos.Nombre} ---");
            //Console.WriteLine("");
             Inicio. CentrarTexto("_____________________    .    ______________________");
              Console.WriteLine("");
               Console.WriteLine("");
              Inicio.CentrarTexto("-------CARACTERISTICAS DE PERSONAJES --------");
              Console.WriteLine("");
            MostrarComparacionPersonajes(jugadorElegido, enemigo);
            Thread.Sleep(7000);

            // Limpio consola 
            Console.Clear();
            Inicio. CentrarTexto("_____________________    .    ______________________");
          Console.WriteLine("");
           Console.ForegroundColor = ConsoleColor.DarkYellow;
            Inicio.CentrarTexto($"RONDA NRO {i}/ {cantidadRondas}");
             Console.ResetColor();
            Console.WriteLine("");
            Inicio. CentrarTexto("_____________________    .    ______________________");
            Console.WriteLine("");
            Inicio.CentrarTexto($"--- { jugadorElegido.Datos.Nombre}         VS         {enemigo.Datos.Nombre} ---");
            Console.WriteLine("");
             Inicio. CentrarTexto("_____________________    .    ______________________");
              Console.WriteLine("");

            Inicio.CentrarTexto(" Cargando el planeta de combate... ¡Prepárate para descubrir el escenario de tu próximo enfrentamiento!"); 
            Console.WriteLine("");
            Thread.Sleep(1000);
            
           // Obtener un planeta aleatorio y mostrar sus características
           Result planeta = ObtenerYMostrarPlanetaAsync().Result;
           // Muestro el planeta 
           //MostrarCaracteristicasPlaneta(planeta);
           Thread.Sleep(2000);

           Console.Write("\nPresiona cualquier tecla para CONTINUAR");
            Console.ReadKey();   
         
          Console.Clear();
         Inicio. CentrarTexto("_____________________    .    ______________________");
          Console.WriteLine("");
          Console.ForegroundColor = ConsoleColor.DarkYellow;
          Inicio.CentrarTexto($"RONDA NRO {i}/ {cantidadRondas}");
            Console.WriteLine("");
             Console.ResetColor();
            Inicio. CentrarTexto("_____________________    .    ______________________");
            Console.WriteLine("");
            Inicio.CentrarTexto($"--- { jugadorElegido.Datos.Nombre}         VS         {enemigo.Datos.Nombre} ---");
            Console.WriteLine("");
            Inicio. CentrarTexto("_____________________    .    ______________________");
            Console.WriteLine("");

          // Modificar las características del jugador y el enemigo según el planeta
          ModificarCaracteristicasPorPlaneta(planeta, jugadorElegido);
          ModificarCaracteristicasPorPlaneta(planeta, enemigo);
        
          Console.WriteLine("");
          Console.ForegroundColor = ConsoleColor.DarkRed;
          Inicio.CentrarTexto("-------CARACTERISTICAS DE PERSONAJES MODIFICADAS--------");
             Console.ResetColor();
            

          MostrarComparacionPersonajes(jugadorElegido, enemigo);
           Console.WriteLine("");
         Thread.Sleep(4000); // Esperar para que el jugador lea el mensaje
           Console.Write("\nPresiona cualquier tecla para CONTINUAR");
           Console.ReadKey();   
         
  
         Console.Clear();
         Titulo.ContadorPelea();
         Thread.Sleep(1000);
         Console.Clear();

        

        // Realizar el combate entre el jugador y el enemigo
        bool jugadorGano = RealizarCombate(jugadorElegido, enemigo,cantidadRondas,i );

        if (jugadorGano ) // Siempre que haya ganado 
        {    Console.ForegroundColor = ConsoleColor.DarkYellow;
            // El jugador gana la ronda, aumenta su nivel
            jugadorElegido = AumentarNivel(jugadorElegido);
            Inicio. CentrarTexto("_____________________    .    ______________________");
          Console.WriteLine("");
            Inicio.CentrarTexto($"{jugadorElegido.Datos.Nombre} ha ganado la ronda!");
             Console.WriteLine("");
            Inicio. CentrarTexto("_____________________    .    ______________________");

            if( cantidadRondas!=i) //siempre que no sea su ultima ronda
            {
            Inicio. CentrarTexto(".....................................................");
             Console.WriteLine("");
            Inicio.CentrarTexto("TU MAGIA HA EVOLUCIONADO. ¡Estás preparado para enfrentarte a tu próximo oponente con habilidades mejoradas!");
             Console.WriteLine("");
            Inicio. CentrarTexto(".....................................................");
            }
            Thread.Sleep(5000); // Esperar para que el jugador lea el mensaje
            Console.ResetColor();
            
        }
        else
        {
            // El jugador pierde la ronda
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{enemigo.Datos.Nombre} ha ganado la ronda. Fin del combate.");
            Console.ResetColor();
              Console.Write("\nPresiona cualquier tecla para CONTINUAR");
           Console.ReadKey();  
            return enemigo; // El enemigo gana y se convierte en el ganador
        }
      }

         // El jugador gana todas las rondas
         Inicio.CentrarTexto($"{jugadorElegido.Datos.Nombre} HA GANADO LA BATALLA!");
         Console.Write("\nPresiona cualquier tecla para CONTINUAR");
          Console.ReadKey();  
          return  ganador;
         }

    }
    
}