using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Votos.BLO.Referendums;
using Votos.COMMON.DTOS;
using Votos.COMMON.DTOS.Referendum;

namespace Votos.Api.Controllers.Referendum
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferendumController
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] ReferendumRequest request) =>
            await new ReferendumsBLO().Create(request);
    }
}