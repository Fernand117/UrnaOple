﻿using System;

namespace Urna.COMMON.DTOS.Elecciones
{
    public class ConfiguracionesDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Codigo { get; set; }
        public string Categoria { get; set; }
        public string Configuraciones { get; set; }
    }
}
