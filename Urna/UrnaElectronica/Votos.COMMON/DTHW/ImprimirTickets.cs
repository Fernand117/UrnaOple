using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Votos.COMMON.DTOS.Boletas;

namespace Votos.COMMON.DTHW
{
    public class ImprimirTickets
    {
        private string mensaje { get; set; }
        private Image _image { get; set; }

        public void imprimirComprobante(BoletasDTO request)
        {
            mensaje = estructuraTicket(request);
            Console.WriteLine(mensaje);
            PrintDocument pf = new PrintDocument();
            pf.PrintPage += Pf_PrintPage;
            pf.Print();
        }
        public void imprimirComprobanteEscolares(BoletasDTO request)
        {
            mensaje = estructuraTicketEscolares(request);
            Console.WriteLine(mensaje);
            PrintDocument pf = new PrintDocument();
            pf.DefaultPageSettings.PrinterSettings.PrinterName = "POS-80-Series";
            pf.PrintPage += Pf_PrintPage;
            pf.Print();
        }

        public void imprimirComprobanteMecanismos(BoletasDTO request)
        {
            mensaje = estructuraTicketMecanismos(request);
            Console.WriteLine(mensaje);
            PrintDocument pf = new PrintDocument();
            Console.WriteLine(1);
            pf.DefaultPageSettings.PrinterSettings.PrinterName = "POS-80-Series";
            Console.WriteLine(2);
            pf.PrintPage += Pf_PrintPage;
            pf.Print();
            Console.WriteLine(3);
        }

        public void imprimirBoletaCeros(BoletaInicialRequest request)
        {
            mensaje = estructuraBoletaCeros(request);
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PrinterSettings.PrinterName = "POS-80-Series";   
            pd.PrintPage +=  new PrintPageEventHandler(Pf_PrintPage);
            pd.Print();
        }

        public void imprimirBoletaCerosMecanismos(BoletaInicialMecanismosRequest request)
        {
            mensaje = estructuraBoletaCerosMecanismos(request);
            Console.WriteLine(mensaje);
            PrintDocument pd = new PrintDocument();
            Console.WriteLine(1);
            pd.DefaultPageSettings.PrinterSettings.PrinterName = "POS-80-Series";
            pd.PrintPage += Pd_PrintPageNormal;
            Console.WriteLine(2);
            pd.Print();
            Console.WriteLine(4);
        }
        public void imprimirBoletaCerosEscolares(BoletaInicialRequest request)
        {
            mensaje = estructuraBoletaCerosEscolares(request);
            Console.WriteLine(mensaje);
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PrinterSettings.PrinterName = "POS-80-Series";
            pd.PrintPage += Pd_PrintPageNormal;
            pd.Print();
        }

        public async void imprimirBoletaCierre(BoletaFinalRequest request)
        {
            mensaje = estructuraBoletaResultados(request);
            Console.WriteLine("COD QR" + request.QrCode);
            string image64 = await GetImageAsBase64Url(request.QrCode);
            _image = Base64ToImage(image64);
            Console.WriteLine(mensaje);
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PrinterSettings.PrinterName = "POS-80-Series";
            pd.PrintPage +=  new PrintPageEventHandler(Pd_PrintPage);
            pd.Print();
        }
        public async void imprimirBoletaCierreMecanismos(BoletaInicialMecanismosRequest request)
        {
            mensaje = estructuraBoletaResultadosMecanismos(request);
            string image64 = await GetImageAsBase64Url(request.QrCode);
            _image = Base64ToImage(image64);
            Console.WriteLine(mensaje);
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PrinterSettings.PrinterName = "POS-80-Series";
            pd.PrintPage +=  new PrintPageEventHandler(Pd_PrintPage);
            pd.Print();
        }

        public async void imprimirBoletaCierreEscolares(BoletaFinalRequest request)
        {
            mensaje = estructuraBoletaResultadosEscolares(request);
            string image64 = await GetImageAsBase64Url(request.QrCode);
            _image = Base64ToImage(image64);
            Console.WriteLine(mensaje);
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PrinterSettings.PrinterName = "POS-80-Series";
            pd.PrintPage +=  new PrintPageEventHandler(Pd_PrintPage);
            pd.Print();
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Image image = Image.FromFile("C:\\LOGOTIPO_OPLE.png");
            Bitmap imageOple = new Bitmap(image, 120, 80);

            Bitmap imageBit = new Bitmap(_image, 100, 100);
            Font font = new Font("Arial", 11);

            SolidBrush brush = new SolidBrush(Color.Black);

            //g.DrawString(mensaje, font, brush, new Rectangle(0, 0));
            g.DrawImage(imageOple, 20, 0);
            g.DrawImage(imageBit, 170, 0);
            g.DrawString(mensaje, font, brush, 0, 120);
        }
        
        private void Pd_PrintPageNormal(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Image image = Image.FromFile("C:\\LOGOTIPO_OPLE.png");
            Bitmap imageOple = new Bitmap(image, 120, 80);

            Font font = new Font("Arial", 11);

            SolidBrush brush = new SolidBrush(Color.Black);

            //g.DrawString(mensaje, font, brush, new Rectangle(0, 0));
            g.DrawImage(imageOple, 20, 0);

            g.DrawString(mensaje, font, brush, 0, 120);
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

        public string estructuraTicketEscolares(BoletasDTO _boletas)
        {
            BoletasDTO boletaDto = new BoletasDTO()
            {
                Partido = _boletas.Partido,
            };

            string cabezera = "           OPLE VERACRUZ\n";
            string mensajeHead = "      Comprobante de votación\n";
            string fechaHora = "Fecha: " + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "    " + "Hora: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "hrs." + "\n";
            string eleccion = "Elecciones escolares: " + "\n";
            string separadorUno = "------------------------------------------------\n";
            string partidos = "      Votaste por el candidato\n\n";
            string partidoNombre = "     " + boletaDto.Partido + "\n";

            string mensajeEstructura = cabezera + mensajeHead + fechaHora + eleccion + separadorUno
                      + partidos + partidoNombre;

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
                res = "      Respuesta: Si";
            } else
            {
                res = "      Respuesta: No";
            }

            if (boletaDto.Partido == "Voto nulo")
            {
                res = "";
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
                QrCode = _boletas.QrCode,
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
                SegundoEscrutador = _boletas.SegundoEscrutador,
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
                partidosFirmas += "\n" + separadorUno + "       RPP: " + p.partido +
                                  ": Nombre y Firma\n\n\n";
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
                partidos = partidos + "\n" + p.Partido + "\n" + "Votos Si: 0\n" + "Votos No: 0\n";
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
                QrCode = _boletas.QrCode,
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
                partidos = partidos + "\n" + p.Partido + "\n" + "Votos Si: " + p.RespuestaSi + "\n" + "Votos No: " + p.RespuestaNo + "\n";
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

        // *************************************************************************************************************************************************

        public string estructuraBoletaCerosEscolares(BoletaInicialRequest _boletas)
        {
            BoletaInicialRequest boletaDto = new BoletaInicialRequest()
            {
                Partidos = _boletas.Partidos,
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
            string eleccion = "Elecciones Escolares" + "\n";
            string separadorUno = "------------------------------------------------\n";
            string headPartidos = "Que en presencia del Funcionariado\nde Mesa Directiva de Casilla\ny representaciones de los partidos\npolíticos se inicializó y verificó\nque el sistema se encuentra en\nceros, así como el contenedor de\ntestigos de votos se encuentra vacío.\n" + separadorUno + "\tCandidatos escolares";
            var lp = boletaDto.Partidos.ToList();
            string partidos = "";
            foreach (var p in lp)
            {
                partidos = partidos + "\n" + "Candidato: " + p.Hipocoristico + "\n" + "Votos: 0\n";
            }

            string presidente = "\n" + separadorUno + "Funcionariado de Mesa Directiva\n" + "\tde Casilla\n\n\n" +
                                boletaDto.Presidente + "\n" + separadorUno + "        Presidente(a): Nombre y Firma\n\n\n";
            string secretario = boletaDto.Secretario + "\n" + separadorUno + "      Secretario(a): Nombre y Firma\n\n\n";
            string escrutadorUno = boletaDto.PrimerEscrutador + "\n" + separadorUno +
                                   "      Escrutador(a) 1: Nombre y Firma\n\n\n";
            string escrutadorDos = boletaDto.SegundoEscrutador + "\n" + separadorUno +
                                   "      Escrutador(a) 2: Nombre y Firma \n";

            mensaje = cabezera + mensajeHead + fechaHora + eleccion + separadorUno + headPartidos + partidos +
                      presidente + secretario + escrutadorUno + escrutadorDos;
            return mensaje;
        }

        public string estructuraBoletaResultadosEscolares(BoletaFinalRequest _boletas)
        {
            BoletaFinalRequest boletaDto = new BoletaFinalRequest()
            {
                QrCode = _boletas.QrCode,
                Partidos = _boletas.Partidos,
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
            string eleccion = "Elecciones escolares " + "\n";
            string separadorUno = "------------------------------------------------\n";
            string headPartidos = "Que en presencia del Funcionariado\nde Mesa Directiva de Casilla\ny representaciones de los partidos\npolíticos se clausuró y computaron\nquedando de la siguiente manera:\n" + separadorUno + "\tVOTACIÓN " + "\n";
            var lp = boletaDto.Partidos.ToList();
            string partidos = "";
            int total_votos = 0;
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
                                   "      Escrutador(a) 2: Nombre y Firma \n";

            mensaje = cabezera + mensajeHead + fechaHora + eleccion  + separadorUno + headPartidos + partidos +
                      txt_total + presidente + secretario + escrutadorUno + escrutadorDos;
            return mensaje;
        }
        
        public async static Task<string> GetImageAsBase64Url(String url)
        {
            var credentials = new NetworkCredential("", "");
            using (var handler = new HttpClientHandler { Credentials = credentials })
            using (var client = new HttpClient(handler))
            {
                Console.WriteLine(url);
                var bytes = await client.GetByteArrayAsync(url);
                string img = Convert.ToBase64String(bytes);
                return img;
            }
        }
        
        public Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

    }
}
