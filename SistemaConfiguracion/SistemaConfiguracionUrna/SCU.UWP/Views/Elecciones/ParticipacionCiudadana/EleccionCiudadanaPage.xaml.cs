using SCU.UWP.Views.Partidos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace SCU.UWP.Views.Elecciones.ParticipacionCiudadana
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class EleccionCiudadanaPage : Page
    {
        int num_textBox = 2;
        String[] stringarr = new String[] { "Geeks", "GFG", "Noida" };

        public EleccionCiudadanaPage()
        {
            this.InitializeComponent();
            Console.WriteLine("hola mundo");


        }
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            EleccionesPage mynewPage = new EleccionesPage();
            this.Content = mynewPage;
        }
        private async void btnNuevoPartido_Click(object sender, RoutedEventArgs e)
        {
            AgregarPartido agregarPartido = new AgregarPartido();
            await agregarPartido.ShowAsync();
        }

        private void addTextBlock(object sender, RoutedEventArgs e)
        {
            TextBox textBox = new TextBox();
            this.ListaPreguntas.Children.Add(textBox);
            textBox.Header = "Pregunta " + this.num_textBox.ToString();
            num_textBox = num_textBox + 1;
            Console.WriteLine(this.stringarr[0]);
            Console.WriteLine(stringarr[1]);
            Console.WriteLine(stringarr[2]);
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
