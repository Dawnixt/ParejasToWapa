using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParejasCartas_Entities
{
    public class clsScore
    {
        #region Propiedades privadas
        private string _nombre;
        private string _tiempo;
        private int _id;
        #endregion

        #region constructores
        public clsScore()
        {
            _id = 0;
            _tiempo = "";
            _nombre = "";
        }

        public clsScore(string tiempo, string nombre)
        {
            _tiempo = tiempo;
            _nombre = nombre;
        }
        #endregion

        #region Propiedades publicas

        public String Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        public string Tiempo
        {
            get
            {
                return _tiempo;
            }
            set
            {
                _tiempo = value;
            }
        }

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        #endregion
    }
}
