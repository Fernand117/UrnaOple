using System.Collections.Generic;

namespace Urna.DAL.Entities
{
    public class TipoMecanismo
    {
        public string MecanismoTipo { get; set; }
        public string Nombre { get; set; }
        public string Objeto { get; set; }
        public string CantidadBoletas { get; set; }
        public string Folio { get; set; }
        public List<Preguntas.Preguntas> Preguntas { get; set; }
    }
}