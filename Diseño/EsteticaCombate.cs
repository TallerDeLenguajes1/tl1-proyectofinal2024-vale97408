using System;
using System.Threading;
using Personajes;
using Fabrica;

namespace Proyecto
{
    public class DiseñoCombate
    {



        public static string MostrarBarraDeSalud(int salud)
        {

            // Asegúrate de que la salud no sea menor que 0
            salud = Math.Max(salud, 0);

            // Calcular el número de símbolos completos
            int simbolosCompletos = salud / 10;

            // Calcular el resto de la salud
            int resto = salud % 10;

            // Crear la barra de salud
            string barra = new string('⬤', simbolosCompletos); // Símbolos completos

            // Agregar el símbolo para la parte restante
            if (resto >= 6)
            {
                barra += "◉";
            }
            else if (resto >= 1)
            {
                barra += "〇";
            }
            return barra;
        }

        public static Personaje CopiarPersonaje(Personaje original)
        {
            return new Personaje
            {
                Datos = new Datos
                {
                    Nombre = original.Datos.Nombre,
                    Tipo = original.Datos.Tipo
                },
                Caracteristicas = new Caracteristicas
                {
                    Velocidad = original.Caracteristicas.Velocidad,
                    Destreza = original.Caracteristicas.Destreza,
                    Fuerza = original.Caracteristicas.Fuerza,
                    Nivel = original.Caracteristicas.Nivel,
                    Proteccion = original.Caracteristicas.Proteccion,
                    Salud = original.Caracteristicas.Salud
                }
            };
        }

        public static string CalcularCambio(int valorOriginal, int valorModificado)
        {
            // Calcular la diferencia
            int cambio = valorModificado - valorOriginal;

            // Formatear el cambio con signo
            if (cambio > 0)
            {
                return $"+{cambio}";
            }
            else
            {
                if (cambio < 0)
                {
                    return $"{cambio}"; // el signo negativo se incluye automáticamente
                }
                else
                {
                    return "0"; // Sin cambio
                }
            }

        }

        public static void MostrarComparacionPersonajesCambios(Personaje jugadorOriginal, Personaje jugadorModificado, Personaje rivalOriginal, Personaje rivalModificado)
        {
            // Definir los anchos fijos para las columnas
            const int anchoCaracteristica = 20;
            const int anchoValor = 25;
            const int anchoCambio = 15;

            // Determinar el ancho total de la tabla
            int anchoTotal = anchoCaracteristica + anchoValor * 2 + anchoCambio * 2 + 10; // Espacios adicionales para separadores

            // Imprimir encabezado de la tabla
            Inicio.CentrarTexto(new string('-', anchoTotal + 10));

            // Encabezados
            Inicio.CentrarTexto($"{"Característica".PadRight(anchoCaracteristica)} | {jugadorModificado.Datos.Nombre.PadRight(anchoValor)} | {"Cambio".PadRight(anchoCambio)} | {rivalModificado.Datos.Nombre.PadRight(anchoValor)} | {"Cambio".PadRight(anchoCambio)}");
            Inicio.CentrarTexto(new string('-', anchoTotal + 10));

            // Mostrar características con cambios para el jugador
            // Alineación para el tipo de hechicero
            string tipoJugador = jugadorModificado.Datos.Tipo.ToString().PadRight(anchoValor);
            string tipoRival = rivalModificado.Datos.Tipo.ToString().PadRight(anchoValor);

            Inicio.CentrarTexto($"{"Tipo".PadRight(anchoCaracteristica)} | {tipoJugador} | {"-".PadLeft(anchoCambio)} | {tipoRival} | {"-".PadLeft(anchoCambio)}"); // Tipo no cambia
            Inicio.CentrarTexto($"{"Velocidad".PadRight(anchoCaracteristica)} | {jugadorModificado.Caracteristicas.Velocidad.ToString().PadRight(anchoValor)} | {CalcularCambio(jugadorOriginal.Caracteristicas.Velocidad, jugadorModificado.Caracteristicas.Velocidad).PadLeft(anchoCambio)} | {rivalModificado.Caracteristicas.Velocidad.ToString().PadRight(anchoValor)} | {CalcularCambio(rivalOriginal.Caracteristicas.Velocidad, rivalModificado.Caracteristicas.Velocidad).PadLeft(anchoCambio)}");
            Inicio.CentrarTexto($"{"Destreza".PadRight(anchoCaracteristica)} | {jugadorModificado.Caracteristicas.Destreza.ToString().PadRight(anchoValor)} | {CalcularCambio(jugadorOriginal.Caracteristicas.Destreza, jugadorModificado.Caracteristicas.Destreza).PadLeft(anchoCambio)} | {rivalModificado.Caracteristicas.Destreza.ToString().PadRight(anchoValor)} | {CalcularCambio(rivalOriginal.Caracteristicas.Destreza, rivalModificado.Caracteristicas.Destreza).PadLeft(anchoCambio)}");
            Inicio.CentrarTexto($"{"Fuerza".PadRight(anchoCaracteristica)} | {jugadorModificado.Caracteristicas.Fuerza.ToString().PadRight(anchoValor)} | {CalcularCambio(jugadorOriginal.Caracteristicas.Fuerza, jugadorModificado.Caracteristicas.Fuerza).PadLeft(anchoCambio)} | {rivalModificado.Caracteristicas.Fuerza.ToString().PadRight(anchoValor)} | {CalcularCambio(rivalOriginal.Caracteristicas.Fuerza, rivalModificado.Caracteristicas.Fuerza).PadLeft(anchoCambio)}");
            Inicio.CentrarTexto($"{"Nivel".PadRight(anchoCaracteristica)} | {jugadorModificado.Caracteristicas.Nivel.ToString().PadRight(anchoValor)} | {CalcularCambio(jugadorOriginal.Caracteristicas.Nivel, jugadorModificado.Caracteristicas.Nivel).PadLeft(anchoCambio)} | {rivalModificado.Caracteristicas.Nivel.ToString().PadRight(anchoValor)} | {CalcularCambio(rivalOriginal.Caracteristicas.Nivel, rivalModificado.Caracteristicas.Nivel).PadLeft(anchoCambio)}");
            Inicio.CentrarTexto($"{"Protección".PadRight(anchoCaracteristica)} | {jugadorModificado.Caracteristicas.Proteccion.ToString().PadRight(anchoValor)} | {CalcularCambio(jugadorOriginal.Caracteristicas.Proteccion, jugadorModificado.Caracteristicas.Proteccion).PadLeft(anchoCambio)} | {rivalModificado.Caracteristicas.Proteccion.ToString().PadRight(anchoValor)} | {CalcularCambio(rivalOriginal.Caracteristicas.Proteccion, rivalModificado.Caracteristicas.Proteccion).PadLeft(anchoCambio)}");
            Inicio.CentrarTexto($"{"Salud".PadRight(anchoCaracteristica)} | {jugadorModificado.Caracteristicas.Salud.ToString().PadRight(anchoValor)} | {CalcularCambio(jugadorOriginal.Caracteristicas.Salud, jugadorModificado.Caracteristicas.Salud).PadLeft(anchoCambio)} | {rivalModificado.Caracteristicas.Salud.ToString().PadRight(anchoValor)} | {CalcularCambio(rivalOriginal.Caracteristicas.Salud, rivalModificado.Caracteristicas.Salud).PadLeft(anchoCambio)}");

            // Imprimir línea divisoria final
            Inicio.CentrarTexto(new string('-', anchoTotal + 10));
        }


        public static void MostrarMejoraPersonaje(Personaje personajeOriginal, Personaje personajeMejorado)
        {
            // Definir los anchos fijos para las columnas
            const int anchoCaracteristica = 20;
            const int anchoValor = 25;
            const int anchoCambio = 15;

            // Determinar el ancho total de la tabla
            int anchoTotal = anchoCaracteristica + anchoValor * 2 + anchoCambio + 10; // Espacios adicionales para separadores

            // Imprimir encabezado de la tabla
            Inicio.CentrarTexto(new string('-', anchoTotal + 10));

            // Encabezados
            Inicio.CentrarTexto($"{"Característica".PadRight(anchoCaracteristica)} | {personajeMejorado.Datos.Nombre.PadRight(anchoValor)} | {"Mejora ".PadRight(anchoCambio)}");
            Inicio.CentrarTexto(new string('-', anchoTotal + 10));

            // Mostrar características con mejoras para el personaje
            // Alineación para el tipo de hechicero
            string tipo = personajeMejorado.Datos.Tipo.ToString().PadRight(anchoValor);

            Inicio.CentrarTexto($"{"Tipo".PadRight(anchoCaracteristica)} | {tipo} | {"-".PadLeft(anchoCambio)}"); // Tipo no cambia
            Inicio.CentrarTexto($"{"Velocidad".PadRight(anchoCaracteristica)} | {personajeMejorado.Caracteristicas.Velocidad.ToString().PadRight(anchoValor)} | {CalcularCambio(personajeOriginal.Caracteristicas.Velocidad, personajeMejorado.Caracteristicas.Velocidad).PadLeft(anchoCambio)}");
            Inicio.CentrarTexto($"{"Destreza".PadRight(anchoCaracteristica)} | {personajeMejorado.Caracteristicas.Destreza.ToString().PadRight(anchoValor)} | {CalcularCambio(personajeOriginal.Caracteristicas.Destreza, personajeMejorado.Caracteristicas.Destreza).PadLeft(anchoCambio)}");
            Inicio.CentrarTexto($"{"Fuerza".PadRight(anchoCaracteristica)} | {personajeMejorado.Caracteristicas.Fuerza.ToString().PadRight(anchoValor)} | {CalcularCambio(personajeOriginal.Caracteristicas.Fuerza, personajeMejorado.Caracteristicas.Fuerza).PadLeft(anchoCambio)}");
            Inicio.CentrarTexto($"{"Nivel".PadRight(anchoCaracteristica)} | {personajeMejorado.Caracteristicas.Nivel.ToString().PadRight(anchoValor)} | {CalcularCambio(personajeOriginal.Caracteristicas.Nivel, personajeMejorado.Caracteristicas.Nivel).PadLeft(anchoCambio)}");
            Inicio.CentrarTexto($"{"Protección".PadRight(anchoCaracteristica)} | {personajeMejorado.Caracteristicas.Proteccion.ToString().PadRight(anchoValor)} | {CalcularCambio(personajeOriginal.Caracteristicas.Proteccion, personajeMejorado.Caracteristicas.Proteccion).PadLeft(anchoCambio)}");
            Inicio.CentrarTexto($"{"Salud".PadRight(anchoCaracteristica)} | {personajeMejorado.Caracteristicas.Salud.ToString().PadRight(anchoValor)} | {CalcularCambio(personajeOriginal.Caracteristicas.Salud, personajeMejorado.Caracteristicas.Salud).PadLeft(anchoCambio)}");

            // Imprimir línea divisoria final
            Inicio.CentrarTexto(new string('-', anchoTotal + 10));
        }







    }
}