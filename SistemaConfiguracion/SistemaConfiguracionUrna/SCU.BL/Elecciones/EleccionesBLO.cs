using SCU.COMMON;
using SCU.COMMON.Elecciones;
using SCU.COMMON.RESOURCES;
using SCU.DAO.Elecciones;

namespace SCU.BL.Elecciones
{
    public class EleccionesBLO
    {
        public async Task<ApiResponse> Create(EleccionesRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();

            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseMessage = Resources.MensajeOk;
                apiResponse.Data = await new EleccionesDAO().Create(request);
            }
            catch (Exception)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseMessage = Resources.MensajeError;
                apiResponse.Data = null;
            }

            return apiResponse;
        }
    }
}
