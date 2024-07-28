# -----Proyecto : Juego de Rol------
# ----------ARCANUM: TORNEO DE MAGIA-------------

#### En el legendario Torneo Arcanum hechiceros compiten en duelos mágicos llenos de misterio y desafíos, con un giro cósmico único ¿Quién dominará el arte arcano y ganará el trono del Gran Hechicero?

## Descripción del juego 
 Es un juego de rol por turnos que permite seleccionar un personaje y enfrentarse a una serie de diez desafiantes enemigos en duelos que se desarrollan en distintos planetas del universo. Cada planeta modifica las habilidades y estrategias de los competidores, añadiendo un elemento de sorpresa a cada batalla.
 Hechicero contra hechicero en una arena mágica, modificada según el planeta. El objetivo es  derrotar a todos los enemigos utilizando habilidades mágicas, y convertirse en el Gran Hechicero. ¿Estás listo para la batalla?

## Sistema de competencia
 - **Combate:** Es por turnos donde un hechicero ataca con un hechizo y el otro defiende con contramagia, eligiendo sus acciones, como atacar, defenderse o usar habilidades especiales. El daño puede traducirse en pérdida  de salud mágica o resistencia.
 - **Eliminacion Directa:**  Los duelos son uno a uno, el ganador avanza a la siguiente ronda y el perdedor es eliminado del torneo, poniéndole  fin al juego.
 - **Dificultad Aleatoria:**  El jugador puede elegir el personaje con el que desee empezar a jugar pero antes de cada duelo, se selecciona aleatoriamente un tipo de un planeta que en cada ronda puede beneficiarlo o perjudicarlo.
 - **Modificaciones Planetarias:** Cada planeta tiene caracteristicas únicas. Por ejemplo, en un  planeta de fuego, los hechizos de fuego son más poderosos, pero los de hielo pierden efectividad.
 - **Personajes:** Cada personaje tendrá en sus caracteristicas valores aleatorios de vida, velocidad, que a medida de que vayan ganando los duelos, irán avanzando de niveles e incrementando sus habilidades de acuerdo a la dificultad del planeta y la dificultad del enemigo.


## Implementación

### Uso de API en el proyecto
 Este proyecto hace uso de la API [Planetas] (https://swapi.dev/api/planets/?format=api)  del sitio [SWAPI] (https://swapi.dev/api/) para crear entornos planetarios aleatorios que añaden una dimensión única a cada duelo. 
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
