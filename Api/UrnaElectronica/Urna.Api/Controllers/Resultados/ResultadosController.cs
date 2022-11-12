using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Urna.BLO.Resultados;
using Urna.COMMON.DTOS;
using Urna.COMMON.DTOS.Resultados;

namespace Urna.Api.Controllers.Resultados
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadosController
    {
        [HttpGet("code/{codigo}")]
        public async Task<ActionResult<ApiResponse>> Get(string codigo) => await new ResultadosBLO().Read(codigo);

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] ResultadosRequest request) =>
            await new ResultadosBLO().Create(request);
    }
}