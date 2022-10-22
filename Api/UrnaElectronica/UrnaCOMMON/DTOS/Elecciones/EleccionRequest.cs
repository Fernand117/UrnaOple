using System.Collections.Generic;
using Urna.DAL.Entities.Partidos;

namespace Urna.COMMON.DTOS.Elecciones
{
    public class EleccionRequest
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public List<DAL.Entities.Elecciones> Elecciones { get; set; }
    }
}
