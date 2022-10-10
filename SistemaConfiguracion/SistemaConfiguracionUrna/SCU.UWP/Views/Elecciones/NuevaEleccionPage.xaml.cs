﻿using CONFIG.BL.Elecciones;
using CONFIG.COMMON.DTOS.Elecciones;
using CONFIG.COMMON.DTOS.Partidos;
using SCU.UWP.Lists;
using SCU.UWP.Views.Partidos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json.Nodes;
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

        public List<PartidosDTO> PartidosList;
        public PartidosDTO partidos;
        public ObservableCollection<PartidosDTO> Customers = new ObservableCollection<PartidosDTO>();

        public NuevaEleccionPage()
        {
            //ListaPartidosUI = new ListView();
            this.InitializeComponent();
            //ListaPartidosUI = new ListView();
            //ListaPartidosUI.ItemsSource = PartidosList;
            Customers.Add(new PartidosDTO()
            {
                Cargo = "Prueba"
            });

            ListaPartidosUI.ItemsSource = Customers;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            EleccionesPage mynewPage = new EleccionesPage();
            this.Content = mynewPage;
        }

        public void agregarPartidoLista(PartidosDTO _partidos, ObservableCollection<PartidosDTO> _Customers)
        {
            partidos = _partidos;
            PartidosList = new List<PartidosDTO>();

            PartidosDTO Partidos = _partidos;

            PartidosList.Add(Partidos);

            Customers.Add(Partidos);

            ListaPartidosUI.ItemsSource = _Customers;
        }

        private async void btnAddConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            EleccionesRequest eleccionesRequest = new EleccionesRequest()
            {
                TipoEleccion = "Gubernaturas",
                Presidente = txtPresidente.Text,
                Secretario = txtSecretario.Text,
                PrimerEscrutador = txtPrimerEscrutador.Text,
                SegundoEscrutador = txtSegundoEscrutador.Text,
                CantidadBoletas = txtNumeroBoletas.Text,
                Partidos = PartidosList,
                Distrito = txtDistrito.Text,
                Entidad = txtEntidad.Text,
                Municipio = txtMunicipio.Text,
                SeccionElectoral = txtSeccionElectoral.Text,
                TipoCasilla = txtTipoCasilla.Text,
                Folio = txtFolio.Text
            };

            await new EleccionesBLO().Create(eleccionesRequest);
        }
        private async void btnNuevoPartido_Click(object sender, RoutedEventArgs e)
        {
            AgregarPartido agregarPartido = new AgregarPartido();
            await agregarPartido.ShowAsync();
        }
        
    }
}
