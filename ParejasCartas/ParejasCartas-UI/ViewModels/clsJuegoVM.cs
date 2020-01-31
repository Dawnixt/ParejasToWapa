using ParejasCartas_UI.Models;
using ParejasCartas_UI.Utils;
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
        private bool _carta1Seleccionada;

        public clsJuegoVM()
        {
            clsTablero tablero = new clsTablero();
            _tablero = new ObservableCollection<clsCarta>(tablero.getTablero());
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
                if (!_carta1Seleccionada)
                {
                    _cartaSeleccionada1 = value;

                    if (!_cartaSeleccionada1.Volteada)
                    {
                        _cartaSeleccionada1.Volteada = true;
                        _carta1Seleccionada = true;
                    }
                    else
                    {
                        _cartaSeleccionada1.Volteada = false;
                        _carta1Seleccionada = false;
                    }
                }
                else
                {
                    CartaSeleccionada2 = value;
                }
                
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

                if (!_cartaSeleccionada2.Volteada)
                {
                    _cartaSeleccionada2.Volteada = true;
                    
                }
                else
                {
                    _cartaSeleccionada2.Volteada = false;
                    
                }
                _carta1Seleccionada = false;
            }
        }

        public bool Carta1Seleccionada
        {
            get
            {
                return _carta1Seleccionada;
            }
            set
            {
                _carta1Seleccionada = value;
            }
        }

    }
}
