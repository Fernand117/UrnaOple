using System;
using System.Collections.Generic;
using System.Text;

namespace Votos.COMMON.DTOS.Boletas
{
    public class BoletaInicialMecanismosRequest
    {
        public string QrCode { get; set; }
        public string MecanismoTipo { get; set; }

        //Datos para imprimir el ticket
        public string Entidad { get; set; }
        public string Distrito { get; set; }
        public string Municipio { get; set; }
        public string SeccionElectoral { get; set; }
        public string Folio { get; set; }

        //Datos de los representantes de las mesas directivas de casillas
        public string Presidente { get; set; }
        public string Secretario { get; set; }
        public string PrimerEscrutador { get; set; }
        public string SegundoEscrutador { get; set; }

        //Lista de preguntas registradas
        public virtual List<PreguntasDTO> Preguntas { get; set; }
    }
}
