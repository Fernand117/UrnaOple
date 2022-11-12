using System.Collections.Generic;

namespace Urna.DAL.Entities
{
    public class Mecanismos
    {
        public string Presidente { get; set; } 
        public string Secretario { get; set; } 
        public string PrimerEscrutador { get; set; } 
        public string SegundoEscrutador { get; set; }
        public string Entidad { get; set; } 
        public string Distrito { get; set; } 
        public string Municipio { get; set; } 
        public string SeccionElectoral { get; set; }
        public string CodigoPresidente { get; set; }
        public List<TipoMecanismo> TipoMecanismos { get; set; }
    }
}