using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Votos.BLO.Escolares;
using Votos.COMMON.DTOS;
using Votos.COMMON.DTOS.Escolares;

namespace Votos.Api.Controllers.Escolar
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolarController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] EscolaresRequest request) =>
            await new EscolaresBLO().Create(request);
    }
}