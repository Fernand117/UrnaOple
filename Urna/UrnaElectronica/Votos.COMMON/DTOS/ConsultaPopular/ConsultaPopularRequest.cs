namespace Votos.COMMON.DTOS.ConsultaPopular
{
    public class ConsultaPopularRequest
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public string RespuestaSi { get; set; }
        public string RespuestaNo { get; set; }
    }
}