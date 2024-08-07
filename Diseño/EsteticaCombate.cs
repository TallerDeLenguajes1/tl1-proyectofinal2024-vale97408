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


    
    }
}