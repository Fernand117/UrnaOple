using System.Collections.Generic;

namespace Urna.DAL.Entities
{
    public class Mecanismos
    {
        public int Id { get; set; }
        public string TipoMecanismo { get; set; }
        public string Nombre { get; set; }
        public string Objeto { get; set; }
        public string Presidente { get; set; } 
        public string Secretario { get; set; } 
        public string PrimerEscrutador { get; set; } 
        public string SegundoEscrutador { get; set; } 
        public string CantidadBoletas { get; set; } 
        public string Entidad { get; set; } 
        public string Distrito { get; set; } 
        public string Municipio { get; set; } 
        public string SeccionElectoral { get; set; } 
        public string Folio { get; set; } 
        public List<Firmas.Firmas> Firmas { get; set; }
        public List<Preguntas.Preguntas> Preguntas { get; set; }
    }
}