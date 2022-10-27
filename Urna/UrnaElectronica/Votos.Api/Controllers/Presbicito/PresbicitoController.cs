using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Votos.BLO.Presbicitos;
using Votos.COMMON.DTOS;
using Votos.COMMON.DTOS.Presbicito;

namespace Votos.Api.Controllers.Presbicito
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresbicitoController
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] PresbicitoRequest request) => await new PresbicitosBLO().Create(request);

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Read() => await new PresbicitosBLO().Read();
    }
}