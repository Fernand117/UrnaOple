using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Urna.DAL.Entities
{
    public class Escolares
    {
        public int Id { get; set; }
        public string Presidente { get; set; }
        public string Secretario { get; set; }
        public string PrimerEscrutador { get; set; }
        public string SegundoEscrutador { get; set; }
        public string NombreInstitucion { get; set; }
        public string CantidadBoletas { get; set; }
        public List<Partidos.Partidos> Partidos { get; set; }
    }
}
