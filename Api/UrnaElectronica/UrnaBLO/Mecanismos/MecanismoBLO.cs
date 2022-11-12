using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Urna.COMMON.DTOS;
using Urna.COMMON.RESOURCES;
using Urna.COMMON.DTOS.Mecanismos;
using Urna.DAO.Mecanismos;

namespace Urna.BLO.Mecanismos
{
    public class MecanismoBLO
    {
        public async Task<ApiResponse> Create(ConfiguracionMecanismosRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = UrnaResources.MensajeOk;
                apiResponse.Data = await new MecanismoDAO().Create(request);
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
                apiResponse.Data = await new MecanismoDAO().Read();
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
                apiResponse.Data = await new MecanismoDAO().Read(codigo);
            }
            catch (Exception)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = UrnaResources.MensajeError;
                apiResponse.Data = null;
            }

            return apiResponse;
        }

        public async Task<ApiResponse> Update(ConfiguracionMecanismosRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = UrnaResources.MensajeOk;
                apiResponse.Data = await new MecanismoDAO().Update(request);
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
                apiResponse.Data = await new MecanismoDAO().Delete(id);
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
