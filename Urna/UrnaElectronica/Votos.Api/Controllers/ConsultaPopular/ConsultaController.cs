using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Votos.BLO.ConsultasPopulares;
using Votos.COMMON.DTOS;
using Votos.COMMON.DTOS.ConsultaPopular;

namespace Votos.Api.Controllers.ConsultaPopular
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] ConsultaPopularRequest request) =>
            await new ConsultasPopularesBLO().Create(request);
    }
}