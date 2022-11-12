using System;
using System.Collections.Generic;
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

        public void imprimirComprobanteMecanismos(BoletasDTO request)
        {
            mensaje = estructuraTicketMecanismos(request);
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

        public void imprimirBoletaCerosMecanismos(BoletaInicialMecanismosRequest request)
        {
            mensaje = estructuraBoletaCerosMecanismos(request);
            Console.WriteLine(mensaje);
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += Pd_PrintPage;
            pd.Print();
        }

        public void imprimirBoletaCierre(BoletaFinalRequest request)
        {
            mensaje = estructuraBoletaResultados(request);
            Console.WriteLine(mensaje);
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += Pd_PrintPage;
            pd.Print();
        }
        public void imprimirBoletaCierreMecanismos(BoletaInicialMecanismosRequest request)
        {
            mensaje = estructuraBoletaResultadosMecanismos(request);
            Console.WriteLine(mensaje);
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += Pd_PrintPage;
            pd.Print();
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Image image = Image.FromFile("C:\\LOGOTIPO_OPLE.png");
            Bitmap imageBit = new Bitmap(image, 150, 100);
            Font font = new Font("Arial", 12);

            SolidBrush brush = new SolidBrush(Color.Black);

            //g.DrawString(mensaje, font, brush, new Rectangle(0, 0));
            g.DrawImage(imageBit, 60, 0);
            g.DrawString(mensaje, font, brush, 0, 150);
        }

        private void Pf_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Image image = Image.FromFile("C:\\LOGOTIPO_OPLE.png");
            Font font = new Font("Arial", 12);

            SolidBrush brush = new SolidBrush(Color.Black);

            Bitmap imageBit = new Bitmap(image, 150, 100);
            g.DrawImage(imageBit, 60, 0);
            g.DrawString(mensaje, font, brush, 0, 150);
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

        public string estructuraTicketMecanismos(BoletasDTO _boletas)
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
                TipoEleccion = _boletas.TipoEleccion,
                RespuestaSi = _boletas.RespuestaSi
            };

            string cabezera = "           OPLE VERACRUZ\n";
            string mensajeHead = "      Comprobante de votación\n";
            string fechaHora = "Fecha: " + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "    " + "Hora: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "hrs." + "\n";
            string eleccion = "Tipo de mecanismo: " + boletaDto.TipoEleccion + "\n";
            string separadorUno = "------------------------------------------------\n";
            string datosUno = "Entidad: " + boletaDto.Entidad + "  Distrito: " + boletaDto.Distrito + "\n";
            string datosDos = "Sección: " + boletaDto.Seccion + "  Folio: " + boletaDto.Folio + "\n";
            string folio = "Municipio: " + boletaDto.Municipio + "\n\n";
            string partidos = "      Votaste por la pregunta\n\n";
            string partidoNombre = "     " + boletaDto.Partido + "\n";
            string respuesta = boletaDto.RespuestaSi;
            string res = "";
            if (respuesta == "1")
            {
                res = "      Si";
            } else
            {
                res = "      No";
            }

            string mensajeEstructura = cabezera + mensajeHead + fechaHora + eleccion + separadorUno
                      + datosUno + datosDos + folio + partidos + partidoNombre + res;

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
                TipoEleccion = _boletas.TipoEleccion,
                Presidente = _boletas.Presidente,
                Secretario = _boletas.Secretario,
                PrimerEscrutador = _boletas.PrimerEscrutador,
                SegundoEscrutador = _boletas.SegundoEscrutador
            };

            string cabezera = "             OPLE VERACRUZ\n";
            string mensajeHead = "ACTA DE INSTALACIÓN DE CASILLA\n\n";
            string fechaHora = "Fecha: " + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day +
                               "    " + "Hora: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" +
                               DateTime.Now.Second + "hrs." + "\n";
            string eleccion = "Tipo elección: " + boletaDto.TipoEleccion + "\n";
            string datosUno = "Entidad: " + boletaDto.Entidad + "  Distrito: " + boletaDto.Distrito + "\nMunicipio: " +
                              boletaDto.Municipio + "\n";
            string datosDos = "Sección: " + boletaDto.SeccionElectoral + "  Casilla: " + boletaDto.TipoCasilla + "\n";
            string separadorUno = "------------------------------------------------\n";
            string headPartidos = "Que en presencia del Funcionariado\nde Mesa Directiva de Casilla\ny representaciones de los partidos\npolíticos se inicializó y verificó\nque el sistema se encuentra en\nceros, así como el contenedor de\ntestigos de votos se encuentra vacío.\n" + separadorUno+ "\tPartidos Políticos";
            var lp = boletaDto.Partidos.ToList();
            string partidos = "";
            string partidosFirmas = "";
            foreach (var p in lp)
            {
                partidos = partidos + "\n" + "Partido: " + p.Hipocoristico + "\n" + "Votos: 0\n";

                partidosFirmas += p.Propietario + "\n" + separadorUno + "       RPP: " + p.Hipocoristico +
                                  ": Nombre y Firma\n\n\n";
            }

            string presidente = "\n" + separadorUno + "Funcionariado de Mesa Directiva\n" + "\tde Casilla\n\n\n" +
                                boletaDto.Presidente + "\n" + separadorUno + "        Presidente(a): Nombre y Firma\n\n\n";
            string secretario = boletaDto.Secretario + "\n" + separadorUno + "      Secretario(a): Nombre y Firma\n\n\n";
            string escrutadorUno = boletaDto.PrimerEscrutador + "\n" + separadorUno +
                                   "      Escrutador(a) 1: Nombre y Firma\n\n\n";
            string escrutadorDos = boletaDto.SegundoEscrutador + "\n" + separadorUno +
                                   "      Escrutador(a) 2: Nombre y Firma \n\n\n" + separadorUno +
                                   "Representantes de Partidos Políticos\n\n\n";

            mensaje = cabezera + mensajeHead + fechaHora + eleccion + datosUno + datosDos + separadorUno + headPartidos + partidos +
                      presidente + secretario + escrutadorUno + escrutadorDos + partidosFirmas;
            return mensaje;
        }

        // ************************************************************************************************************************************************************

        public string estructuraBoletaResultados(BoletaFinalRequest _boletas)
        {
            BoletaFinalRequest boletaDto = new BoletaFinalRequest()
            {
                CantidadBoletas = _boletas.CantidadBoletas,
                TipoCasilla = _boletas.TipoCasilla,
                Distrito = _boletas.Distrito,
                Entidad = _boletas.Entidad,
                Folio = _boletas.Folio,
                Municipio = _boletas.Municipio,
                Partidos = _boletas.Partidos,
                SeccionElectoral = _boletas.SeccionElectoral,
                TipoEleccion = _boletas.TipoEleccion,
                Presidente = _boletas.Presidente,
                Secretario = _boletas.Secretario,
                PrimerEscrutador = _boletas.PrimerEscrutador,
                SegundoEscrutador = _boletas.SegundoEscrutador
            };

            string cabezera = "             OPLE VERACRUZ\n";
            string mensajeHead = "ACTA DE CÓMPUTO DE CASILLA\n\n";
            string fechaHora = "Fecha: " + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day +
                               "    " + "Hora: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" +
                               DateTime.Now.Second + "hrs." + "\n";
            string eleccion = "Tipo elección: " + boletaDto.TipoEleccion + "\n";
            string datosUno = "Entidad: " + boletaDto.Entidad + "  Distrito: " + boletaDto.Distrito + "\nMunicipio: " +
                              boletaDto.Municipio + "\n";
            string datosDos = "Sección: " + boletaDto.SeccionElectoral + "  Casilla: " + boletaDto.TipoCasilla + "\n";
            string separadorUno = "------------------------------------------------\n";
            string headPartidos = "Que en presencia del Funcionariado\nde Mesa Directiva de Casilla\ny representaciones de los partidos\npolíticos se clausuró y computaron\nquedando de la siguiente manera:\n" + separadorUno + "\tVOTACIÓN " + "\n";
            var lp = boletaDto.Partidos.ToList();
            string partidos = "";
            int total_votos = 0;
            string partidosFirmas = "";
            foreach (var p in lp)
            {
                partidos = partidos + "\n" + p.partido + "\n" + "Votos: " + p.voto + "\n";
                total_votos = total_votos + int.Parse(p.voto);
            }
            string txt_total = "\n" + "VOTACIÓN TOTAL: " + total_votos;

            string presidente = "\n" + separadorUno + "Funcionariado de Mesa Directiva\n" + "\tde Casilla\n\n\n" +
                                boletaDto.Presidente + "\n" + separadorUno + "        Presidente(a): Nombre y Firma\n\n\n";
            string secretario = boletaDto.Secretario + "\n" + separadorUno + "      Secretario(a): Nombre y Firma\n\n\n";
            string escrutadorUno = boletaDto.PrimerEscrutador + "\n" + separadorUno +
                                   "      Escrutador(a) 1: Nombre y Firma\n\n\n";
            string escrutadorDos = boletaDto.SegundoEscrutador + "\n" + separadorUno +
                                   "      Escrutador(a) 2: Nombre y Firma \n\n\n" + separadorUno +
                                   "Representantes de Partidos Políticos\n\n\n";

            mensaje = cabezera + mensajeHead + fechaHora + eleccion + datosUno + datosDos + separadorUno + headPartidos + partidos +
                      txt_total + presidente + secretario + escrutadorUno + escrutadorDos + partidosFirmas;
            return mensaje;
        }


        // ************************************************************* MECANISMOS *****************************************************************

        public string estructuraBoletaCerosMecanismos(BoletaInicialMecanismosRequest _boletas)
        {
            BoletaInicialMecanismosRequest boletaDto = new BoletaInicialMecanismosRequest()
            {
                Distrito = _boletas.Distrito,
                Entidad = _boletas.Entidad,
                Folio = _boletas.Folio,
                Municipio = _boletas.Municipio,
                Preguntas = _boletas.Preguntas,
                SeccionElectoral = _boletas.SeccionElectoral,
                MecanismoTipo = _boletas.MecanismoTipo,
                Presidente = _boletas.Presidente,
                Secretario = _boletas.Secretario,
                PrimerEscrutador = _boletas.PrimerEscrutador,
                SegundoEscrutador = _boletas.SegundoEscrutador
            };

            string cabezera = "             OPLE VERACRUZ\n";
            string mensajeHead = "ACTA DE INSTALACIÓN DE CASILLA\n\n";
            string fechaHora = "Fecha: " + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day +
                               "    " + "Hora: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" +
                               DateTime.Now.Second + "hrs." + "\n";
            string eleccion = "Tipo de mecanismo: " + boletaDto.MecanismoTipo + "\n";
            string datosUno = "Entidad: " + boletaDto.Entidad + "  Distrito: " + boletaDto.Distrito + "\nMunicipio: " +
                              boletaDto.Municipio + "\n";
            string datosDos = "Sección: " + boletaDto.SeccionElectoral + "\n";
            string separadorUno = "------------------------------------------------\n";
            string headPartidos = "Que en presencia del Funcionariado\nde Mesa Directiva de Casilla\ny representaciones de los partidos\npolíticos se inicializó y verificó\nque el sistema se encuentra en\nceros, así como el contenedor de\ntestigos de votos se encuentra vacío.\n" + separadorUno + "\tLista de preguntas";
            var lp = boletaDto.Preguntas.ToList();
            string partidos = "";
            foreach (var p in lp)
            {
                partidos = partidos + "\n" + p.Pregunta + "\n" + "Votos Si: 0\n" + "Votos No: 0\n";
            }

            string presidente = "\n" + separadorUno + "Funcionariado de Mesa Directiva\n" + "\tde Casilla\n\n\n" +
                                boletaDto.Presidente + "\n" + separadorUno + "        Presidente(a): Nombre y Firma\n\n\n";
            string secretario = boletaDto.Secretario + "\n" + separadorUno + "      Secretario(a): Nombre y Firma\n\n\n";
            string escrutadorUno = boletaDto.PrimerEscrutador + "\n" + separadorUno +
                                   "      Escrutador(a) 1: Nombre y Firma\n\n\n";
            string escrutadorDos = boletaDto.SegundoEscrutador + "\n" + separadorUno +
                                   "      Escrutador(a) 2: Nombre y Firma \n";

            mensaje = cabezera + mensajeHead + fechaHora + eleccion + datosUno + datosDos + separadorUno + headPartidos + partidos +
                      presidente + secretario + escrutadorUno + escrutadorDos;
            return mensaje;
        }


        public string estructuraBoletaResultadosMecanismos(BoletaInicialMecanismosRequest _boletas)
        {
            BoletaInicialMecanismosRequest boletaDto = new BoletaInicialMecanismosRequest()
            {
                Distrito = _boletas.Distrito,
                Entidad = _boletas.Entidad,
                Folio = _boletas.Folio,
                Municipio = _boletas.Municipio,
                Preguntas = _boletas.Preguntas,
                SeccionElectoral = _boletas.SeccionElectoral,
                MecanismoTipo = _boletas.MecanismoTipo,
                Presidente = _boletas.Presidente,
                Secretario = _boletas.Secretario,
                PrimerEscrutador = _boletas.PrimerEscrutador,
                SegundoEscrutador = _boletas.SegundoEscrutador
            };

            string cabezera = "             OPLE VERACRUZ\n";
            string mensajeHead = "ACTA DE CÓMPUTO DE CASILLA\n\n";
            string fechaHora = "Fecha: " + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day +
                               "    " + "Hora: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" +
                               DateTime.Now.Second + "hrs." + "\n";
            string eleccion = "Tipo de mecanismo: " + boletaDto.MecanismoTipo + "\n";
            string datosUno = "Entidad: " + boletaDto.Entidad + "  Distrito: " + boletaDto.Distrito + "\nMunicipio: " +
                              boletaDto.Municipio + "\n";
            string datosDos = "Sección: " + boletaDto.SeccionElectoral + "\n";
            string separadorUno = "------------------------------------------------\n";
            string headPartidos = "Que en presencia del Funcionariado\nde Mesa Directiva de Casilla\ny representaciones de los partidos\npolíticos se clausuró y computaron\nquedando de la siguiente manera:\n" + separadorUno + "\tVOTACIÓN " + "\n";
            var lp = boletaDto.Preguntas.ToList();
            string partidos = "";
            foreach (var p in lp)
            {
                partidos = partidos + "\n" + p.Pregunta + "\n" + "Votos Si: " + p.RespuestaSi + "\n" + "Votos No: " + p.RespuestaNo + "\n";
            }

            string presidente = "\n" + separadorUno + "Funcionariado de Mesa Directiva\n" + "\tde Casilla\n\n\n" +
                                boletaDto.Presidente + "\n" + separadorUno + "        Presidente(a): Nombre y Firma\n\n\n";
            string secretario = boletaDto.Secretario + "\n" + separadorUno + "      Secretario(a): Nombre y Firma\n\n\n";
            string escrutadorUno = boletaDto.PrimerEscrutador + "\n" + separadorUno +
                                   "      Escrutador(a) 1: Nombre y Firma\n\n\n";
            string escrutadorDos = boletaDto.SegundoEscrutador + "\n" + separadorUno +
                                   "      Escrutador(a) 2: Nombre y Firma \n";

            mensaje = cabezera + mensajeHead + fechaHora + eleccion + datosUno + datosDos + separadorUno + headPartidos + partidos +
                      presidente + secretario + escrutadorUno + escrutadorDos;
            return mensaje;
        }

    }
}
