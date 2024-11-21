using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BlackJack
{
    class Baraja
    {
        #region "Variables"
        public string[] palos = { "♠", "♦", "♥", "♣" }; //Array de String donde se nombran los diferentes palos de la baraja.
        public string[] valores = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" }; //Array de String donde se nombran los posibles valores de la baraja.
        public List<Carta> baraja = new List<Carta>(); //Lista de tipo carta, baraja principal.
        public List<Carta> barajaBarajada = new List<Carta>(); //Lista de tipo carta, baraja en la que se realizará el barajado de la cartas.
        int palosActuales = 0;
        #endregion

        public Baraja()
        {
            IniciarBaraja();
            MostrarBaraja();
            Barajar();
        }

        #region "ControlBaraja"
        public void IniciarBaraja() //Función que se encarga de iniciar la baraja y dar los valores.
        {
            for (int i = 0; i < palos.Length; i++) //Bucle for que se repite por tantos String palos contenga.
            {
                for (int j = 0; j < valores.Length; j++) //Bucle for que se repite por tantos String valores contenga.
                {
                    baraja.Add(new Carta(palos[i], valores[j])); //Crea una nueva carta en baraja dando el valor y palo en orden.
                }
            }
        }

        public void Barajar() //Función que se encarga de barajar.
        {
            for(int i = baraja.Count; i > 0; i--) //Bucle for que se repite por tantas cartas baraja contenga.
            {
                Random rnd = new Random(); //Se crea un nuevo random.
                barajaBarajada.Add(baraja[rnd.Next(0, i)]); //A la baraja a barajar se le añade una carta atleatoria entre 0 y el numero de cartas en la baraja principal.
                baraja.Remove(barajaBarajada[52 - i]); //Se elimina la carta que se ha barajado.
            }
        }
        #endregion
        #region "Repartir"
        public Carta RepartirCarta() //Función que se encarga de repartir las cartas.
        {
            Carta carta = barajaBarajada[0]; //Se crea una variable local de tipo carta y se le asigna el valor de la primera carta de la baraja.
            barajaBarajada.Remove(carta); //Se elimina esta carta de la baraja.
            return carta; //Se devuelve el valor de carta.
        }
        #endregion
        #region "Mostrar"
        public void  MostrarBaraja() //Función encargada de mostrar la baraja.
        {
            for(int i = 0; i < palos.Length; i++)
            {
                for(int j = palosActuales; j < valores.Length + palosActuales; j++)
                {
                    Console.Write("{0}{1} ",baraja[j].palo, baraja[j].valor);
                    Thread.Sleep(25);
                }
                palosActuales += valores.Length;
                Console.WriteLine();
            }
        }
        #endregion
    }
}


