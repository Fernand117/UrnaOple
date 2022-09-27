using SCU.UI.Models;
using System.Windows;

namespace SCU.UI.Views.Login
{
    /// <summary>
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UsuariosModel usuariosModel;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Window_DpiChanged(object sender, DpiChangedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            usuariosModel = new UsuariosModel();
            usuariosModel.usuario = txtUsuario.Text;
            usuariosModel.password = txtPassword.Text;
            MessageBox.Show("Usuario: " + usuariosModel.usuario + "\n" + "Contraseña: " + usuariosModel.password, "Validando datos", MessageBoxButton.OK);
        }
    }
}
