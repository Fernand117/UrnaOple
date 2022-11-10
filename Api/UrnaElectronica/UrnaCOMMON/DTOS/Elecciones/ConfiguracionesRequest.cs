namespace Urna.COMMON.DTOS.Elecciones
{
    public class ConfiguracionesRequest
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public ProcesosElectoralesRequest Procesos { get; set; }
    }
}