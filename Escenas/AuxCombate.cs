using Personajes;

namespace Proyecto
{
    public class Combate
    {
        
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
                while (personajeSeleccionado == personajeJugador); 

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

                Thread.Sleep(1000);

                // Eliminar el personaje seleccionado de la lista para evitar duplicados
                listaSinJugador.Remove(personajeSeleccionado);
            }
            // Retornar la lista de enemigos generados
            return enemigos;
        }




        // Funcion que obtenga un planeta aleatorio de mi API , muestre sus caracteristicas y me devuelva el planeta generado
        public static async Task<Result> ObtenerYMostrarPlanetaAsync()
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
        public static void MostrarCaracteristicasPlaneta(Result planeta)
        {
            Inicio.CentrarTexto("_____________________    .    ______________________");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("");
            Inicio.CentrarTexto($"   PLANETA {planeta.Name}    ");
            Console.WriteLine("");
            Console.ResetColor();
            Inicio.CentrarTexto("_____________________    .    ______________________");
            Console.WriteLine("");
            //  Console.ForegroundColor = ConsoleColor.Blue;
            Inicio.CentrarTexto($"CLIMA : {planeta.Climate}");
            Inicio.CentrarTexto($"TERRENO: {planeta.Terrain}");
            Inicio.CentrarTexto($"GRAVEDAD: {planeta.Gravity}");
            Inicio.CentrarTexto($"CREACION: {planeta.Created}");
            //  Console.ResetColor();
            Console.WriteLine(); // Línea en blanco para separación
        }

        // Modifica caracteristicas de acuerdo al planeta seleccionado en la ronda- Hecho con IA
        public static void ModificarCaracteristicasPorPlaneta(Result planeta, Personaje personaje)
        {
            // Definir valores mínimos y máximos para las características para evitar daños negativos o valores no deseados.
            const int MIN_SALUD = 2; // Salud mínima para evitar 0 o valores negativos
            const int MIN_FUERZA = 2; // Fuerza mínima para evitar 0 o valores negativos
            const int MIN_VELOCIDAD = 2; // Velocidad mínima para evitar 0 o valores negativos
            const int MIN_PROTECCION = 2; // Protección mínima para evitar 0 o valores negativos
            const int MIN_DESTREZA = 2; // Destreza mínima para evitar 0 o valores negativos

            // Ajustes basados en el clima del planeta
            if (planeta.Climate.Contains("arid") || planeta.Climate.Contains("desert"))
            {
                // Clima árido o desértico
                switch (personaje.Datos.Tipo)
                {
                    case TipoPersonaje.HechiceroDeFuego:
                        personaje.Caracteristicas.Fuerza = Math.Max(MIN_FUERZA, personaje.Caracteristicas.Fuerza + 10); // Aumento
                        break;
                    case TipoPersonaje.HechiceroDeHielo:
                        personaje.Caracteristicas.Salud = Math.Max(MIN_SALUD, personaje.Caracteristicas.Salud - 10); // Decremento
                        break;
                    case TipoPersonaje.HechiceroDeLaNaturaleza:
                        personaje.Caracteristicas.Velocidad = Math.Max(MIN_VELOCIDAD, personaje.Caracteristicas.Velocidad - 5); // Decremento
                        break;
                    case TipoPersonaje.HechiceroDeLasSombras:
                        personaje.Caracteristicas.Proteccion = Math.Max(MIN_PROTECCION, personaje.Caracteristicas.Proteccion - 5); // Decremento
                        break;
                    case TipoPersonaje.HechiceroDeLuz:
                        personaje.Caracteristicas.Destreza = Math.Max(MIN_DESTREZA, personaje.Caracteristicas.Destreza + 5); // Aumento
                        break;
                }
            }
            else if (planeta.Climate.Contains("temperate") || planeta.Climate.Contains("tropical"))
            {
                // Clima templado o tropical
                switch (personaje.Datos.Tipo)
                {
                    case TipoPersonaje.HechiceroDeFuego:
                        personaje.Caracteristicas.Salud = Math.Max(MIN_SALUD, personaje.Caracteristicas.Salud - 10); // Decremento
                        break;
                    case TipoPersonaje.HechiceroDeHielo:
                        personaje.Caracteristicas.Fuerza = Math.Max(MIN_FUERZA, personaje.Caracteristicas.Fuerza + 10); // Aumento
                        break;
                    case TipoPersonaje.HechiceroDeLaNaturaleza:
                        personaje.Caracteristicas.Destreza = Math.Max(MIN_DESTREZA, personaje.Caracteristicas.Destreza + 5); // Aumento
                        break;
                    case TipoPersonaje.HechiceroDeLasSombras:
                        personaje.Caracteristicas.Velocidad = Math.Max(MIN_VELOCIDAD, personaje.Caracteristicas.Velocidad + 5); // Aumento
                        break;
                    case TipoPersonaje.HechiceroDeLuz:
                        personaje.Caracteristicas.Proteccion = Math.Max(MIN_PROTECCION, personaje.Caracteristicas.Proteccion + 10); // Aumento
                        break;
                }
            }
            else if (planeta.Climate.Contains("frozen") || planeta.Climate.Contains("murky"))
            {
                // Clima congelado o turbio
                switch (personaje.Datos.Tipo)
                {
                    case TipoPersonaje.HechiceroDeFuego:
                        personaje.Caracteristicas.Fuerza = Math.Max(MIN_FUERZA, personaje.Caracteristicas.Fuerza - 10); // Decremento
                        break;
                    case TipoPersonaje.HechiceroDeHielo:
                        personaje.Caracteristicas.Salud = Math.Max(MIN_SALUD, personaje.Caracteristicas.Salud + 10); // Aumento
                        break;
                    case TipoPersonaje.HechiceroDeLaNaturaleza:
                        personaje.Caracteristicas.Proteccion = Math.Max(MIN_PROTECCION, personaje.Caracteristicas.Proteccion + 5); // Aumento
                        break;
                    case TipoPersonaje.HechiceroDeLasSombras:
                        personaje.Caracteristicas.Velocidad = Math.Max(MIN_VELOCIDAD, personaje.Caracteristicas.Velocidad - 5); // Decremento
                        break;
                    case TipoPersonaje.HechiceroDeLuz:
                        personaje.Caracteristicas.Destreza = Math.Max(MIN_DESTREZA, personaje.Caracteristicas.Destreza - 5); // Decremento
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
                        personaje.Caracteristicas.Velocidad = Math.Max(MIN_VELOCIDAD, personaje.Caracteristicas.Velocidad + 5); // Aumento
                        break;
                    case TipoPersonaje.HechiceroDeHielo:
                        personaje.Caracteristicas.Fuerza = Math.Max(MIN_FUERZA, personaje.Caracteristicas.Fuerza - 5); // Decremento
                        break;
                    case TipoPersonaje.HechiceroDeLaNaturaleza:
                        personaje.Caracteristicas.Salud = Math.Max(MIN_SALUD, personaje.Caracteristicas.Salud - 5); // Decremento
                        break;
                    case TipoPersonaje.HechiceroDeLasSombras:
                        personaje.Caracteristicas.Destreza = Math.Max(MIN_DESTREZA, personaje.Caracteristicas.Destreza - 5); // Decremento
                        break;
                    case TipoPersonaje.HechiceroDeLuz:
                        personaje.Caracteristicas.Proteccion = Math.Max(MIN_PROTECCION, personaje.Caracteristicas.Proteccion + 5); // Aumento
                        break;
                }
            }
            else if (planeta.Terrain.Contains("jungle") || planeta.Terrain.Contains("swamp"))
            {
                // Terreno de jungla o pantano
                switch (personaje.Datos.Tipo)
                {
                    case TipoPersonaje.HechiceroDeFuego:
                        personaje.Caracteristicas.Proteccion = Math.Max(MIN_PROTECCION, personaje.Caracteristicas.Proteccion - 5); // Decremento
                        break;
                    case TipoPersonaje.HechiceroDeHielo:
                        personaje.Caracteristicas.Velocidad = Math.Max(MIN_VELOCIDAD, personaje.Caracteristicas.Velocidad + 5); // Aumento
                        break;
                    case TipoPersonaje.HechiceroDeLaNaturaleza:
                        personaje.Caracteristicas.Fuerza = Math.Max(MIN_FUERZA, personaje.Caracteristicas.Fuerza + 5); // Aumento
                        break;
                    case TipoPersonaje.HechiceroDeLasSombras:
                        personaje.Caracteristicas.Salud = Math.Max(MIN_SALUD, personaje.Caracteristicas.Salud + 5); // Aumento
                        break;
                    case TipoPersonaje.HechiceroDeLuz:
                        personaje.Caracteristicas.Destreza = Math.Max(MIN_DESTREZA, personaje.Caracteristicas.Destreza + 5); // Aumento
                        break;
                }
            }
        }

        // FUNCION QUE MUESTRA LAS CARACTERISTICAS MODIFICADAS, comparando al jugador y al rival

        public static void MostrarComparacionPersonajes(Personaje personaje1, Personaje personaje2)
        {
            Inicio.CentrarTexto(new string('-', 80));

            // Encabezados
            Inicio.CentrarTexto($"{"Característica",-15} | {personaje1.Datos.Nombre,-25} | {personaje2.Datos.Nombre,-25}");
            Inicio.CentrarTexto(new string('-', 80));

            // Mostrar características
            Inicio.CentrarTexto($"{"Tipo",-15} | {personaje1.Datos.Tipo,-25} | {personaje2.Datos.Tipo,-25}");
            Inicio.CentrarTexto($"{"Velocidad",-15} | {personaje1.Caracteristicas.Velocidad,-25} | {personaje2.Caracteristicas.Velocidad,-25}");
            Inicio.CentrarTexto($"{"Destreza",-15} | {personaje1.Caracteristicas.Destreza,-25} | {personaje2.Caracteristicas.Destreza,-25}");
            Inicio.CentrarTexto($"{"Fuerza",-15} | {personaje1.Caracteristicas.Fuerza,-25} | {personaje2.Caracteristicas.Fuerza,-25}");
            Inicio.CentrarTexto($"{"Nivel",-15} | {personaje1.Caracteristicas.Nivel,-25} | {personaje2.Caracteristicas.Nivel,-25}");
            Inicio.CentrarTexto($"{"Protección",-15} | {personaje1.Caracteristicas.Proteccion,-25} | {personaje2.Caracteristicas.Proteccion,-25}");
            Inicio.CentrarTexto($"{"Salud",-15} | {personaje1.Caracteristicas.Salud,-25} | {personaje2.Caracteristicas.Salud,-25}");

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
            int aumentoVelocidad = 1;
            int aumentoDestreza = 1;
            int aumentoFuerza = 1;
            int aumentoNivel = 1;
            int aumentoProteccion = 1;
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
        public static void Atacar(Personaje atacante, Personaje defensor)
        {
            Random random = new Random();
            // Calcular daño
            int ataque = atacante.Caracteristicas.Destreza * atacante.Caracteristicas.Fuerza * atacante.Caracteristicas.Nivel;
            int efectividad = random.Next(5, 101); // Valor aleatorio entre 1 y 100-- al 1 lo cmabie por 5Val
            int defensa = defensor.Caracteristicas.Proteccion * defensor.Caracteristicas.Velocidad;
            int constanteAjuste = 500;
            int danoProvocado = (ataque * efectividad - defensa) / constanteAjuste;

            // Asegurarse de que el daño no exceda 60 y minimamente siempre se realice un daño de 5
            danoProvocado = Math.Min(60, Math.Max(5, danoProvocado));

            // Aplicar daño
            defensor.Caracteristicas.Salud -= danoProvocado;

            // Muestro mensajes 
            // Mostrar mensaje de ataque
            Inicio.CentrarTexto("____________________________________________________");
            Console.WriteLine("");
            Inicio.CentrarTexto($"{atacante.Datos.Nombre} ataca a {defensor.Datos.Nombre}.");
            Console.WriteLine("");
            Inicio.CentrarTexto($"{atacante.Datos.Nombre} inflige {danoProvocado} de daño a {defensor.Datos.Nombre}.");
            Console.WriteLine("");
            Inicio.CentrarTexto("____________________________________________________");
            Thread.Sleep(2000); // Esperar 2 segundos para que el jugador lea el mensaje
        }


        // FUNCION PARA IR MOSTRANDO LA SALUD DE MI PERSONAJE
        public static void MostrarSalud(Personaje jugador, Personaje rival, int cantRonda, int nro)
        {
            Console.Clear(); // Limpiar consola

            // Encabezado
            Console.WriteLine("");
            Console.WriteLine("");

            Inicio.CentrarTexto($"{jugador.Datos.Nombre,-20}  (Tú)    VS    {rival.Datos.Nombre,-20}");
            Inicio.CentrarTexto("_____________________    .    ______________________");
            Console.WriteLine("");
            // Inicio.CentrarTexto(new string('-', 50)); // Línea divisoria


            // Mostrar las barras de salud
            Inicio.CentrarTexto($"  [{DiseñoCombate.MostrarBarraDeSalud(jugador.Caracteristicas.Salud)}]  [{jugador.Caracteristicas.Salud}]  |      [ {DiseñoCombate.MostrarBarraDeSalud(rival.Caracteristicas.Salud)}]      [{rival.Caracteristicas.Salud}]");

            Console.WriteLine("");
            Console.WriteLine("");
        }

        // FUNCION QUE REALIZA TODO EL COMBATE DE UNA RONDA- UNO SALE VICTORIOSO
        public static bool RealizarCombate(Personaje jugador, Personaje rival, int cantRonda, int nro)
        {
            // -------Implemento SONIDO 
            Sonido.ReproducirSonidoLargoBucle(Sonido.SonidoAmbientalPelea);

            Inicio.CentrarTexto("_____________________    .    ______________________");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Inicio.CentrarTexto($"RONDA NRO {nro}/ {cantRonda}");
            Console.WriteLine("");
            Console.ResetColor();
            Inicio.CentrarTexto("_____________________    .    ______________________");
          
            while (jugador.Caracteristicas.Salud > 0 && rival.Caracteristicas.Salud > 0)
            {
                // Mostrar la salud actualizada
                MostrarSalud(jugador, rival, cantRonda, nro);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                // Turno del jugador
                Atacar(jugador, rival);
                Console.ResetColor();
                // Mostrar la salud actualizada
                MostrarSalud(jugador, rival, cantRonda, nro);

                // Verificar si el rival está derrotado
                if (rival.Caracteristicas.Salud <= 0)
                {  Thread.Sleep(1500);
                    Console.Clear(); // Limpiar consola para mostrar el mensaje final
                                     // Inicio.CentrarTexto($"{jugador.Datos.Nombre} ha ganado la ronda!");
                    return true;
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                // Turno del rival
                Atacar(rival, jugador);
                Console.ResetColor();

                // Mostrar la salud actualizada
                MostrarSalud(jugador, rival, cantRonda, nro);

                // Verificar si el jugador está derrotado
                if (jugador.Caracteristicas.Salud <= 0)
                {  Thread.Sleep(1500);
                    Console.Clear(); // Limpiar consola para mostrar el mensaje final
                                     //  Inicio.CentrarTexto($"{rival.Datos.Nombre} ha ganado la ronda!");
                    return false;
                }
            }
            return false;
        }
        // FUNCION PARA RESTAURAR LA SALUD DEL JUGADOR DESPUES DE CADA RONDA 
        public static void RestaurarSalud(Personaje personaje)
        {
            if (personaje != null)
            {
                personaje.Caracteristicas.Salud = 100; // Restaurar salud a 100
            }
        }

    }

}