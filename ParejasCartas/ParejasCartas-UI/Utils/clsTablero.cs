using ParejasCartas_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParejasCartas_UI.Utils
{
    public class clsTablero
    {

        //private List<clsCarta> _tablero;

        public clsTablero()
        {

        }

        /// <summary>
        /// Este metodo genera un tablero aleatorio de cartas
        /// </summary>
        /// <returns>Un listado de cartas aleatorias</returns>
        public List<clsCarta> getTablero()
        {
            //TODO Cambiar esto
            List<clsCarta> cartas = new List<clsCarta>();
            List<clsCarta> tablero = new List<clsCarta>();
            cartas.Add(new clsCarta(1, "ms-appx:///Assets/Adorable.jpg"));
            cartas.Add(new clsCarta(1, "ms-appx:///Assets/Adorable.jpg"));
            cartas.Add(new clsCarta(2, "ms-appx:///Assets/SakuWitch.png"));
            cartas.Add(new clsCarta(2, "ms-appx:///Assets/SakuWitch.png"));
            cartas.Add(new clsCarta(3, "ms-appx:///Assets/KaminaJimaru.jpg"));
            cartas.Add(new clsCarta(3, "ms-appx:///Assets/KaminaJimaru.jpg"));
            cartas.Add(new clsCarta(4, "ms-appx:///Assets/Mercy.jpg"));
            cartas.Add(new clsCarta(4, "ms-appx:///Assets/Mercy.jpg"));
            cartas.Add(new clsCarta(5, "ms-appx:///Assets/SOXVA.jpg"));
            cartas.Add(new clsCarta(6, "ms-appx:///Assets/ChaldeaPark.jpg"));
            cartas.Add(new clsCarta(6, "ms-appx:///Assets/ChaldeaPark.jpg"));
            cartas.Add(new clsCarta(5, "ms-appx:///Assets/SOXVA.jpg"));
            Random cartaSiguiente = new Random();
            int idCarta = 0;

            for (int i = 0; i < 12; i++)
            {
                idCarta = cartaSiguiente.Next(0, cartas.Count);
                tablero.Add(cartas[idCarta]);
                cartas.Remove(cartas[idCarta]);
            }

            //int numero1 = 0, numero2 = 0, numero3 = 0, numero4 = 0, numero5 = 0, numero6 = 0;

            //for (int i = 0; i < 12; i++)
            //{
                
            //    idCarta = cartaSiguiente.Next(1, 7);

            //    switch (idCarta)
            //    {
            //        case 1:
            //            if(numero1 < 2)
            //            {
            //                cartas.Add(new clsCarta(1, "ms-appx:///Assets/Adorable.jpg"));
            //                numero1++;
            //            }
            //            else
            //            {
            //                i--;
            //            }
            //            break;
            //        case 2:
            //            if (numero2 < 2)
            //            {
            //                cartas.Add(new clsCarta(2, "ms-appx:///Assets/SakuWitch.png"));
            //                numero2++;
            //            }
            //            else
            //            {
            //                i--;
            //            }
            //            break;
            //        case 3:
            //            if (numero3 < 2)
            //            {
            //                cartas.Add(new clsCarta(3, "ms-appx:///Assets/KaminaJimaru.jpg"));
            //                numero3++;
            //            }
            //            else
            //            {
            //                i--;
            //            }
            //            break;
            //        case 4:
            //            if (numero4 < 2)
            //            {
            //                cartas.Add(new clsCarta(4, "ms-appx:///Assets/Mercy.jpg"));
            //                numero4++;
            //            }
            //            else
            //            {
            //                i--;
            //            }
            //            break;
            //        case 5:
            //            if (numero5 < 2)
            //            {
            //                cartas.Add(new clsCarta(5, "ms-appx:///Assets/SOXVA.jpg"));
            //                numero5++;
            //            }
            //            else
            //            {
            //                i--;
            //            }
            //            break;
            //        case 6:
            //            if (numero6 < 2)
            //            {
            //                cartas.Add(new clsCarta(6, "ms-appx:///Assets/ChaldeaPark.jpg"));
            //                numero6++;
            //            }
            //            else
            //            {
            //                i--;
            //            }
            //            break;
            //    }

            //}

            return tablero;
        }

    }
}
