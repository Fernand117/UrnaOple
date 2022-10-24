using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Votos.COMMON.DTOS;
using Votos.COMMON.DTOS.Ayuntamientos;
using Votos.COMMON.RESOURCES;
using Votos.DAO.Ayuntamientos;

namespace Votos.BLO.Ayuntamientos
{
    public class AyuntamientoBLO
    {
        public async Task<ApiResponse> Create(AyuntamientoRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse.ResponseCode = Response.Success;
                apiResponse.ResponseText = Resources.MensajeOk;
                apiResponse.Data = await new AyuntamientoDAO().Create(request);
            }
            catch (Exception)
            {
                apiResponse.ResponseCode = Response.Error;
                apiResponse.ResponseText = Resources.MensajeError;
                apiResponse.Data = null;
            }

            return apiResponse;
        }

        //public async Task<ApiResponse> Update(AyuntamientoRequest request)
        //{
        //    ApiResponse apiResponse = new ApiResponse();
        //    try
        //    {
        //        apiResponse.ResponseCode = Response.Success;
        //        apiResponse.ResponseText = Resources.MensajeOk;
        //        apiResponse.Data = await new AyuntamientoDAO().Update(request);
        //    }
        //    catch (Exception)
        //    {
        //        apiResponse.ResponseCode = Response.Error;
        //        apiResponse.ResponseText = Resources.MensajeError;
        //        apiResponse.Data = null;
        //    }

        //    return apiResponse;
        //}
    }
}
