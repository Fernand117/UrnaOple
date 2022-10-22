using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Urna.DAL.Entities
{
    public class Configuracion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Codigo { get; set; }
        public string Categoria { get; set; }
        public string Configuraciones { get; set; }
    }
}
