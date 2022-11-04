namespace Votos.COMMON.DTOS.Referendum
{
    public class ReferendumRequest
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public string RespuestaSi { get; set; }
        public string RespuestaNo { get; set; }

        //Datos para imprimir el ticket
        public string TipoEleccion { get; set; }
        public string Entidad { get; set; }
        public string Distrito { get; set; }
        public string Municipio { get; set; }
        public string Seccion { get; set; }
        public string Casilla { get; set; }
        public string Folio { get; set; }
    }
}