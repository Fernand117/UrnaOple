using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
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

        public void imprimirBoletaCeros(BoletaInicialRequest request)
        {
            mensaje = estructuraBoletaCeros(request);
            Console.WriteLine(mensaje);
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += Pd_PrintPage;
            pd.Print();
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Font font = new Font("Arial", 12);

            SolidBrush brush = new SolidBrush(Color.Black);

            //g.DrawString(mensaje, font, brush, new Rectangle(0, 0));
            g.DrawString(mensaje, font, brush, 0, 0);
        }

        private void Pf_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Font font = new Font("Arial", 12);

            SolidBrush brush = new SolidBrush(Color.Black);

            g.DrawString(mensaje,
            font, brush,
            new Rectangle(0, 0, 300, 400));
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
            string separadorUno = "------------------------------------------------\n";
            string datosUno = "Entidad: " + boletaDto.Entidad + "  Distrito: " + boletaDto.Distrito + "  Municipio: " + boletaDto.Municipio + "\n";
            string datosDos = "Sección: " + boletaDto.Seccion + "  Casilla: " + boletaDto.Casilla + "\n";
            string folio = "Folio: " + boletaDto.Folio + "\n\n";
            string partidos = "      Votaste por el partido\n\n";
            string partidoNombre = "     " + boletaDto.Partido + "\n";

            string mensajeEstructura = cabezera + mensajeHead + fechaHora + eleccion + separadorUno
                      + datosUno + datosDos + folio + partidos + partidoNombre;
            
            return mensajeEstructura;
        }

        public string estructuraBoletaCeros(BoletaInicialRequest _boletas)
        {
            BoletaInicialRequest boletaDto = new BoletaInicialRequest()
            {
                CantidadBoletas = _boletas.CantidadBoletas,
                TipoCasilla = _boletas.TipoCasilla,
                Distrito = _boletas.Distrito,
                Entidad = _boletas.Entidad,
                Folio = _boletas.Folio,
                Municipio = _boletas.Municipio,
                Partidos = _boletas.Partidos,
                SeccionElectoral = _boletas.SeccionElectoral,
                TipoEleccion = _boletas.TipoEleccion
            };

            string cabezera = "           OPLE VERACRUZ\n";
            string mensajeHead = "      Comprobante de votación\n";
            string fechaHora = "Fecha: " + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day +
                               "    " + "Hora: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" +
                               DateTime.Now.Second + "hrs." + "\n";
            string eleccion = "Tipo elección: " + boletaDto.TipoEleccion + "\n";
            string datosUno = "Entidad: " + boletaDto.Entidad + "  Distrito: " + boletaDto.Distrito + "  Municipio: " +
                              boletaDto.Municipio + "\n";
            string datosDos = "Sección: " + boletaDto.SeccionElectoral + "  Casilla: " + boletaDto.TipoCasilla + "\n";
            string separadorUno = "------------------------------------------------\n";
            string partidos = boletaDto.Partidos.ToList() + "\n" + separadorUno;
            string presidente = separadorUno + "\n      Funcionariado de Mesa Directiva de Casilla\n" +
                                boletaDto.Presidente + "\n" + separadorUno + "        Presidente(a): Nombre y Firma\n";
            string secretario = boletaDto.Secretario + "\n" + separadorUno + "\n      Secretario(a): Nombre y Firma\n";
            string escrutadorUno = boletaDto.PrimerEscrutador + "\n" + separadorUno +
                                   "\n      Escrutador(a) 1: Nombre y Firma\n";
            string escrutadorDos = boletaDto.SegundoEscrutador + "\n" + separadorUno +
                                   "\n      Escrutador(a) 2: Nombre y Firma \n" + separadorUno +
                                   "\n     Representantes de Partidos Políticos\n";

            mensaje = cabezera + mensajeHead + fechaHora + eleccion + datosUno + datosDos + separadorUno + partidos +
                      presidente + secretario + escrutadorUno + escrutadorDos;

            return mensaje;
        }
    }
}
