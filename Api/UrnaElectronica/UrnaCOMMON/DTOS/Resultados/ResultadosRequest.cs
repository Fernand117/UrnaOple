using System;
using System.Collections.Generic;

namespace Urna.COMMON.DTOS.Resultados
{
    public class ResultadosRequest
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Codigo { get; set; }
        public string Categoria { get; set; }
        public string QrCode { get; set; }
        public List<ResultadosLocalesRequest> Resultados { get; set; }
    }
}