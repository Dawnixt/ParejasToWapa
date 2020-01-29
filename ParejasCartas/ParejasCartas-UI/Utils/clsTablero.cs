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

            cartas.Add(new clsCarta());
            cartas.Add(new clsCarta());
            cartas.Add(new clsCarta());
            cartas.Add(new clsCarta());
            cartas.Add(new clsCarta());
            cartas.Add(new clsCarta());

            return cartas;
        }

    }
}
