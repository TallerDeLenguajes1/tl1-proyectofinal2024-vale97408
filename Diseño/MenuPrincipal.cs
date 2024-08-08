using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Json;

namespace Proyecto
{
    public class MenuPrincipal
    {
        string [] opciones; 
        int eleccion;
        public MenuPrincipal(string [] Opciones)
        {
            opciones = Opciones;
            eleccion=0; 
        }


        private  void MostrarOpciones(string[] opciones)
        {    
             Console.WriteLine("  ");
             Console.WriteLine("  ");
            Inicio.CentrarTexto("          `✵•.¸,✵°✵.｡.✰    𝐌 𝐄 𝐍 𝐔  𝐏 𝐑 𝐈 𝐍 𝐂 𝐈 𝐏 𝐀 𝐋   ✰.｡.✵°✵,¸.•✵´");
            Console.WriteLine("  ");
            
             Console.ResetColor();
             for (int i = 0; i < opciones.Length; i++)
             {
                if(i == eleccion)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Inicio.CentrarTexto($" {opciones[i]}");
             }
             Console.ResetColor();
        }
         public int Display()
        {
            ConsoleKeyInfo teclaPresionada;
            do
            {
                Console.Clear();
                MostrarOpciones(opciones);
                teclaPresionada = Console.ReadKey(true);

                switch (teclaPresionada.Key)
                {
                    case ConsoleKey.DownArrow:
                        eleccion = eleccion == opciones.Length-1 ? 0: eleccion+1;
                        break;
                    case ConsoleKey.UpArrow:
                        eleccion = eleccion == 0 ? opciones.Length-1: eleccion-1;
                        break;
                }

            } while (teclaPresionada.Key != ConsoleKey.Enter);
            return eleccion;
        }
    }
}
