using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Carta
    {

        public string palo;
        public string valor;
        public int puntuacion;
        public bool isEleven;

        #region "Puntuacion"
        public int GetPuntuacion(string valor) //Funcion de tipo que es llamada para obtener la puntuación de las cartas.
        {
            switch (valor)
            {
                case "A":
                    if(isEleven == true)
                    {
                        puntuacion = 11;
                    }
                    else
                    {
                        puntuacion = 1;
                    }
                    break;

                case "2":

                    puntuacion = 2;
                    break;

                case "3":

                    puntuacion = 3;
                    break;

                case "4":

                    puntuacion = 4;
                    break;

                case "5":

                    puntuacion = 5;
                    break;

                case "6":

                    puntuacion = 6;
                    break;

                case "7":

                    puntuacion = 7;
                    break;

                case "8":

                    puntuacion = 8;
                    break;

                case "9":

                    puntuacion = 9;
                    break;

                case "10":

                    puntuacion = 10;
                    break;

                case "J":

                    puntuacion = 10;
                    break;

                case "K":

                    puntuacion = 10;
                    break;

                case "Q":

                    puntuacion = 10;
                    break;
            }
            return puntuacion;
        }
        #endregion
        #region "ConstructorCarta"
        public Carta(string palo, string valor)
        {

            this.palo = palo; //Se le da a la variable palo de esta clase el valor de la variable palo que pide el constructor.
            this.valor = valor; //Se le da a la variable valor de esta clase el valor de la variable valor que pide el constructor.
        }
        #endregion
    }
}
