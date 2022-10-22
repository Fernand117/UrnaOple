using System;
using System.Collections.Generic;
using System.Text;

namespace Urna.COMMON.DTOS.Escolares
{
    public class EscolarRequest
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public List<DAL.Entities.Escolares> Escolares { get; set; }
    }
}
