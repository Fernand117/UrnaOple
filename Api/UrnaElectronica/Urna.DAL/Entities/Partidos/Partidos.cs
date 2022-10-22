using System;
using System.Collections.Generic;
using System.Text;

namespace Urna.DAL.Entities.Partidos
{
    public class Partidos
    {
        public int Id { get; set; }
        public string Logotipo { get; set; }
        public string Propietario { get; set; }
        public string Suplente { get; set; }
        public string Hipocoristico { get; set; }
        public string Cargo { get; set; }
        public string TipoCandidatura { get; set; }
    }
}
