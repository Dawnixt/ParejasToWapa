using ParejasCartas_DAL.Lists;
using ParejasCartas_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParejasCartas_BL.Lists
{
    public class clsListadoPuntuacionesBL
    {
        public clsListadoPuntuacionesBL()
        {

        }

        /// <summary>
        /// Esta funcion se conectara con la capa DAL y obtendra el listado de puntuaciones ordenadas de mejor a peor
        /// </summary>
        /// <returns>Un listado con las puntuaciones ordenadas de mejor a peor</returns>
        public List<clsScore> obtenerPuntuacionesBL()
        {
            List<clsScore> scores = new List<clsScore>();
            clsListadoPuntuaciones listadoPuntuaciones = new clsListadoPuntuaciones();

            scores = listadoPuntuaciones.obtenerPuntuaciones();
            return scores;
        }

    }
}
