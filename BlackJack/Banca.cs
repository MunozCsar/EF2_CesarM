using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BlackJack
{
    class Banca : Jugador
    {
        #region "ConstructorBanca"
        public Banca(Baraja baraja)
        {
            Turno(baraja);
        }
        #endregion

        public int puntuacionIA;
        #region "LogicaIA"
        public override void Turno(Baraja baraja) //Uso de la funcion override para cambiar el código de Turno.
        {
            Console.WriteLine("Turno de la IA");
            Thread.Sleep(500);

            for (int i = 0; i < 2; i++)
            {
                mano.Add(baraja.RepartirCarta()); //Se llama la función RepartirCarta de Baraja y se añade el resultado a la lista mano.
            }

            while (puntuacionIA < 21) //Mientras la puntuación de la IA sea menor a 21, seguirá robando cartas.
            {
                Console.WriteLine("La IA robado {0} cartas", mano.Count);
                MostrarMano(); //Muestra la mano de la IA.
                SumarMano(); //Suma la puntuación de la IA.
                mano.Add(baraja.RepartirCarta());
                
            }
        }
        #endregion

        #region "Mano"
        public override void MostrarMano() //Uso de la funcion override para cambiar el código de MostrarMano.
        {
            Console.Write("Mano de la IA: ");
            for (int i = 0; i < mano.Count; i++) //Bucle for que se repite tantas veces como cartas tenga la mano.
            {
                Console.Write("{0}{1}", mano[i].palo, mano[i].valor); //Escribe por pantalla el valor de la variable palo y valor de Carta.
                Console.Write(" ");
                Thread.Sleep(250);


            }
        }
        public override int SumarMano() //Uso de la funcion override para cambiar el código de SumarMano.
        {
            puntuacionIA = 0; //Al iniciar la función, se iguala la puntuación a 0.
            Console.WriteLine();
            for (int i = 0; i < mano.Count; i++) //Bucle for que se repite tantas veces como cartas tenga la mano.
            {

                if (mano[i].valor.Equals("A")) //Condicional if que detecta si el valor de la carta es "A".
                {
                    if (puntuacionIA + 11 > 21) //Condicional if que detecta si la puntuación actual del jugador + 11 (El valor inicial de A) supera 21, si lo hace, cambia el valor de A a 1.
                    {
                        mano[i].isEleven = false;
                    }
                    else //En caso de que no se supere 21, A se mantiene en 11.
                    {
                        mano[i].isEleven = true;
                    }
                }
                puntuacionIA += mano[i].GetPuntuacion(mano[i].valor); //Se suma a puntuaciónIA el valor de la mano usando la función GetPuntuación.

            }
            Console.WriteLine("Tu mano suma {0} puntos", puntuacionIA);
            return puntuacionIA; //Devuelve la puntuación de la IA.
        }
        #endregion
    }
}
