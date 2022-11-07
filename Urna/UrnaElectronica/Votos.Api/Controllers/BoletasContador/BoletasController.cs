using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Votos.BLO.ContadorBoletas;
using Votos.BLO.Diputaciones;
using Votos.COMMON.DTOS;
using Votos.COMMON.DTOS.Boletas;

namespace Votos.Api.Controllers.BoletasContador
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletasController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] BoletasRequest request) =>
            await new BoletasBLO().Create(request);

        [HttpPost("imprimir/boletainicial")]
        public async Task<ActionResult<ApiResponse>>
            PostImprimirBoletaInicial([FromBody] BoletaInicialRequest request) => await new BoletasBLO().Print(request);

        [HttpPut]
        public async Task<ActionResult<ApiResponse>> Update([FromBody] BoletasRequest request) =>
            await new BoletasBLO().Update(request);

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Read() => await new BoletasBLO().Read();
    }
}