using ParejasCartas_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace ParejasCartas_UI.View
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Juego : Page
    {
        public Juego()
        {
            this.InitializeComponent();
            this.ViewModel = (clsJuegoVM)this.DataContext;
        }
        public clsJuegoVM ViewModel { get; }

        private async void AppBarButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            bool result;
            result = await ViewModel.mostarMensajeSalida();

            if(result == true)
            {
                this.Frame.Navigate(typeof(MainPage));
            }

        }

        private void Carta_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Storyboard sb = (sender as Image).Resources["Rotar"] as Storyboard;
            sb.Begin();
        }

        private void Reiniciar_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ViewModel.inicializarTablero();
        }

        //private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //    AnimacionRotation.Begin();
        //}
    }
}
