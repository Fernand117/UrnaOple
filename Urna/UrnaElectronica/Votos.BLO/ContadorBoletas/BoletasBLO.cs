using System;
using System.Threading.Tasks;
using Votos.COMMON.DTOS;
using Votos.COMMON.DTOS.Boletas;
using Votos.COMMON.RESOURCES;
using Votos.DAO.Ayuntamientos;
using Votos.DAO.Boletas;

namespace Votos.BLO.ContadorBoletas
{
    public class BoletasBLO
    {
        public async Task<ApiResponse> Create(BoletasRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = Resources.MensajeOk;
                apiResponse.Data = await new BoletasDAO().Create(request);
            }
            catch (Exception e)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = Resources.MensajeError;
                apiResponse.Data = null;
            }
            return apiResponse;
        }

        public async Task<ApiResponse> Update(BoletasRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = Resources.MensajeOk;
                apiResponse.Data = await new BoletasDAO().Update(request);
            }
            catch (Exception e)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = Resources.MensajeError;
                apiResponse.Data = null;
            }
            return apiResponse;
        }

        public async Task<ApiResponse> Read()
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = Resources.MensajeOk;
                apiResponse.Data = await new BoletasDAO().Read();
            }
            catch (Exception e)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = Resources.MensajeError;
                apiResponse.Data = null;
            }
            return apiResponse;
        }

        public async Task<ApiResponse> Print(BoletaInicialRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = Resources.MensajeOk;
                apiResponse.Data = await new BoletasDAO().ImprimirBoletaInicial(request);
            }
            catch (Exception e)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = Resources.MensajeError;
                apiResponse.Data = null;
            }
            return apiResponse;
        }

        public async Task<ApiResponse> PrintMecanismos(BoletaInicialMecanismosRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = Resources.MensajeOk;
                apiResponse.Data = await new BoletasDAO().ImprimirBoletaInicialMecanismos(request);
            }
            catch (Exception e)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = Resources.MensajeError;
                apiResponse.Data = null;
            }
            return apiResponse;
        }

        public async Task<ApiResponse> PrintEscolares(BoletaInicialRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = Resources.MensajeOk;
                apiResponse.Data = await new BoletasDAO().ImprimirBoletaInicialEscolares(request);
            }
            catch (Exception e)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = Resources.MensajeError;
                apiResponse.Data = null;
            }
            return apiResponse;
        }

        public async Task<ApiResponse> Print_Clausura(BoletaFinalRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = Resources.MensajeOk;
                apiResponse.Data = await new BoletasDAO().ImprimirBoletaFinal(request);
            }
            catch (Exception e)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = Resources.MensajeError;
                apiResponse.Data = null;
            }
            return apiResponse;
        }

        public async Task<ApiResponse> Print_Clausura_Mecanismos(BoletaInicialMecanismosRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = Resources.MensajeOk;
                apiResponse.Data = await new BoletasDAO().ImprimirBoletaFinalMecanismos(request);
            }
            catch (Exception e)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = Resources.MensajeError;
                apiResponse.Data = null;
            }
            return apiResponse;
        }

        public async Task<ApiResponse> Print_Clausura_Escolares(BoletaFinalRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = Resources.MensajeOk;
                apiResponse.Data = await new BoletasDAO().ImprimirBoletaFinalEscolares(request);
            }
            catch (Exception e)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = Resources.MensajeError;
                apiResponse.Data = null;
            }
            return apiResponse;
        }

        public async Task<ApiResponse> Delete()
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = Resources.MensajeOk;
                apiResponse.Data = await new BoletasDAO().Delete();
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