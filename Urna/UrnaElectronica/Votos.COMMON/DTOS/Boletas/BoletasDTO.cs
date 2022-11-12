namespace Votos.COMMON.DTOS.Boletas
{
    public class BoletasDTO
    {
        public int Id { get; set; }
        public string TipoEleccion { get; set; }
        public string CantidadBoletas { get; set; }
        public string Partido { get; set; }
        public string Entidad { get; set; }
        public string Distrito { get; set; }
        public string Municipio { get; set; }
        public string Seccion { get; set; }
        public string Casilla { get; set; }
        public string Folio { get; set; }
        public string RespuestaSi { get; set; }

    }
}