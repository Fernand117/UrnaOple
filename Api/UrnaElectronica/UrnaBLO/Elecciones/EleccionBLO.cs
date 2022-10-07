using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Urna.COMMON.DTOS;
using Urna.COMMON.DTOS.Elecciones;
using Urna.COMMON.RESOURCES;
using Urna.DAO.Elecciones;

namespace Urna.BLO.Elecciones
{
    public class EleccionBLO
    {
        public async Task<ApiResponse> Create(EleccionRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = UrnaResources.MensajeOk;
                apiResponse.Data = await new EleccionDAO().Create(request);
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
                apiResponse.Data = await new EleccionDAO().Read();
            }
            catch (Exception)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = UrnaResources.MensajeError;
                apiResponse.Data = null;
            }

            return apiResponse;
        }

        public async Task<ApiResponse> Read(int IdEleccion)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = UrnaResources.MensajeOk;
                apiResponse.Data = await new EleccionDAO().Read(IdEleccion);
            }
            catch (Exception)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = UrnaResources.MensajeError;
                apiResponse.Data = null;
            }

            return apiResponse;
        }

        public async Task<ApiResponse> Update(EleccionRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = UrnaResources.MensajeOk;
                apiResponse.Data = await new EleccionDAO().Update(request);
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
                apiResponse.Data = await new EleccionDAO().Delete(id);
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
