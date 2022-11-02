using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<ApiResponse>> Post([FromBody] BoletasRequest request) =>
            await new BoletasBLO().Create(request);

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Update([FromBody] BoletasRequest request) =>
            await new BoletasBLO().Update(request);
    }
}