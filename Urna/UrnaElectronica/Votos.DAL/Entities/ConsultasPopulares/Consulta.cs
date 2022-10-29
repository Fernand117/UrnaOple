namespace Votos.DAL.Entities.ConsultasPopulares
{
    public class Consulta
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public string RespuestaSi { get; set; }
        public string RespuestaNo { get; set; }
    }
}