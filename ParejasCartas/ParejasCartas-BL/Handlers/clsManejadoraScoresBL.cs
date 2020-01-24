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

        /// <summary>
        /// Esta funcion se conecta con la capa DAL y nos permite insertar una nueva puntuacion a la base de datos
        /// </summary>
        /// <param name="puntuacion">Es el tiempo y el nombre del usuario</param>
        /// <returns>El numero de columnas modificadas</returns>
        public int insertarPuntuacionBL(clsScore puntuacion)
        {
            int filas = 0;
            clsManejadoraScores manejadoraScores = new clsManejadoraScores();
            filas = manejadoraScores.insertarPuntuacion(puntuacion);

            return filas;
        }
    }
}
