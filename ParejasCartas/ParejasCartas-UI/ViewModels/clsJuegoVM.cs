using ParejasCartas_UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParejasCartas_UI.ViewModels
{
    public class clsJuegoVM : INotifyPropertyChanged
    {

        private ObservableCollection<clsCarta> _tablero;
        private string _tiempo;
        private string _nombreJugador;

        public clsJuegoVM()
        {

        }

        //Cosas del NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
