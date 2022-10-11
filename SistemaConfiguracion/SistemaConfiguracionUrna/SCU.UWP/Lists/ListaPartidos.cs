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
        private PartidosDTO partidos;
        private ListaPartidos() { }

        private static ListaPartidos _listaPartidos;


        public static ListaPartidos getInstance()
        {
            if (_listaPartidos == null)
            {
                _listaPartidos = new ListaPartidos();
            }
            return _listaPartidos;
        }

        public void agregarPartido(PartidosDTO partidosDTO)
        {
            partidos = partidosDTO;
        }

        public PartidosDTO getPartido()
        {
            return partidos;
        }
    }
}
