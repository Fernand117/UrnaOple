﻿using System;
using System.Drawing;
using System.Drawing.Printing;
using Votos.COMMON.DTOS.Boletas;

namespace Votos.COMMON.DTHW
{
    public class ImprimirTickets
    {
        private string mensaje { get; set; }

        public void imprimirComprobante(BoletasDTO request)
        {
            mensaje = estructuraTicket(request);
            Console.WriteLine(mensaje);
            PrintDocument pf = new PrintDocument();
            pf.PrintPage += Pf_PrintPage;
            pf.Print();
        }

        private void Pf_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Font font = new Font("Arial", 12);

            SolidBrush brush = new SolidBrush(Color.Black);

            g.DrawString(mensaje,
            font, brush,
            new Rectangle(5, 5, 200, 400));
        }

        public string estructuraTicket(BoletasDTO _boletas)
        {
            BoletasDTO boletaDto = new BoletasDTO()
            {
                CantidadBoletas = _boletas.CantidadBoletas,
                Casilla = _boletas.Casilla,
                Distrito = _boletas.Distrito,
                Entidad = _boletas.Entidad,
                Folio = _boletas.Folio,
                Municipio = _boletas.Municipio,
                Partido = _boletas.Partido,
                Seccion = _boletas.Seccion,
                TipoEleccion = _boletas.TipoEleccion
            };
            
            string cabezera = "           OPLE VERACRUZ\n";
            string mensajeHead = "      Comprobante de votación\n";
            string fechaHora = "Fecha: " + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "    " + "Hora: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "hrs." + "\n";
            string eleccion = "Tipo elección: " + boletaDto.TipoEleccion + "\n";
            string separadorUno = "-------------------------------------\n";
            string datosUno = "Entidad: " + boletaDto.Entidad + "  Distrito: " + boletaDto.Distrito + "  Municipio: " + boletaDto.Municipio + "\n";
            string datosDos = "Sección: " + boletaDto.Seccion + "  Casilla: " + boletaDto.Casilla + "   Folio: " + boletaDto.Folio + "\n";
            string partidos = "      Votaste por el partido\n";
            string partidoNombre = "     " + boletaDto.Partido + "\n";
            string corte = "\x1B" + "m";
            string avance = "\x1B" + "d" + "\x09";

            string mensajeEstructura = cabezera + mensajeHead + fechaHora + eleccion + separadorUno
                      + datosUno + datosDos + partidos + partidoNombre + corte + avance;
            
            return mensajeEstructura;
        }
    }
}
