using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;

namespace Votos.COMMON.DTHW
{
    public class ImprimirTickets
    {
        private string mensaje { get; set; }
        public string imprimirComprobante(string msj)
        {
            mensaje = msj;
            PrintDocument pf = new PrintDocument();
            pf.PrintPage += Pf_PrintPage;
            pf.Print();
            return "";
        }

        private void Pf_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Get the Graphics object  
            Graphics g = e.Graphics;

            //Create a font Arial with size 16  
            Font font = new Font("Arial", 16);

            //Create a solid brush with black color  
            SolidBrush brush = new SolidBrush(Color.Black);

            //Draw "Hello Printer!";  
            g.DrawString(mensaje,
            font, brush,
            new Rectangle(20, 20, 200, 100));
        }
    }
}
