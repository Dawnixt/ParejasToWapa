using ParejasCartas_DAL.Handlers;
using ParejasCartas_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParejasCartas_BL.Handlers
{
    public class clsManejadoraScoresBL
    {
        public clsManejadoraScoresBL()
        {

        }

        public int insertarPuntuacionBL(clsScore puntuacion)
        {
            int filas = 0;
            clsManejadoraScores manejadoraScores = new clsManejadoraScores();
            filas = manejadoraScores.insertarPuntuacion(puntuacion);

            return filas;
        }
    }
}
