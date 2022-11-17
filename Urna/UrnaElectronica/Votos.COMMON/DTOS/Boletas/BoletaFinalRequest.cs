﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Votos.COMMON.DTOS.Boletas
{
    public class BoletaFinalRequest
    {
        public string QrCode { get; set; }
        public string TipoEleccion { get; set; }
        public string CantidadBoletas { get; set; }

        //Datos para imprimir el ticket
        public string Entidad { get; set; }
        public string Distrito { get; set; }
        public string Municipio { get; set; }
        public string SeccionElectoral { get; set; }
        public string TipoCasilla { get; set; }
        public string Folio { get; set; }
        
        //Datos de los representantes de las mesas directivas de casillas
        public string Presidente { get; set; }
        public string Secretario { get; set; }
        public string PrimerEscrutador { get; set; }
        public string SegundoEscrutador { get; set; }
        
        //Lista de partidos registrados
        public virtual List<PartidosVotosDTO> Partidos { get; set; }
    }
}
