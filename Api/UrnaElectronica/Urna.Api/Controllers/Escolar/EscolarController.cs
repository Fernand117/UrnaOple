using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Urna.BLO.Escolares;
using Urna.COMMON.DTOS;
using Urna.COMMON.DTOS.Escolares;

namespace Urna.Api.Controllers.Escolar
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolarController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Get() => await new EscolarBLO().Read();

        [HttpGet("code/{codigo}")]
        public async Task<ActionResult<ApiResponse>> Get(string codigo) => await new EscolarBLO().Read(codigo);

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] EscolarRequest request) => await new EscolarBLO().Create(request);

        [HttpPut]
        public async Task<ActionResult<ApiResponse>> Put([FromBody] EscolarRequest request) => await new EscolarBLO().Update(request);

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(int id) => await new EscolarBLO().Delete(id);
    }
}
