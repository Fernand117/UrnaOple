﻿using System.Collections.Generic;

namespace CONFIG.DAL.Entitys.Elecciones
{
    public class Elecciones
    {
        public int Id { get; set; }
        public string TipoEleccion { get; set; }
        public string Presidente { get; set; }
        public string Secretario { get; set; }
        public string PrimerEscrutador { get; set; }
        public string SegundoEscrutador { get; set; }
        public string CantidadBoletas { get; set; }
        public string Entidad { get; set; }
        public string Distrito { get; set; }
        public string Municipio { get; set; }
        public string SeccionElectoral { get; set; }
        public string TipoCasilla { get; set; }
        public string Folio { get; set; }
        public List<Partidos.Partidos> Partidos { get; set; }
    }
}
