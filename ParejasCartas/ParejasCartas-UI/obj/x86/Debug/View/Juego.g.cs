﻿#pragma checksum "D:\Ejercicios\Github\ParejasToWapa\ParejasCartas\ParejasCartas-UI\View\Juego.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5629FF66287199091DE88468D8032594"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParejasCartas_UI.View
{
    partial class Juego : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // View\Juego.xaml line 19
                {
                    this.Barra = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                }
                break;
            case 3: // View\Juego.xaml line 20
                {
                    this.Volver = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Volver).Tapped += this.AppBarButton_Tapped;
                }
                break;
            case 4: // View\Juego.xaml line 21
                {
                    this.Cronometro = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 5: // View\Juego.xaml line 25
                {
                    this.Cartas = (global::Windows.UI.Xaml.Controls.GridView)(target);
                }
                break;
            case 6: // View\Juego.xaml line 28
                {
                    global::Windows.UI.Xaml.Controls.Image element6 = (global::Windows.UI.Xaml.Controls.Image)(target);
                    ((global::Windows.UI.Xaml.Controls.Image)element6).Tapped += this.Carta_Tapped;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

