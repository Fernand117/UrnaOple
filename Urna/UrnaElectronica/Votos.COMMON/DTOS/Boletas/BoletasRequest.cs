namespace Votos.COMMON.DTOS.Boletas
{
    public class BoletasRequest
    {
        public int Id { get; set; }
        public string TipoEleccion { get; set; }
        public string CantidadBoletas { get; set; }

        //Datos para imprimir el ticket
        public string Entidad { get; set; }
        public string Distrito { get; set; }
        public string Municipio { get; set; }
        public string Seccion { get; set; }
        public string Casilla { get; set; }
        public string Folio { get; set; }
    }
}