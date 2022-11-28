using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Votos.BLO.Ayuntamientos;
using Votos.COMMON.DTOS;
using Votos.COMMON.DTOS.Ayuntamientos;

namespace Votos.Api.Controllers.Ayuntamiento
{
    [Route("api/[controller]")]
    [ApiController]
    public class AyuntamientoController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] AyuntamientoRequest request) => await new AyuntamientoBLO().Create(request);
        
        [HttpPost("guardar")]
        public async Task<ActionResult<ApiResponse>> GuardarCandidato([FromBody] AyuntamientoRequest request) => await new AyuntamientoBLO().GuardarCandidatos(request);

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Read() => await new AyuntamientoBLO().Read();
    }
}
