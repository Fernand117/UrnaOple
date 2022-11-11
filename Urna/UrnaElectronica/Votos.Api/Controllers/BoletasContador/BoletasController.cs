using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Votos.BLO.ContadorBoletas;
using Votos.COMMON.DTOS;
using Votos.COMMON.DTOS.Boletas;

namespace Votos.Api.Controllers.BoletasContador
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletasController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] BoletasRequest request) => await new BoletasBLO().Create(request);

        [HttpPost("imprimir/boletainicial")]
        public async Task<ActionResult<ApiResponse>> PostImprimirBoletaInicial([FromBody] BoletaInicialRequest request) => await new BoletasBLO().Print(request);


        [HttpPost("imprimir/boletafinal")]
        public async Task<ActionResult<ApiResponse>> PostImprimirBoletaFinal([FromBody] BoletaFinalRequest request) => await new BoletasBLO().Print_Clausura(request);

        [HttpPut]
        public async Task<ActionResult<ApiResponse>> Update([FromBody] BoletasRequest request) => await new BoletasBLO().Update(request);

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Read() => await new BoletasBLO().Read();

        [HttpDelete]
        public async Task<ActionResult<ApiResponse>> Delete() => await new BoletasBLO().Delete();
    }
}