using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Urna.BLO.Elecciones;
using Urna.COMMON.DTOS;
using Urna.COMMON.DTOS.Elecciones;

namespace Urna.Api.Controllers.Eleccion
{
    [Route("api/[controller]")]
    [ApiController]
    public class EleccionController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Get() => await new EleccionBLO().Read();

        [HttpGet("code/{codigo}")]
        public async Task<ActionResult<ApiResponse>> Get(string codigo) => await new EleccionBLO().Read(codigo);

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] EleccionRequest request) => await new EleccionBLO().Create(request);

        [HttpPut]
        public async Task<ActionResult<ApiResponse>> Put([FromBody] EleccionRequest request) => await new EleccionBLO().Update(request);

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(int id) => await new EleccionBLO().Delete(id);
    }
}
