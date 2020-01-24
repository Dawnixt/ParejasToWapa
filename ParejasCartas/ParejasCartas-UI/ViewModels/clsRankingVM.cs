using ParejasCartas_BL.Lists;
using ParejasCartas_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParejasCartas_UI.ViewModels
{
    public class clsRankingVM 
    {

        private ObservableCollection<clsScore> _listadoPuntuaciones;


        public clsRankingVM()
        {
            clsListadoPuntuacionesBL puntuacionesBL = new clsListadoPuntuacionesBL();
            _listadoPuntuaciones = new ObservableCollection<clsScore>(puntuacionesBL.obtenerPuntuacionesBL());
        }

        public ObservableCollection<clsScore> ListadoPuntuaciones
        {
            get
            {
                return _listadoPuntuaciones;
            }
            set
            {
                _listadoPuntuaciones = value;
            }
        }

    }
}
