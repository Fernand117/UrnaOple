using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
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
        
        public string ImprimirComprobante(BoletasDTO request)
        {
            tipoEleccion = request.TipoEleccion;
            partido = request.Partido;
            entidad = request.Entidad;
            distrito = request.Distrito;
            municipio = request.Municipio;
            seccion = request.Seccion;
            casilla = request.Casilla;
            folio = request.Folio;
            PrintDocument pf = new PrintDocument();
            pf.PrintPage += Pf_PrintPage;
            pf.Print();
            return "Voto impreso.";
        }

        private void Pf_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Get the Graphics object  
            Graphics g = e.Graphics;
            //Create a font Arial with size 12  
            Font font = new Font("Arial", 12);
            //Create a solid brush with black color  
            SolidBrush brush = new SolidBrush(Color.Black);
            //Draw "Hello Printer!";  
            g.DrawString(MensajeVotacion(),
            font, brush,
            new Rectangle(5, 5, Int32.MaxValue, Int32.MaxValue));
        }

        private string MensajeVotacion()
        {
            string cabezera      = "     OPLE VERACRUZ           \n";
            string mensajeHead   = "  Comprobante de votación    \n";
            string fechaHora     = "Fecha: " + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "      " + "Hora: " + DateTime.Now.Hour + "hrs." + "\n";
            string eleccion      = "Tipo elección: " + tipoEleccion + "\n";
            string separadorUno  = "-------------------------------------\n";
            string datosUno      = "Entidad: " + entidad + "  Distrito: " + distrito + "  Municipio: " + municipio;
            string datosDos      = "Sección: " + seccion + "  Casilla: " + casilla + "  Folio: " + folio;
            string partido       = "  Votaste por el partido     \n";
            string partidoNombre = "     " + partido + "         \n";

            mensaje = cabezera + mensajeHead + fechaHora + eleccion + separadorUno 
                      + datosUno + datosDos + partido + partidoNombre;
            
            return mensaje;
        }
    }
}
