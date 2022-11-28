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
        public async Task<ActionResult<ApiResponse>> Post([FromBody] GubernaturaRequest request) => await new GubernaturasBLO().Create(request);
        
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> GuardarCandidato([FromBody] GubernaturaRequest request) => await new GubernaturasBLO().GuardarCandidato(request);

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Read() => await new GubernaturasBLO().Read();
    }
}