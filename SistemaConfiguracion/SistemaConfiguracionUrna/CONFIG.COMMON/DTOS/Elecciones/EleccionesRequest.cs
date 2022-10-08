using CONFIG.COMMON.DTOS.Partidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONFIG.COMMON.DTOS.Elecciones
{
    public class EleccionesRequest
    {
        public int Id { get; set; }
        public string TipoEleccion { get; set; }
        public string Presidente { get; set; }
        public string Secretario { get; set; }
        public string PrimerEscrutador { get; set; }
        public string SegundoEscrutador { get; set; }
        public string CantidadBoletas { get; set; }
        public string Entidad { get; set; }
        public string Distrito { get; set; }
        public string Municipio { get; set; }
        public string SeccionElectoral { get; set; }
        public string TipoCasilla { get; set; }
        public string Folio { get; set; }
        public List<PartidosDTO> Partidos { get; set; }
    }
}
