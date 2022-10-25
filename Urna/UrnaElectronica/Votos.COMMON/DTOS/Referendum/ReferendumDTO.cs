namespace Votos.COMMON.DTOS.Referendum
{
    public class ReferendumDTO
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public string RespuestaSi { get; set; }
        public string RespuestaNo { get; set; }
    }
}