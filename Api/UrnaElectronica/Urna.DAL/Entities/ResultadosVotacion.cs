using System;

namespace Urna.DAL.Entities
{
    public class ResultadosVotacion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Codigo { get; set; }
        public string Categoria { get; set; }
        public string Resultados { get; set; }
    }
}