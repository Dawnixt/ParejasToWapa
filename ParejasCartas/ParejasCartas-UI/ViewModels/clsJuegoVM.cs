using ParejasCartas_BL.Handlers;
using ParejasCartas_Entities;
using ParejasCartas_UI.Models;
using ParejasCartas_UI.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ParejasCartas_UI.ViewModels
{
    public class clsJuegoVM : INotifyPropertyChanged
    {
        #region propiedades privadas
        private ObservableCollection<clsCarta> _tablero;
        private DispatcherTimer _cronometro;
        private bool _tableroHabilitado;
        private string _nombreJugador;
        private string _tiempo;
        private clsCarta _cartaSeleccionada;
        private clsCarta _carta1;
        private clsCarta _carta2;
        private int _numeroParejas;
        private DateTime _fecha;
        private DelegateCommand _reiniciar;
        #endregion

        #region constructor
        public clsJuegoVM()
        {
            this.inicializarTablero();
            _cronometro = new DispatcherTimer();
            _cronometro.Interval = new TimeSpan(0,0,1);
            _cronometro.Tick += dispatcherTimer_Tick;
            _cronometro.Start();
            _reiniciar = new DelegateCommand(Reiniciar_Executed);
        }

        #endregion

        #region Propiedades publicas

        public DelegateCommand Reiniciar
        {
            get
            {
                return _reiniciar;
            }
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
                this.comprobarJugada();

            }
        }

        public string Tiempo
        {
            get
            {
                return _tiempo;
            }
        }

        public bool TableroHabilitado
        {
            get
            {
                return _tableroHabilitado;
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Este metodo inicializa todos las propiedades para tener un nuevo tablero
        /// </summary>
        public void inicializarTablero()
        {
            clsTablero tablero = new clsTablero();
            _tablero = new ObservableCollection<clsCarta>(tablero.getTablero());
            _tableroHabilitado = true;
            _numeroParejas = 0;
            _fecha = new DateTime(1, 1, 1, 0, 0, 0);
        }

        ///// <summary>
        ///// Esto es un evento que se ejecutara cuando se presione el boton reiniciar y lo que hara sera 
        ///// crear un nuevo tablero
        ///// </summary>
        private void Reiniciar_Executed()
        {
            _cronometro.Stop();
            _tableroHabilitado = false;
            NotifyPropertyChanged("TableroHabilitado");
            _cartaSeleccionada = null;
            this.inicializarTablero();
            NotifyPropertyChanged("Tablero");
            NotifyPropertyChanged("Tiempo");
            //NotifyPropertyChanged("CartaSeleccionada");
            _tableroHabilitado = true;
            NotifyPropertyChanged("TableroHabilitado");
            _cronometro.Start();
        }

        /// <summary>
        /// Este metodo comprueba si la carta ya ha sido seleccionada y si no lo es comprueba si es la primera 
        /// y si lo es no hace nada.Comprueba si es la segunda y si lo es
        /// comprueba que la pareja es correcta en el caso de que no lo es le da la vuelta a las cartas
        /// Y en el caso de que si sea correcta le suma uno al numero de parejas
        /// </summary>
        public async void comprobarJugada()
        {
            if(_cartaSeleccionada != null)
            {
                //Aqui comprueba que la carta que ha seleccionado no es una que ya este volteada
                if (_cartaSeleccionada.Volteada)
                {
                    _cartaSeleccionada = null;
                }
                else
                {
                    //Aqui comprobamos que carta es a la que le vamos a dar el valor
                    _cartaSeleccionada.Volteada = true;
                    if (_carta1 == null)
                    {
                        _carta1 = _cartaSeleccionada;

                    }
                    else
                    {
                        _carta2 = _cartaSeleccionada;


                        //Aqui hago la comprobacion de las parejas
                        _tableroHabilitado = false;
                        NotifyPropertyChanged("TableroHabilitado");
                        if (_carta1.ID == _carta2.ID)
                        {
                            _numeroParejas++;
                            _carta2 = null;
                            _carta1 = null;

                        }
                        else
                        {
                            Task task = Task.Delay(500);
                            await task.AsAsyncAction();
                            _carta1.Volteada = false;
                            _carta2.Volteada = false;
                            _carta2 = null;
                            _carta1 = null;
                            //Aqui intentamos que se deseleccione la carta para poder darle la vuelta  
                            _cartaSeleccionada = null;
                            NotifyPropertyChanged("CartaSeleccionada");


                        }

                        //Aqui compruebo si ya ha encontrado todas las parejas
                        if (_numeroParejas == 6)
                        {
                            _cronometro.Stop();
                            _nombreJugador = await this.mostrarMensajeGanador();
                            this.guardarResultado();
                        }
                        _tableroHabilitado = true;
                        NotifyPropertyChanged("TableroHabilitado");
                    }
                }
            }
            
        }

        /// <summary>
        /// Este evento se activa cuando se ha terminado la partida y muestra un mensaje para que introduzca el nombre del jugador
        /// </summary>
        /// <returns>Devuelve el nick del usuario</returns>
        public async Task<string> mostrarMensajeGanador()
        {
            string resultado;
            TextBox inputTextBox = new TextBox();
            inputTextBox.AcceptsReturn = false;
            inputTextBox.Height = 32;
            ContentDialog dialog = new ContentDialog();
            dialog.Content = inputTextBox;
            dialog.Title = "Has terminado\n" +
                "Introduce tu nick";
            dialog.IsSecondaryButtonEnabled = true;
            dialog.PrimaryButtonText = "Ok";
            dialog.SecondaryButtonText = "Cancel";
            if (await dialog.ShowAsync() == ContentDialogResult.Primary)
                resultado = inputTextBox.Text;
            else
                resultado = "Anonimo";

            return resultado;

        }

        /// <summary>
        /// Este evento se activara cuando el usuario quiera salir de la pantalla de juego
        /// </summary>
        /// <returns>Devuelve un boolean si este es igual a true significa que el usuario quiere salir y si es false que no</returns>
        public async Task<bool> mostarMensajeSalida()
        {
            bool result = false;
            ContentDialog mensaje = new ContentDialog();
            Frame frame = Window.Current.Content as Frame;

            mensaje.Title = "Alerta";
            mensaje.Content = "Quieres salir?";
            mensaje.PrimaryButtonText = "Ok perfecto";
            mensaje.SecondaryButtonText = "Mejor no me voy";

            ContentDialogResult finale = await mensaje.ShowAsync();

            if(finale == ContentDialogResult.Primary)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Este procedimiento se encargara de llamar al metodo de la BL para guardar 
        /// el resultado de la partida en la base de datos
        /// </summary>
        public void guardarResultado()
        {
            clsScore score = new clsScore(_tiempo,_nombreJugador);
            clsManejadoraScoresBL scoresBL = new clsManejadoraScoresBL();
            try
            {
                scoresBL.insertarPuntuacionBL(score);
            }
            catch (SqlException)
            {
                this.mensajeError();
            }

        }

        /// <summary>
        /// Este procedimiento se ejecuta cada vez que pasa un segundo
        /// </summary>
        /// <param name="sender">No es nada</param>
        /// <param name="e">No es nada</param>
        private void dispatcherTimer_Tick(object sender, object e)
        {
            _fecha = _fecha.AddSeconds(1);
            _tiempo = _fecha.ToString("mm:ss");
            NotifyPropertyChanged("Tiempo");
        }

        #region NotifyPropertyChanged
        //Cosas del NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        /// <summary>
        /// Este metodo nos mostrara un mensaje de error 
        /// </summary>
        public async void mensajeError()
        {

            ContentDialog mensaje = new ContentDialog();
            Frame frame = Window.Current.Content as Frame;

            mensaje.Title = "Error";
            mensaje.Content = "Ha ocurrido un error vuelva a intertarlo mas tarde";
            mensaje.PrimaryButtonText = "Salir";

            ContentDialogResult finale = await mensaje.ShowAsync();

        }

        #endregion

    }
}
