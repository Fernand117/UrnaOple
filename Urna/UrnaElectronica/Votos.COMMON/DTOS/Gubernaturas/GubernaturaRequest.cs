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
    }
}
