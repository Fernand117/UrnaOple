using System;
using System.Collections.Generic;
using System.Text;

namespace Votos.DAL.Entities.Diputaciones
{
    public class Diputacion
    {
        public int Id { get; set; }

        public string Partido { get; set; }
        public string Voto { get; set; }
        public string Tipo { get; set; }
    }
}
