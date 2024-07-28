namespace Juego
{

    public class FabricaDePersonajes
    {
        public List<Personaje> GeneradorDePersonajes(List<string> Nombres)
        {
            List<Personaje> ListaDePersonajes = new List<Personaje>();
            var semilla = Environment.TickCount;
            var random = new Random(semilla); 
            foreach (var nombre in Nombres)
            {
                Personaje personaje = new Personaje();
                personaje.Nombre = nombre;
                personaje.Distrito = random.Next(1,12);
                personaje.Tipo = (TipoPersonaje)random.Next(0,4);
                personaje.PuntuacionPrevia = random.Next(1,13);
                personaje.Salud = 100;
                switch (personaje.Tipo)
                {
                        case TipoPersonaje.Intelectual:
                            personaje.Velocidad = random.Next(1,7);
                            personaje.Armadura = random.Next(6,11);
                            personaje.Destreza = random.Next(1,6);
                            personaje.Fuerza = random.Next(1,6);
                            break;
                        case TipoPersonaje.Agresivo:
                            personaje.Velocidad = random.Next(4,9);
                            personaje.Armadura = random.Next(7,11);
                            personaje.Destreza = random.Next(1,6);
                            personaje.Fuerza = random.Next(5,11);
                            break;
                        case TipoPersonaje.Habil:
                            personaje.Velocidad = random.Next(5,11);
                            personaje.Armadura = random.Next(1,11);
                            personaje.Destreza = random.Next(3,6);
                            personaje.Fuerza = random.Next(5,11);
                            break;
                        case TipoPersonaje.Fuerte:
                            personaje.Velocidad = random.Next(1,11);
                            personaje.Armadura = random.Next(5,11);
                            personaje.Destreza = random.Next(1,6);
                            personaje.Fuerza = random.Next(8,11);
                            break;

                }
                ListaDePersonajes.Add(personaje);
                
            }
            return ListaDePersonajes;

        }


    }
}