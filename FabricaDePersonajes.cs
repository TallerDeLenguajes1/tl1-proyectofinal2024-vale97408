// Implemento clases para poder crear personajes aleatorios

namespace Personajes
{
    // using System;
    //using System.Collections.Generic;


    public enum TipoPersonaje
    {
        HechiceroDeFuego,
        HechiceroDeHielo,
        HechiceroDeLaNaturaleza,
        HechiceroDeLasSombras,
        HechiceroDeLuz
    }

    public class Personaje
    {
        // Datos
        public string Nombre { get; set; }
        public string Apodo { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public int Edad { get; set; }
        public TipoPersonaje Tipo { get; set; }

        // Características
        public int Velocidad { get; set; }
        public int Destreza { get; set; }
        public int Fuerza { get; set; }
        public int Nivel { get; set; }
        public int Armadura { get; set; }
        public int Salud { get; set; }
    }

    public class FabricaDePersonajes
    {
        private static Random random = new Random();

        public List<Personaje> GeneradorDePersonajes(List<string> nombres)
        {
            List<Personaje> listaDePersonajes = new List<Personaje>();
            foreach (var nombre in nombres)
            {
                Personaje personaje = new Personaje
                {
                    Nombre = nombre,
                    Apodo = GenerarApodoAleatorio(),
                    FechaDeNacimiento = GenerarFechaDeNacimientoAleatoria(),
                    Edad = CalcularEdad(GenerarFechaDeNacimientoAleatoria()),
                    Tipo = (TipoPersonaje)random.Next(0, 5),
                    Salud = 100
                };

                AsignarCaracteristicas(personaje);
                listaDePersonajes.Add(personaje);
            }
            return listaDePersonajes;
        }

        private void AsignarCaracteristicas(Personaje personaje)
        {
            switch (personaje.Tipo)
            {
                case TipoPersonaje.HechiceroDeFuego:
                    personaje.Velocidad = random.Next(1, 11);
                    personaje.Destreza = random.Next(1, 6);
                    personaje.Fuerza = random.Next(5, 11);
                    personaje.Nivel = random.Next(1, 11);
                    personaje.Armadura = random.Next(3, 8);
                    break;
                case TipoPersonaje.HechiceroDeHielo:
                    personaje.Velocidad = random.Next(1, 8);
                    personaje.Destreza = random.Next(4, 6);
                    personaje.Fuerza = random.Next(3, 8);
                    personaje.Nivel = random.Next(1, 11);
                    personaje.Armadura = random.Next(5, 11);
                    break;
                case TipoPersonaje.HechiceroDeLaNaturaleza:
                    personaje.Velocidad = random.Next(3, 10);
                    personaje.Destreza = random.Next(2, 6);
                    personaje.Fuerza = random.Next(4, 9);
                    personaje.Nivel = random.Next(1, 11);
                    personaje.Armadura = random.Next(4, 10);
                    break;
                case TipoPersonaje.HechiceroDeLasSombras:
                    personaje.Velocidad = random.Next(4, 10);
                    personaje.Destreza = random.Next(3, 6);
                    personaje.Fuerza = random.Next(2, 8);
                    personaje.Nivel = random.Next(1, 11);
                    personaje.Armadura = random.Next(2, 8);
                    break;
                case TipoPersonaje.HechiceroDeLuz:
                    personaje.Velocidad = random.Next(2, 9);
                    personaje.Destreza = random.Next(4, 6);
                    personaje.Fuerza = random.Next(3, 8);
                    personaje.Nivel = random.Next(1, 11);
                    personaje.Armadura = random.Next(6, 11);
                    break;
            }
        }

        private string GenerarApodoAleatorio()
        {
            string[] apodos = { "El Fulgor", "El Sombra", "El Sabio", "El Destructor", "El Sanador" };
            return apodos[random.Next(apodos.Length)];
        }

        private DateTime GenerarFechaDeNacimientoAleatoria()
        {
            int year = random.Next(DateTime.Now.Year - 300, DateTime.Now.Year);
            int month = random.Next(1, 13);
            int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            return new DateTime(year, month, day);
        }

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

 

