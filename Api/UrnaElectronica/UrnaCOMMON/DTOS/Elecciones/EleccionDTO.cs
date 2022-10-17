using System;

namespace Urna.COMMON.DTOS.Elecciones
{
    public class EleccionDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string codigo { get; set; }
        public string Configuraciones { get; set; }
    }
}
