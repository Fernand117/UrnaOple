using System.Collections.Generic;

namespace Urna.COMMON.DTOS.Resultados
{
    public class ResultadosLocalesRequest
    {
        public string TipoEleccion { get; set; }
        public List<DatosDTO> Datos { get; set; }
    }
}