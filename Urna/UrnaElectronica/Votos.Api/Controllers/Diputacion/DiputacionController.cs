using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Votos.BLO.Diputaciones;
using Votos.COMMON.DTOS;
using Votos.COMMON.DTOS.Diputaciones;

namespace Votos.Api.Controllers.Diputacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiputacionController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] DiputacionRequest request) => await new DiputacionesBLO().Create(request);
        
        [HttpPost("guardar")]
        public async Task<ActionResult<ApiResponse>> GuardarCandidato([FromBody] DiputacionRequest request) => await new DiputacionesBLO().GuardarCandidato(request);

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Read() => await new DiputacionesBLO().Read();
    }
}