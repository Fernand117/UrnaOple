using System;
using System.Collections.Generic;
using System.Text;

namespace Votos.COMMON.DTOS.Ayuntamientos
{
    public class AyuntamientoRequest
    {
        public int Id { get; set; }
        public string Partido { get; set; }
        public string Voto { get; set; }

    }
}
