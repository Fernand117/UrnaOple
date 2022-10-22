using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Urna.COMMON.DTOS;
using Urna.COMMON.DTOS.Escolares;
using Urna.COMMON.RESOURCES;
using Urna.DAO.Escolares;

namespace Urna.BLO.Escolares
{
    public class EscolarBLO
    {
        public async Task<ApiResponse> Create(EscolarRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = UrnaResources.MensajeOk;
                apiResponse.Data = await new EscolarDAO().Create(request);
            }
            catch (Exception)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = UrnaResources.MensajeError;
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
                apiResponse.ResponseText = UrnaResources.MensajeOk;
                apiResponse.Data = await new EscolarDAO().Read();
            }
            catch (Exception)
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
                apiResponse.Data = await new EscolarDAO().Read(codigo);
            }
            catch (Exception)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = UrnaResources.MensajeError;
                apiResponse.Data = null;
            }

            return apiResponse;
        }

        public async Task<ApiResponse> Update(EscolarRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = UrnaResources.MensajeOk;
                apiResponse.Data = await new EscolarDAO().Update(request);
            }
            catch (Exception)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = UrnaResources.MensajeError;
                apiResponse.Data = null;
            }

            return apiResponse;
        }

        public async Task<ApiResponse> Delete(int id)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = UrnaResources.MensajeOk;
                apiResponse.Data = await new EscolarDAO().Delete(id);
            }
            catch (Exception)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = UrnaResources.MensajeError;
                apiResponse.Data = null;
            }

            return apiResponse;
        }
    }
}
