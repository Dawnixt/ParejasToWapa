using ParejasCartas_DAL.Connection;
using ParejasCartas_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParejasCartas_DAL.Handlers
{
    public class clsManejadoraScores
    {

        public clsManejadoraScores()
        {

        }
        /// <summary>
        /// Esta funcion nos permite introducir una puntuacion en la base de datos
        /// </summary>
        /// <param name="puntuacion">Es el tiempo y el nombre del usuario</param>
        /// <returns>El numero de filas que altera</returns>
        public int insertarPuntuacion(clsScore puntuacion)
        {
            int filasCambiadas = 0;
            SqlConnection connection;
            clsMyConnection myConnection;

            try
            {
                SqlCommand command = new SqlCommand();
                myConnection = new clsMyConnection();
                connection = new SqlConnection();

                connection = myConnection.getConnection();
                command.CommandText = "INSERT INTO dbo.Scores (nombre,tiempo) VALUES(@nombreJugador,@tiempo)";
                command.Parameters.Add("@nombreJugador", System.Data.SqlDbType.VarChar).Value = (string)puntuacion.Nombre;
                command.Parameters.Add("@tiempo", System.Data.SqlDbType.VarChar).Value = (string) puntuacion.Tiempo;

                command.Connection = connection;
                filasCambiadas = command.ExecuteNonQuery();

                myConnection.closeConnection(ref connection);

            }
            catch (SqlException)
            {
                throw;
            }

            return filasCambiadas;
        }
    }
}
