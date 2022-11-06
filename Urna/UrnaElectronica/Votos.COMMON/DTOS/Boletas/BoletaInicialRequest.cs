using System.Collections.Generic;

namespace Votos.COMMON.DTOS.Boletas
{
    public class BoletaInicialRequest
    {
        public int Id { get; set; }
        public string TipoEleccion { get; set; }
        public string CantidadBoletas { get; set; }

        //Datos para imprimir el ticket
        public string Entidad { get; set; }
        public string Distrito { get; set; }
        public string Municipio { get; set; }
        public string Seccion { get; set; }
        public string Casilla { get; set; }
        public string Folio { get; set; }
        public virtual List<PartidosDTO> Partidos { get; set; }
    }
}