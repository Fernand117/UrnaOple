using CONFIG.COMMON.DTOS.Partidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCU.UWP.Lists
{
    public class ListaPartidos
    {
        public List<PartidosDTO> partidos;

        public void SetPartidos()
        {
            partidos = new List<PartidosDTO>();
        }
    }
}
