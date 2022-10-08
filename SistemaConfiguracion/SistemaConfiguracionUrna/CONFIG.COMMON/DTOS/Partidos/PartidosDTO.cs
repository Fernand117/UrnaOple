using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONFIG.COMMON.DTOS.Partidos
{
    public class PartidosDTO
    {
        public int Id { get; set; }
        public string Logotipo { get; set; }
        public string Propietario { get; set; }
        public string Suplente { get; set; }
        public string Hipocoristico { get; set; }
        public string Cargo { get; set; }
        public string TipoCandidatura { get; set; }

        public static implicit operator PartidosDTO(List<PartidosDTO> v)
        {
            throw new NotImplementedException();
        }
    }
}
