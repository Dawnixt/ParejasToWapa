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
                command.CommandText = "INSERT INTO Scores VALUES(@nombreJugador,@tiempo)";
                command.Parameters.Add("@nombreJugador", System.Data.SqlDbType.VarChar).Value = puntuacion.Nombre;
                command.Parameters.Add("@tiempo", System.Data.SqlDbType.VarChar).Value = puntuacion.Tiempo;

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
