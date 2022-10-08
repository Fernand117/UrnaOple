using CONFIG.COMMON;
using CONFIG.COMMON.DTOS.Elecciones;
using CONFIG.DAO.Elecciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONFIG.BL.Elecciones
{
    public class EleccionesBLO
    {
        public async Task<ApiResponse> Create(EleccionesRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();

            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseMessage = "Transacción completada.";
                apiResponse.Data = await new EleccionesDAO().Create(request);
            }
            catch (Exception)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseMessage = "Error en la transacción.";
                apiResponse.Data = null;
            }

            return apiResponse;
        }
    }
}
