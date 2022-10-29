namespace Votos.DAL.Entities.MecanismoReferendum
{
    public class Referendums
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public string RespuestaSi { get; set; }
        public string RespuestaNo { get; set; }
    }
}