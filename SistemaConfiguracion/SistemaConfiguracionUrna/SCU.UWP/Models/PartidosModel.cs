using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SCU.UWP.Models
{
    public class PartidosModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public int _Id { get; set; }
        public string _Logotipo { get; set; }
        public string _Propietario { get; set; }
        public string _Suplente { get; set; }
        public string _Hipocoristico { get; set; }
        public string _Cargo { get; set; }
        public string _TipoCandidatura { get; set; }


        public string Cargo
        {
            get { return _Cargo; }
            set
            {
                _Cargo = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
