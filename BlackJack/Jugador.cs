using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BlackJack
{
    class Jugador : Juego
    {
        #region "Variables"
        public string nombre;
        public List<Carta> mano = new List<Carta>(); //Se crea una lista de tipo Carta.
        public int puntuacionJugador;
        #endregion

        public Jugador(Baraja baraja)
        {
            Turno(baraja);
        }

        public Jugador()
        {

        }
        #region "LogicaJuego"
        public virtual void Turno(Baraja baraja) //Se crea una funcion virtual de tipo void que recibe un objeto de tipo Baraja.
        {
            Console.WriteLine("Turno del jugador");
            Thread.Sleep(500);
            bool isValid;
            int robar = 0;
            Console.WriteLine("Introduce tu nombre: ");
            string nombre = NombreJugador(); //Se llama a la función NombreJugador para darle un nombre al jugador.
            Console.WriteLine("Bienvenido, {0}.", nombre);

            Console.WriteLine("___________________________\n");

            for (int i = 0; i < 2; i++)
            {
                mano.Add(baraja.RepartirCarta()); //Se llama la función RepartirCarta de Baraja y se añade el resultado a la lista mano.
            }

            do
            {
                Thread.Sleep(250);
                Console.WriteLine("Has robado {0} cartas", mano.Count); //Para mostrar la cantidad de cartas que tienes en mano, se usa la función Count de la lista mano.
                Thread.Sleep(100);
                MostrarMano(); //Se llama a la función MostrarMano.
                puntuacionJugador = SumarMano(); //Se le da el valor resultante de realizar SumarMano a puntuaciónJugador.
                if(puntuacionJugador < 21)
                {
                    do
                    {
                        Console.WriteLine("Quieres robar otra carta?");
                        isValid = Int32.TryParse(Console.ReadLine(), out robar);
                    }
                    while (!isValid || robar < 0 || robar > 1 && puntuacionJugador <= 21); //Se hace un do while en el que se le pregunta al jugador si quiere robar otra carta.
                }
                
                if (robar == 1)
                {
                    Console.WriteLine("Robando carta...");
                    Thread.Sleep(500);
                    mano.Add(baraja.RepartirCarta()); //Se llama la función RepartirCarta de Baraja y se añade el resultado a la lista mano.
                }
            } while (robar == 1 && puntuacionJugador < 21);

        }

        #endregion
        #region "Mano"
        public virtual void MostrarMano() //Función para mostrar la mano del jugador.
        {
            Console.Write("Tu mano consiste de las cartas: ");
            for (int i = 0; i < mano.Count; i++) //Bucle for que se repite tantas veces como cartas tenga la mano.
            {
                Console.Write("{0}{1}", mano[i].palo, mano[i].valor); //Escribe por pantalla el valor de la variable palo y valor de Carta.
                Console.Write(" ");
                Thread.Sleep(250);
            }
        }

        public virtual int SumarMano() //Función para sumar la mano.
        {
            puntuacionJugador = 0; //Al iniciar la función, se iguala la puntuación a 0.

            Console.WriteLine();
            for(int i = 0; i < mano.Count; i++) //Bucle for que se repite tantas veces como cartas tenga la mano.
            {

                if (mano[i].valor.Equals("A")) //Condicional if que detecta si el valor de la carta es "A".
                {
                    if (puntuacionJugador + 11 > 21) //Condicional if que detecta si la puntuación actual del jugador + 11 (El valor inicial de A) supera 21, si lo hace, cambia el valor de A a 1.
                    {
                        mano[i].isEleven = false;
                    }
                    else //En caso de que no se supere 21, A se mantiene en 11.
                    {
                        mano[i].isEleven = true;
                    }
                }
                puntuacionJugador += mano[i].GetPuntuacion(mano[i].valor); //Se suma a puntuaciónJugador el valor de la mano usando la función GetPuntuación.

            }
            Console.WriteLine("Tu mano suma {0} puntos", puntuacionJugador);
            return puntuacionJugador; //Devuelve la puntuación del jugador.
        }
        #endregion
        #region "Nombre"
        public string NombreJugador()
        {

            nombre = Console.ReadLine(); //Escribir el nombre y asignarselo a la variable.

            return nombre; //Devuelve el nombre.
        }
        #endregion
    }
}
