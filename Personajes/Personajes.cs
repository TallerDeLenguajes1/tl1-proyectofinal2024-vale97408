namespace Personajes
{

    public class Personaje
    {
        private Datos datos;
        private Caracteristicas caracteristicas;

        public Personaje()
        {
            datos = new Datos();
            caracteristicas = new Caracteristicas();
        }

        public Datos Datos { get => datos; set => datos = value; }
        public Caracteristicas Caracteristicas { get => caracteristicas; set => caracteristicas = value; }
    }

    public enum TipoPersonaje
    {
        HechiceroDeFuego,
        HechiceroDeHielo,
        HechiceroDeLaNaturaleza,
        HechiceroDeLasSombras,
        HechiceroDeLuz
    }

    public class Datos
    {
        private string nombre;
        private string apodo;
        private  DateTime fechaDeNacimiento;
        private int edad;
        private TipoPersonaje tipo;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }
        public TipoPersonaje Tipo { get => tipo; set => tipo = value; }
    }

    public class Caracteristicas
    {
        private int velocidad;
        private int destreza;
        private int fuerza;
        private int nivel;
        private int armadura;
        private int salud;

        public Caracteristicas()
        {
            // Me lo dio en mayusculas
            Velocidad = 0;
            Destreza = 0;
            Fuerza = 0;
            Nivel = 0;
            Armadura = 0;
            Salud = 0;
        }

        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int Salud { get => salud; set => salud = value; }
    }
    
}