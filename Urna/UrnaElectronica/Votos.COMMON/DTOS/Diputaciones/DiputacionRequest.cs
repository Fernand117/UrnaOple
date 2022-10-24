using System;
using System.Collections.Generic;
using System.Text;

namespace Votos.COMMON.DTOS.Diputaciones
{
    public class DiputacionRequest
    {
        public int Id { get; set; }
        public string Partido { get; set; }
        public string Voto { get; set; }
    }
}
