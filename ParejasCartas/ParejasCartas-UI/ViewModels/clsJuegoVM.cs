using ParejasCartas_UI.Models;
using ParejasCartas_UI.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ParejasCartas_UI.ViewModels
{
    public class clsJuegoVM : INotifyPropertyChanged
    {
        //Dispacher time
        //Solo una carta seleccionada
        //Bloquer la pantalla
        //Un booleano para esp
        //El tiempo no como string poner de formato de en el date solo segundos y min
        private ObservableCollection<clsCarta> _tablero;
        private string _tiempo;
        private string _nombreJugador;
        private clsCarta _cartaSeleccionada;
        private clsCarta _carta1;
        private clsCarta _carta2;
        private int _numeroParejas = 0;

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

        public clsCarta CartaSeleccionada
        {
            get
            {
                return _cartaSeleccionada;
            }
            set
            {
                _cartaSeleccionada = value;
                
            }
        }

        public int NumeroParejas
        {
            get
            {
                return _numeroParejas;
            }
            set
            {
                _numeroParejas = value;
                if(_numeroParejas == 6)
                {
                    this.mostrarMensajeGanador();
                }
            }
        }

        //Metodos
        /// <summary>
        /// Este metodo comprueba que la pareja es correcta en el caso de que no lo es le da la vuelta a las cartas
        /// Y en el caso de que si sea correcta le suma uno al numero de parejas
        /// </summary>
        public void comprobarJugada()
        {

            //Aqui comprobamos que carta es a la que le vamos a dar el valor

            if (_carta1 == null)
            {
                _carta1 = _cartaSeleccionada;
                _carta1.Volteada = true;
            }
            else if (_carta2 == null)
            {
                _carta2 = _cartaSeleccionada;
                _carta2.Volteada = true;
            }

            //if (this.NumeroParejas == 5)
            //{
            //    this.comprobarPareja();
            //}

            //_carta1Seleccionada = false;


            //if (!_carta1Seleccionada)
            //  {
            //      if(CartaSeleccionada2 != null)
            //      {
            //          this.comprobarPareja();
            //      }



            //      if (!_cartaSeleccionada1.Volteada)
            //      {
            //          _cartaSeleccionada1.Volteada = true;
            //          _carta1Seleccionada = true;
            //      }
            //      else
            //      {
            //          _carta1Seleccionada = false;
            //      }
            //  }
            //  else
            //  {
            //      CartaSeleccionada2 = value;
            //  }


            if (CartaSeleccionada.ID == CartaSeleccionada.ID)
            {
                NumeroParejas++;
            }
            else
            {
                CartaSeleccionada.Volteada = false;
                CartaSeleccionada.Volteada = false;
            }
        }

        public async void mostrarMensajeGanador()
        {
            ContentDialog mensaje = new ContentDialog();
            Frame frame = Window.Current.Content as Frame;

            mensaje.Title = "Ganador";
            mensaje.Content = "Has GANADO";
            mensaje.PrimaryButtonText = "Bieeennnn";

            ContentDialogResult finale = await mensaje.ShowAsync();
        }

    }
}
