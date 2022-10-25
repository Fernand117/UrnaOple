namespace Votos.DAL.Entities.Referendum
{
    public class Referendum
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public string RespuestaSi { get; set; }
        public string RespuestaNo { get; set; }
    }
}