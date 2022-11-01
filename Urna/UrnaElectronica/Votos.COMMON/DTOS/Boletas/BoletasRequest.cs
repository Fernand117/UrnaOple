namespace Votos.COMMON.DTOS.Boletas
{
    public class BoletasRequest
    {
        public int Id { get; set; }
        public string TipoEleccion { get; set; }
        public string CantidadBoletas { get; set; }
    }
}