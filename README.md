# *Proyecto : Juego de Rol*

# ARCANUM: TORNEO DE MAGIA

#### En el legendario Torneo Arcanum hechiceros compiten en duelos mágicos llenos de misterio y desafíos, con un giro cósmico único ¿Quién dominará el arte arcano y ganará el trono del Gran Hechicero?

## Descripción del juego 
Se basa en un juego de rol por turnos donde al comenzar el jugador puede seleccionar un personaje, elige un nivel de dificultad de juego, basado en la cantidad de enemigos a los cuales debe combatir. El jugador se enfrentará a  desafiantes enemigos en duelos que se desarrollarán en distintos planetas del universo, donde cada uno de estos complejiza la partida ya que modifica las habilidades y estrategias de los competidores, añadiendo un elemento de sorpresa a cada batalla.

 Hechicero contra hechicero en una arena mágica, modificada según el planeta. El objetivo es  derrotar a todos los enemigos utilizando habilidades mágicas, y convertirse en el Gran Hechicero. ¿Estás listo para la batalla?

## Sistema de competencia
 - **Combate:** Es por turnos donde un hechicero ataca con un hechizo y el otro defiende con contramagia.El daño puede traducirse en pérdida  de salud mágica.
 - **Eliminacion Directa:**  Los duelos son uno a uno, el ganador avanza a la siguiente ronda y el perdedor es eliminado del torneo, poniéndole  fin al juego.
 - **Dificultad Duelos:** Los jugadores tienen la opción de elegir tres tipos de jugabilidad, Fácil (Vencer a 2 enemigos), Medio (Vencer a 4 enemigos) y Dificil (Vencer a 6 enemigos).
 - **Dificultad Aleatoria:**  El jugador puede elegir el personaje con el que desee comenzar a jugar pero antes de cada duelo, se selecciona aleatoriamente un tipo de planeta que en cada ronda puede beneficiarlo o perjudicarlo.
 - **Modificaciones Planetarias:** Cada planeta tiene características únicas. Por ejemplo, en un  planeta de fuego, los hechizos de fuego son más poderosos, pero los de hielo pierden efectividad.
 - **Personajes:** Cada personaje tendrá en sus caracteristicas valores aleatorios que se irán modificando a medida de que vayan ganando los duelos, incrementándose, o de acuerdo a la dificultad del planeta, creciendo o decreciendo. Sólo las modificaciones realizadas por los planetas no se acumulan a medida que avanza de ronda.


## Implementación

### Funcionamiento del juego
En este juego, el jugador solo selecciona su personaje y el nivel de dificultad. El resto del programa se desarrolla de manera totalmente aleatoria: la generación de personajes con la asignación de características, los enemigos a combatir, el desarrolo de las batallas y los planetas en los que se lleva a cabo cada combate se determinan al azar. Además, proporciona una dificultad de jugabilidad en tres niveles y otorga  navegación eficiente y flexible en el juego con las opciones del menú *Jugar*, *Historial de Ganadores*, *Info de Personajes* y *Salir*.

Cabe destacar el sistema de persistencia de datos que asegura que la información de los personajes del juego se mantenga entre sesiones, tanto para la carga de personajes como para el historial de ganadores. De igual modo, el elemento de sorpresa y variabilidad en cada batalla que ofrece la API empleada es crucial debido a que crea un entorno dinámico que cambia en cada duelo, influyendo directamente en el desarrollo de las batallas.


### Uso de API en el proyecto
 Este proyecto hace uso de la API [Planetas](https://swapi.dev/api/planets/?format=api)  del sitio [SWAPI](https://swapi.dev/api/) para crear entornos planetarios aleatorios que añaden una dimensión única a cada duelo. 
  La API elegida genera datos JSON detallados sobre diferentes planetas, proporcionando información  sobre sus características. Sin embargo,  aunque los datos que me proporciona son muy completos, trabajaremos principalmente con las propiedades del clima, terreno y gravedad para modificar las habilidades y estrategias de los hechiceros en cada duelo.
  Entre sus datos incluye: 

  - Nombre del planeta: La denominación única del planeta.
  - Período de rotación: El tiempo que tarda el planeta en girar sobre su propio eje.
  - Período orbital: La duración de una órbita completa del planeta alrededor de su estrella.
  - Diámetro: El tamaño del planeta.
  - Clima: Las condiciones climáticas predominantes en el planeta.
  - Gravedad: La fuerza gravitatoria del planeta.
  - Terreno: Las características geográficas del planeta.
  - Agua superficial: El porcentaje de superficie cubierta por agua.
  - Población: La cantidad de habitantes en el planeta.
  - Residentes y películas: Referencias a personajes y eventos asociados con el planeta.
  - Tiempos de creación y edición: Registros de cuándo se crearon y actualizaron los datos.
  - URL: Enlace directo a más información sobre el planeta.

### Otros recursos utilizados
 #### Manejo de API
 Al momento de buscar la API para el proyecto, las páginas que usé para facilitarme la lectura del contenido de las mismas, así como para su conversión de JSON a C# fueron:
 [https://jsonviewer.stack.hu/] 
 [https://json2csharp.com/]

 #### Presentación Visual
 Para mejorar la presentación del proyecto agregué títulos con texto ASCII que aparecen en momentos específicos del juego , todos ellos realizados en la página: [https://www.topster.es/texto-ascii/]. También, añadí detalles relacionados al contexto del juego, la magia, mediante la utilización de símbolos obtenidos en: [https://www.letrasbonitas.art/p/star-decorated-letras-bonitas.html] y en [https://www.caracteresespeciales.com/l%C3%ADnea-caracteres-especiales.html]

 #### Sonido
 Para mejorar la experiencia del jugador, agregué diferentes sonidos para momentos específicos de la partida y algunos también  vinculados a la tématica de magia del juego, estos aparecerán a lo largo de toda la partida. 
 Para la descarga de los sonidos en formato MP3 hice uso de la página: [https://pixabay.com/es/sound-effects/search/magia/]
 Con la finalidad de agregar los archivos de audios a mi juego, empleé la clase SoundPlayer contenida en el namespace System.Media. Este sólo trabaja con el formato de audio (.WAV) en aplicaciones .NET y sólo es admitidos en sistemas Windows, resaltando tras esto varias adventencias en el código y algunas veces al compilar el juego.
 Convertí los archivos de audio de formato MP3 a .WAV con las páginas: [https://convertio.co/es/mp3-wav/] y [https://www.freeconvert.com/es/mp3-to-wav]
 Asimismo recorté y modifiqué algunos audios en el sitio: [https://vocalremover.org/es/cutter]

 #### Inteligencia Artificial
Con este recurso logré implementar en mi juego diversos efectos de los cuales no tenía el conocimiento de su desarrollo. Asimismo, fue de gran inspiración para algunas frases y nombres que aparecen durante el juego, y para evitar el escribir códigos repetitivos en el programa.
Los usos significativos fueron la presentación visual de tablas de comparaciones entre los personajes, efecto en la visualización de la salud  durante las batallas  , el contador de tiempo antes de cada ronda, funciones para el centrado de textos, su aparición progresiva , efectos de titilación en los mismos y la apariencia en la elección de opciones en el menú principal.  

#### Estructura del Programa
El programa consta en su organización de  varias carpetas, cada una de las cuales trata una parte diferente del programa general. La estructura es la siguiente:

- **Personajes**: Contiene dos archivos, *Personajes* para agrupar todo lo relacionado a la definición y características de los mismos en el juego (Datos y Caracteríticas), y *Fábrica de Personajes* con una clase llamada de igual manera, la cuál contiene métodos para crear los competidores con todas sus características aleatorias.

- **API**: Almacena dos archivos para el manejo de la misma, *PlanetasAPi* contiene la copia de la API tras su conversión de formato JSON a C#,es decir cuenta con las clases necesarias para deserializar los datos de una API que proporciona información sobre planetas. Además contiene a *ConsumoAPI*, el código necesario  para realizar solicitudes a la API y procesar la respuesta, obteniendo una lista de planetas y sus características, que luego se deserializa para su uso en el juego.

- **Persistencia Data**: Maneja la persistencia del juego con sus archivos *PersonajeJson* y *HistorialJSon*. Ambas clases cuentan con tres métodos importantes para el manejo de Json: [Guadar] datos en un archivo JSON, [Leer] datos desde un archivo JSON y [Existe] para verificar si el archivo JSON dado existe y tiene datos, utilizando así la serialización y deserialización de JSON para almacenar y recuperar información, asegurando que los datos del juego se mantengan entre sesiones

- **Data**: Contiene los archivos resultado del haber trabajado la persistencia de los datos entre sesiones del juego, *historialGanadores.json* contiene la información de las victorias de los jugadores y *personajes.json* el resultado de serializar los datos de los personajes del juego. Ambos sirven para registrar y recuperar la información. 

- **Diseño**: Guarda cuatro diferentes archivos que se encargan exclusivante de mejorar la estética del juego en diferentes aspectos. Incluye todos los textos empleados, dibujos , diseños en los títulos, tablas , menú y el archivo para la implementación del sonido. 

- **Escenas**: Almacena las funcionalidades  más importantes, necesarias para el desarrollo y fluidez del juego. *Inicio*, *Combate* y *JuegoSegunDificultad* guardan los métodos más significativos  conectándose entre sí para dirigir el flujo del juego en sus distintas fases. *AuxCombate* y *AuxInicioYJuego* guardan todos los métodos auxiliares que son el soporte para las tareas principales. 

- **Sonidos**: Guarda todos los archivos de audios en formato .wav que se implementan en el juego.

- **Archivo Program.cs**: Punto de entrada del juego. Gestiona el inicio y la ejecución del mismo.


### ¿Cómo ejecutar el juego?
 - Teniendo .NET versión 8.0 instalado en tu computadora, en la terminal o consola del sistema operativo que estés usando debes clonar el repositorio:

  ```bash
  git clone https://github.com/TallerDeLenguajes1/tl1-proyectofinal2024-vale97408.git
  ```

 - Para ejecutar el juego, usa la terminal o consola del sistema operativo. Navega a la carpeta del proyecto y ejecuta el siguiente comando adecuado para el entorno .NET Core:

 ```bash
  dotnet run
```





### Datos Personales

- **Alumna** : Cano Arce, María Valentina.

- **Carrera** : Ingeniería en Informática.


