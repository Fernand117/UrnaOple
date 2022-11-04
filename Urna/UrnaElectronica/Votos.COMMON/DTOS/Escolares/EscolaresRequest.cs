namespace Votos.COMMON.DTOS.Escolares
{
    public class EscolaresRequest
    {
        public int Id { get; set; }
        public string Partido { get; set; }
        public string Voto { get; set; }

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