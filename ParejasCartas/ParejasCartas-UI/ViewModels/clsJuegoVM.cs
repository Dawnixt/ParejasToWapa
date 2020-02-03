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
        private DispatcherTimer _tiempo;
        private int _minutos;
        private int _segundos;
        private string _nombreJugador;
        private string _resultado;
        private clsCarta _cartaSeleccionada;
        private clsCarta _carta1;
        private clsCarta _carta2;
        private int _numeroParejas = 0;

        public clsJuegoVM()
        {
            clsTablero tablero = new clsTablero();
            _tablero = new ObservableCollection<clsCarta>(tablero.getTablero());
            _tiempo = new DispatcherTimer();
            _tiempo.Interval = new TimeSpan(0,0,1);
            _tiempo.Tick += dispatcherTimer_Tick;
            _tiempo.Start();
            _minutos = 0;
            _segundos = 0;
        }

        private void dispatcherTimer_Tick(object sender, object e)
        {
            _segundos++;
            if(_segundos == 59)
            {
                _minutos++;
                _segundos = 0;
            }
            _resultado = $"{_minutos}:{_segundos}";
            NotifyPropertyChanged("Cronometro");
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
                NotifyPropertyChanged("CartaSeleccionada");
                if (_cartaSeleccionada.Volteada)
                {
                    _cartaSeleccionada = null;
                }
                else
                {
                    this.comprobarJugada();
                }
                
            }
        }

        public string Cronometro
        {
            get
            {
                return _resultado;
            }
        }

        //public int NumeroParejas
        //{
        //    get
        //    {
        //        return _numeroParejas;
        //    }
        //    set
        //    {
        //        _numeroParejas = value;
                
        //}

        //Metodos
        /// <summary>
        /// Este metodo comprueba que la pareja es correcta en el caso de que no lo es le da la vuelta a las cartas
        /// Y en el caso de que si sea correcta le suma uno al numero de parejas
        /// </summary>
        public async void comprobarJugada()
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
            //Aqui hago la comprobacion de las parejas
            if (_carta2 != null)
            {

                if (_carta1.ID == _carta2.ID)
                {
                    _numeroParejas++;
                    _carta2 = null;
                    _carta1 = null;

                }
                else
                {

                    //ContentDialog mensaje = new ContentDialog();
                    //Frame frame = Window.Current.Content as Frame;

                    //mensaje.Title = "Incorrecto";
                    //mensaje.Content = "Has fallado";
                    //mensaje.PrimaryButtonText = "Vale?";
                    Task task = Task.Delay(350);
                    await task.AsAsyncAction();
                    _carta1.Volteada = false;
                    _carta2.Volteada = false;
                    _carta2 = null;
                    _carta1 = null;
                    //mensaje.Hide();
                    ////ContentDialogResult finale = await mensaje.ShowAsync();
                    

                }

            }

            if (_numeroParejas == 6)
            {
                this.mostrarMensajeGanador();
            }
    }

        public async Task<string> mostrarMensajeGanador()
        {
            //    ContentDialog mensaje = new ContentDialog();
            //    Frame frame = Window.Current.Content as Frame;

            //    mensaje.Title = "Termina";
            //    mensaje.Content = "Has Terminado";
            //    mensaje.PrimaryButtonText = "Por fin";

            //    ContentDialogResult finale = await mensaje.ShowAsync();

            string resultado;
            TextBox inputTextBox = new TextBox();
            inputTextBox.AcceptsReturn = false;
            inputTextBox.Height = 32;
            ContentDialog dialog = new ContentDialog();
            dialog.Content = inputTextBox;
            dialog.Title = "Has terminado\n" +
                "Introduce el nombre";
            dialog.IsSecondaryButtonEnabled = true;
            dialog.PrimaryButtonText = "Ok";
            dialog.SecondaryButtonText = "Cancel";
            if (await dialog.ShowAsync() == ContentDialogResult.Primary)
                resultado = inputTextBox.Text;
            else
                resultado = "";

            return resultado;

        }

    }
}
