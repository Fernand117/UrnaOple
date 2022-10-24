using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Votos.BLO.Gubernaturas;
using Votos.COMMON.DTOS;
using Votos.COMMON.DTOS.Gubernaturas;

namespace Votos.Api.Controllers.Gubernatura
{
    [Route("api/[controller]")]
    [ApiController]
    public class GubernaturaController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] GubernaturaRequest request) =>
            await new GubernaturasBLO().Create(request);
    }
}