using SCU.UWP.Views.Casillas;
using SCU.UWP.Views.Elecciones;
using SCU.UWP.Views.Inicio;
using SCU.UWP.Views.Login;
using SCU.UWP.Views.Partidos;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace SCU.UWP.Views.Dashboard
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(InicioPage));
        }

        private void navView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;

            switch (item.Tag.ToString())
            {
                case "Inicio":
                    ContentFrame.Navigate(typeof(InicioPage));
                    break;
                case "Casillas":
                    ContentFrame.Navigate(typeof(CasillasPage));
                    break;
                case "Partidos":
                    ContentFrame.Navigate(typeof(PartidosPage));
                    break;
                case "Elecciones":
                    ContentFrame.Navigate(typeof(EleccionesPage));
                    break;
            }
        }

        private void NavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage), null);
        }
    }
}
