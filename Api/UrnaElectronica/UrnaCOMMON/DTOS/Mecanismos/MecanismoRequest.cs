using System;
using System.Collections.Generic;
using System.Text;
using Urna.DAL.Entities.Firmas;
using Urna.DAL.Entities.Preguntas;

namespace Urna.COMMON.DTOS.Mecanismos
{
    public class MecanismoRequest
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
        public List<Firmas> Firmas { get; set; }
        public List<Preguntas> Preguntas { get; set; }
    }
}
