using System;
using System.Collections.Generic;
using System.Text;
using Urna.DAL.Entities.Firmas;
using Urna.DAL.Entities.Preguntas;

namespace Urna.COMMON.DTOS.Mecanismos
{
    public class MecanismoRequest
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public List<DAL.Entities.Mecanismos> Mecanismos { get; set; }
    }
}
