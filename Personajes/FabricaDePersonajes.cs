// Implemento clases para poder crear personajes aleatorios
using System;
using System.Collections.Generic;
using Personajes;

namespace Fabrica
{
    public class FabricaDePersonajes
    {
        private static Random random = new Random();

        // Método principal para generar una lista de personajes
        public List<Personaje> GeneradorDePersonajes(List<string> nombres)
        {
            List<Personaje> listaDePersonajes = new List<Personaje>();

            foreach (var nombre in nombres)
            {
                Personaje personaje = CrearPersonaje(nombre);
                AsignarCaracteristicas(personaje);
                listaDePersonajes.Add(personaje);
            }
            return listaDePersonajes;
        }

        // Método para crear un personaje con datos iniciales
        private Personaje CrearPersonaje(string nombre)
        {
            Personaje personaje = new Personaje
            {
                Datos = new Datos
                {
                    Nombre = nombre,
                    Apodo = GenerarApodoAleatorio(),
                    FechaDeNacimiento = GenerarFechaDeNacimientoAleatoria(),
                    Edad = CalcularEdad(GenerarFechaDeNacimientoAleatoria()),
                    Tipo = (TipoPersonaje)random.Next(0, 5)
                },
                Caracteristicas = new Caracteristicas
                {
                    Salud = 100 // Valor inicial de salud
                }
            };

            return personaje;
        }

        // Método para asignar características según el tipo de personaje
        private void AsignarCaracteristicas(Personaje personaje)
        {
            switch (personaje.Datos.Tipo)
            {
                case TipoPersonaje.HechiceroDeFuego:
                    personaje.Caracteristicas.Velocidad = random.Next(1, 11);
                    personaje.Caracteristicas.Destreza = random.Next(1, 6);
                    personaje.Caracteristicas.Fuerza = random.Next(5, 11);
                    personaje.Caracteristicas.Nivel = random.Next(1, 11);
                    personaje.Caracteristicas.Armadura = random.Next(3, 8);
                    break;
                case TipoPersonaje.HechiceroDeHielo:
                    personaje.Caracteristicas.Velocidad = random.Next(1, 8);
                    personaje.Caracteristicas.Destreza = random.Next(4, 6);
                    personaje.Caracteristicas.Fuerza = random.Next(3, 8);
                    personaje.Caracteristicas.Nivel = random.Next(1, 11);
                    personaje.Caracteristicas.Armadura = random.Next(5, 11);
                    break;
                case TipoPersonaje.HechiceroDeLaNaturaleza:
                    personaje.Caracteristicas.Velocidad = random.Next(3, 10);
                    personaje.Caracteristicas.Destreza = random.Next(2, 6);
                    personaje.Caracteristicas.Fuerza = random.Next(4, 9);
                    personaje.Caracteristicas.Nivel = random.Next(1, 11);
                    personaje.Caracteristicas.Armadura = random.Next(4, 10);
                    break;
                case TipoPersonaje.HechiceroDeLasSombras:
                    personaje.Caracteristicas.Velocidad = random.Next(4, 10);
                    personaje.Caracteristicas.Destreza = random.Next(3, 6);
                    personaje.Caracteristicas.Fuerza = random.Next(2, 8);
                    personaje.Caracteristicas.Nivel = random.Next(1, 11);
                    personaje.Caracteristicas.Armadura = random.Next(2, 8);
                    break;
                case TipoPersonaje.HechiceroDeLuz:
                    personaje.Caracteristicas.Velocidad = random.Next(2, 9);
                    personaje.Caracteristicas.Destreza = random.Next(4, 6);
                    personaje.Caracteristicas.Fuerza = random.Next(3, 8);
                    personaje.Caracteristicas.Nivel = random.Next(1, 11);
                    personaje.Caracteristicas.Armadura = random.Next(6, 11);
                    break;
            }
        }

        // Método para generar un apodo aleatorio
        private string GenerarApodoAleatorio()
        {
            string[] apodos = { "El Fulgor", "El Sombra", "El Sabio", "El Destructor", "El Sanador" };
            return apodos[random.Next(apodos.Length)];
        }

        // Método para generar una fecha de nacimiento aleatoria
        private DateTime GenerarFechaDeNacimientoAleatoria()
        {
            int year = random.Next(DateTime.Now.Year - 300, DateTime.Now.Year);
            int month = random.Next(1, 13);
            int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            return new DateTime(year, month, day);
        }

        // Método para calcular la edad a partir de la fecha de nacimiento
        private int CalcularEdad(DateTime fechaDeNacimiento)
        {
            int edad = DateTime.Now.Year - fechaDeNacimiento.Year;
            if (DateTime.Now.DayOfYear < fechaDeNacimiento.DayOfYear)
            {
                edad--;
            }
            return edad;
        }
    }
}
