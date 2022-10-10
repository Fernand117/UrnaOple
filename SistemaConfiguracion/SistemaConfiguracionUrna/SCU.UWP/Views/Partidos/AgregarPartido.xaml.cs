using CONFIG.COMMON.DTOS.Partidos;
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
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using SCU.UWP.Views.Elecciones;
using System.Text.Json;
using System.Collections.ObjectModel;


// La plantilla de elemento del cuadro de diálogo de contenido está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace SCU.UWP.Views.Partidos
{
    public sealed partial class AgregarPartido : ContentDialog
    {
        public ObservableCollection<PartidosDTO> Customers = new ObservableCollection<PartidosDTO>();
        public AgregarPartido()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            PartidosDTO partidos = new PartidosDTO()
            {
                Cargo = txt_cargo.Text,
                Logotipo = txt_logotipo.Text,
                Propietario = txt_propietario.Text,
                Suplente = txt_suplente.Text,
                Hipocoristico = txt_hipocoristico.Text,
                TipoCandidatura = txt_tipo.Text
            };

            Customers.Add(new PartidosDTO()
            {
                Cargo = txt_cargo.Text,
                Logotipo = txt_logotipo.Text,
                Propietario = txt_propietario.Text,
                Suplente = txt_suplente.Text,
                Hipocoristico = txt_hipocoristico.Text,
                TipoCandidatura = txt_tipo.Text
            });

            NuevaEleccionPage page = new NuevaEleccionPage();
            page.agregarPartidoLista(partidos, Customers);

        }
        private void AddPhotoButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
