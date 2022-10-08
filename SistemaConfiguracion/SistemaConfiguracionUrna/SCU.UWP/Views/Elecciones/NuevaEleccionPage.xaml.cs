using CONFIG.BL.Elecciones;
using CONFIG.COMMON.DTOS.Elecciones;
using CONFIG.COMMON.DTOS.Partidos;
using SCU.UWP.Views.Partidos;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace SCU.UWP.Views.Elecciones
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class NuevaEleccionPage : Page
    {
        public NuevaEleccionPage()
        {
            this.InitializeComponent();
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
            EleccionesRequest eleccionesRequest = new EleccionesRequest()
            {
                TipoEleccion = "Gubernaturas",
                Presindente = txtPresidente.Text,
                Secretario = txtSecretario.Text,
                PrimerEscrutador = txtPrimerEscrutador.Text,
                SegundoEscrutado = txtSegundoEscrutador.Text,
                CantidadBoletas = txtNumeroBoletas.Text,
                Partidos = new List<PartidosDTO>()
                {
                    new PartidosDTO()
                    {
                        Cargo = "Diputado",
                        Logotipo = "fmg",
                        Propietario = "Juan",
                        Suplente = "Yessi",
                        Hipocoristico = "PAN",
                        TipoCandidatura = "Candidato registrado"
                    },
                    new PartidosDTO()
                    {
                        Cargo = "Diputado",
                        Logotipo = "fmg",
                        Propietario = "Fernando",
                        Suplente = "Yessi",
                        Hipocoristico = "PAN",
                        TipoCandidatura = "Candidato registrado"
                    }
                },
                Distrito = txtDistrito.Text,
                Entidad = txtEntidad.Text,
                Municipio = txtMunicipio.Text,
                SeccionElectoral = txtSeccionElectoral.Text,
                TipoCasilla = txtTipoCasilla.Text,
                Folio = txtFolio.Text
            };
            await new EleccionesBLO().Create(eleccionesRequest);
        }
    }
}
