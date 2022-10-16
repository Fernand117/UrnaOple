using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Urna.BLO.Mecanismos;
using Urna.COMMON.DTOS;
using Urna.COMMON.DTOS.Mecanismos;

namespace Urna.Api.Controllers.Mecanismo
{
    [Route("api/[controller]")]
    [ApiController]
    public class MecanismoController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Get() => await new MecanismoBLO().Read();

        [HttpGet("code/{codigo}")]
        public async Task<ActionResult<ApiResponse>> Get(string codigo) => await new MecanismoBLO().Read(codigo);

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] MecanismoRequest request) => await new MecanismoBLO().Create(request);

        [HttpPut]
        public async Task<ActionResult<ApiResponse>> Put([FromBody] MecanismoRequest request) => await new MecanismoBLO().Update(request);

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(int id) => await new MecanismoBLO().Delete(id);
    }
}
