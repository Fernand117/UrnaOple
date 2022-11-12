namespace Urna.COMMON.DTOS.Mecanismos
{
    public class ConfiguracionMecanismosRequest
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public MecanismoRequest Mecanismos { get; set; }
    }
}