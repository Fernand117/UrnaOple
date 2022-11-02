using System;
using System.Drawing;
using System.Drawing.Printing;
using Votos.COMMON.DTOS.Boletas;

namespace Votos.COMMON.DTHW
{
    public class ImprimirTickets
    {
        private string mensaje { get; set; }
        private string partido { get; set; }
        private string tipoEleccion { get; set; }
        private string entidad { get; set; }
        private string distrito { get; set; }
        private string municipio { get; set; }
        private string seccion { get; set; }
        private string casilla { get; set; }
        private string folio { get; set; }

        public void imprimirComprobante(BoletasDTO request)
        {
            tipoEleccion = request.TipoEleccion;
            partido = request.Partido;
            entidad = request.Entidad;
            distrito = request.Distrito;
            municipio = request.Municipio;
            seccion = request.Seccion;
            casilla = request.Casilla;
            folio = request.Folio;

            string cabezera = "     OPLE VERACRUZ           \n";
            string mensajeHead = "  Comprobante de votación    \n";
            string fechaHora = "Fecha: " + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "    " + "Hora: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "hrs." + "\n";
            string eleccion = "Tipo elección: " + tipoEleccion + "\n";
            string separadorUno = "-------------------------------------\n";
            string datosUno = "Entidad: " + entidad + "  Distrito: " + distrito + "  Municipio: " + municipio + "\n";
            string datosDos = "Sección: " + seccion + "  Casilla: " + casilla + "  Folio: " + folio + "\n";
            string partidos = "  Votaste por el partido     \n";
            string partidoNombre = "     " + partido + "         \n";
            string corte = "\x1B" + "m";
            string avance = "\x1B" + "d" + "\x09";

            mensaje = cabezera + mensajeHead + fechaHora + eleccion + separadorUno
                      + datosUno + datosDos + partidos + partidoNombre + corte + avance;

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
    }
}
