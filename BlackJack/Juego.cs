using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Juego
    {
        public Juego()
        {
            
        }
        public void Lanzar()
        {
            //Region donde se crean objetos y variables.
            #region "Variables" 
            Console.WriteLine("Baraja con la que se va a jugar:");
            Baraja baraja = new Baraja();
            Jugador jugador = new Jugador(baraja);

            #endregion 



            #region "Resultado"
            if (jugador.puntuacionJugador <= 21) //Si la puntuación del jugador es menor o igual a 21, empieza el turno de la IA.
            {
                Banca jugadorIA = new Banca(baraja); //Se crea un objeto de tipo Banca y se llama a su constructor usando la baraja.
                if (jugador.puntuacionJugador == jugadorIA.puntuacionIA) //Si ambas puntuaciones son las mismas, gana la IA.
                {
                    Console.WriteLine("Empate, gana la IA");
                }
                else if (jugadorIA.puntuacionIA > 21) //Si la IA se pasa de 21, gana el jugador.
                {
                    Console.WriteLine("La IA ha pasado de los 21 puntos ({0})", jugadorIA.puntuacionIA);
                    Console.WriteLine("El ganador es {0}", jugador.nombre);
                }
                else if(jugadorIA.puntuacionIA == 21) //Si la puntuación de la IA es de 21, gana la IA.
                {
                    Console.WriteLine("La IA ha conseguido 21 puntos, gana la IA");
                }
                else if (jugador.puntuacionJugador == 21)
                {
                    Console.WriteLine("El jugador ha conseguido 21 puntos, el ganador es {0}", jugador.nombre);
                }

            }


            else if(jugador.puntuacionJugador > 21)
            {
                Console.WriteLine("El jugador ha pasado de los 21 puntos ({0})", jugador.puntuacionJugador);
                Console.WriteLine("Gana la IA");
            }
            #endregion

        }

    }


}
