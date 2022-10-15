using SCU.UWP.Views.Elecciones.Escolares;
using SCU.UWP.Views.Elecciones.ParticipacionCiudadana;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace SCU.UWP.Views.Elecciones
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class EleccionesPage : Page
    {
        public EleccionesPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NuevaEleccionPage mynewPage = new NuevaEleccionPage();
            this.Content = mynewPage;
        }

        private void Button_Elecciones_escolares(object sender, RoutedEventArgs e)
        {
            EleccionesEscolaresPage x = new EleccionesEscolaresPage();
            this.Content = x;
        }
        private void Button_Participacion_Ciudadana(object sender, RoutedEventArgs e)
        {
            EleccionCiudadanaPage mynewPage = new EleccionCiudadanaPage();
            this.Content = mynewPage;

        }


        
    }
}
