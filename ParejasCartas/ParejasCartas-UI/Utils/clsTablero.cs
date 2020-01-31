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

        public List<clsCarta> getTablero()
        {
            List<clsCarta> cartas = new List<clsCarta>();

            //TODO Esto pero aleatorio
            cartas.Add(new clsCarta(1, "ms-appx:///Assets/Adorable.jpg"));
            cartas.Add(new clsCarta(2, "ms-appx:///Assets/DeathHalloween.jpg"));
            cartas.Add(new clsCarta(3, "ms-appx:///Assets/KaminaJimaru.jpg"));
            cartas.Add(new clsCarta(4, "ms-appx:///Assets/meme.jpg"));
            cartas.Add(new clsCarta(5, "ms-appx:///Assets/Emos.jpg"));
            cartas.Add(new clsCarta(6, "ms-appx:///Assets/ChaldeaPark.jpg"));

            return cartas;
        }

    }
}
