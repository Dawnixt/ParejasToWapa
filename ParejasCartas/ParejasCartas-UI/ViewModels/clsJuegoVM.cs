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
        private clsCarta _cartaSeleccionada1;
        private clsCarta _cartaSeleccionada2;

        public clsJuegoVM()
        {

        }

        //Cosas del NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<clsCarta> Tablero
        {
            get
            {
                return _tablero;
            }
            set
            {
                _tablero = value;
            }
        }

        public string NombreJugador
        {
            get
            {
                return _nombreJugador;
            }
            set
            {
                _nombreJugador = value;
            }
        }

        public clsCarta CartaSeleccionada1
        {
            get
            {
                return _cartaSeleccionada1;
            }
            set
            {
                _cartaSeleccionada1 = value;
            }
        }

        public clsCarta CartaSeleccionada2
        {
            get
            {
                return _cartaSeleccionada2;
            }
            set
            {
                _cartaSeleccionada2 = value;
            }
        }

    }
}
