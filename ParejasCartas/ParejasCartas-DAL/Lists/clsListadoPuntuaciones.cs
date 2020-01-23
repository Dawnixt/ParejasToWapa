using ParejasCartas_DAL.Connection;
using ParejasCartas_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParejasCartas_DAL.Lists
{
    public class clsListadoPuntuaciones
    {
        public clsListadoPuntuaciones()
        {

        }

        public List<clsScore> obtenerPuntuaciones()
        {
            List<clsScore> scores = new List<clsScore>();
            SqlConnection connection;
            clsMyConnection myConnection;

            try
            {
                myConnection = new clsMyConnection();
                connection = new SqlConnection();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader;
                clsScore puntuacion;

                connection = myConnection.getConnection();
                command.CommandText = "Select * from dbo.Scores Order by tiempo";
                command.Connection = connection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        puntuacion = new clsScore();

                        puntuacion.ID = (int)reader["id"];

                        if (!String.IsNullOrEmpty(reader["nombre"].ToString()))
                        {
                            puntuacion.Nombre = (String)reader["nombre"];
                        }

                        if (!String.IsNullOrEmpty(reader["tiempo"].ToString()))
                        {
                            puntuacion.Nombre = (String)reader["tiempo"];
                        }

                        scores.Add(puntuacion);
                    }
                }

                reader.Dispose();
                myConnection.closeConnection(ref connection);
            }
            catch (SqlException)
            {
                throw;
            }

            return scores;
        }
    }
}
