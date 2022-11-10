using System.Collections.Generic;

namespace Urna.DAL.Entities
{
    public class Elecciones
    {
        public string TipoEleccion { get; set; }
        public string CantidadBoletas { get; set; }
        public string Folio { get; set; }
        public List<Partidos.Partidos> Partidos { get; set; }
    }
}