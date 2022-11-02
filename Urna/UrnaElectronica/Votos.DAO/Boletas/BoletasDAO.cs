using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Votos.COMMON.DTOS.Boletas;
using Votos.DAL.Context;
using Votos.DAL.Entities.ContadorBoletas;

namespace Votos.DAO.Boletas
{
    public class BoletasDAO
    {
        public async Task<BoletasRequest> Create(BoletasRequest request)
        {
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var boleta = await context.Boletas
                        .Where(b => b.TipoEleccion == request.TipoEleccion)
                        .FirstOrDefaultAsync();

                    if (boleta == null)
                    {
                        BoletasContador boletas = new BoletasContador()
                        {
                            Id = request.Id,
                            CantidadBoletas = request.CantidadBoletas,
                            TipoEleccion = request.TipoEleccion
                        };

                        await context.AddAsync(boletas);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception e)
            {
                request.TipoEleccion = e.Message;
            }
            return request;
        }

        public async Task<BoletasRequest> Update(BoletasRequest request)
        {
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var boleta = await context.Boletas
                        .Where(b => b.TipoEleccion == request.TipoEleccion)
                        .FirstOrDefaultAsync();

                    int cantidadBoletasActual = int.Parse(boleta.CantidadBoletas);
                    cantidadBoletasActual--;
                    boleta.CantidadBoletas = cantidadBoletasActual.ToString();
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                request.TipoEleccion = e.Message;
            }
            return request;
        }
    }
}