using System;
using System.Collections.Generic;
using System.Text;

namespace Votos.COMMON.DTOS.Gubernaturas
{
    public class GubernaturaRequest
    {
        public int Id { get; set; }
        public string Partido { get; set; }
        public string Voto { get; set; }

        //Datos para imprimir el ticket
        public string TipoEleccion { get; set; }
        public string Entidad { get; set; }
        public string Distrito { get; set; }
        public string Municipio { get; set; }
        public string Seccion { get; set; }
        public string Casilla { get; set; }
        public string Folio { get; set; }
    }
}
