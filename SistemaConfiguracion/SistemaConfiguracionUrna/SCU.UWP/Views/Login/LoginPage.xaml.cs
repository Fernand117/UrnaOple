using SCU.UWP.Views.Dashboard;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace SCU.UWP.Views.Login
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsuario.Text))
            {
                showDialog("Advertencia", "Ingrese su nombre de usuario por favor");
                txtUsuario.Focus(FocusState.Pointer);
                return;
            }

            if (String.IsNullOrEmpty(txtPassword.Password))
            {
                showDialog("Advertencia", "Ingrese su contraseña por favor");
                txtPassword.Focus(FocusState.Pointer);
                return;
            }

            this.Frame.Navigate(typeof(HomePage), null);
        }

        private async void showDialog(string title, string content)
        {
            MessageDialog dialog = new MessageDialog(String.Empty);
            dialog.Title = title;
            dialog.Content = content;
            await dialog.ShowAsync();
        }
    }
}
