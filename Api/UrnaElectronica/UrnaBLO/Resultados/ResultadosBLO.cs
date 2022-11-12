using System;
using System.Threading.Tasks;
using Urna.COMMON.DTOS;
using Urna.COMMON.DTOS.Resultados;
using Urna.COMMON.RESOURCES;
using Urna.DAO.Resultados;

namespace Urna.BLO.Resultados
{
    public class ResultadosBLO
    {
        public async Task<ApiResponse> Create(ResultadosRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = UrnaResources.MensajeOk;
                apiResponse.Data = await new ResultadosDAO().Create(request);
            }
            catch (Exception e)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = UrnaResources.MensajeError;
                apiResponse.Data = null;
            }
            return apiResponse;
        }

        public async Task<ApiResponse> Read(string codigo)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = UrnaResources.MensajeOk;
                apiResponse.Data = await new ResultadosDAO().Read(codigo);
            }
            catch (Exception e)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = UrnaResources.MensajeError;
                apiResponse.Data = null;
            }
            return apiResponse;
        }
    }
}