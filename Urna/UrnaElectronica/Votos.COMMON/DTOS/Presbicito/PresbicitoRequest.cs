namespace Votos.COMMON.DTOS.Presbicito
{
    public class PresbicitoRequest
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public string RespuestaSi { get; set; }
        public string RespuestaNo { get; set; }
    }
}