using System;
using System.Threading.Tasks;
using Votos.COMMON.DTOS;
using Votos.COMMON.DTOS.Gubernaturas;
using Votos.COMMON.RESOURCES;
using Votos.DAO.Gubernaturas;

namespace Votos.BLO.Gubernaturas
{
    public class GubernaturasBLO
    {
        public async Task<ApiResponse> Create(GubernaturaRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = Resources.MensajeOk;
                apiResponse.Data = await new GubernaturasDAO().Create(request);
            }
            catch (Exception e)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = Resources.MensajeError;
                apiResponse.Data = null;
            }
            return apiResponse;
        }
    }
}