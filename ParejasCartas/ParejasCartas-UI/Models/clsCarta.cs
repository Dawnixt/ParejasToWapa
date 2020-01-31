using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParejasCartas_UI.Models
{
    public class clsCarta : INotifyPropertyChanged
    {
        private int _id;
        private string _imagenReverso;
        private string _imagenAnverso;
        private string _imagenAMostrar;
        private bool _volteada;

        public clsCarta()
        {
            _imagenAnverso = "ms-appx:///Assets/yu-gi-oh-standard-card-back-sleeves.jpg";
            _volteada = false;
        }

        public clsCarta(int id,string imagenReverso)
        {
            _id = id;
            _imagenReverso = imagenReverso;
            _imagenAnverso = "ms-appx:///Assets/yu-gi-oh-standard-card-back-sleeves.jpg";
            Volteada = false;
        }

        public string ImagenAMostrar
        {
            get
            {
                return _imagenAMostrar;
            }
        }

        public string ImagenReverso
        {
            get
            {
                return _imagenReverso;
            }
            set
            {
                _imagenReverso = value;
            }
        }

        public string ImagenAnverso
        {
            get
            {
                return _imagenAnverso;
            }
            set
            {
                _imagenAnverso = value;
            }
        }

        public bool Volteada
        {
            get
            {
                return _volteada;
            }
            set
            {
                _volteada = value;

                if (_volteada)
                {
                    _imagenAMostrar = _imagenReverso;
                }
                else
                {
                    _imagenAMostrar = _imagenAnverso;
                }

                NotifyPropertyChanged("ImagenAMostrar");
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

        //Cosas del NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
