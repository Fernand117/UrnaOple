using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Votos.COMMON.DTOS.Diputaciones;
using Votos.DAL.Context;
using Votos.DAL.Entities.Diputaciones;

namespace Votos.DAO.Diputaciones
{
    public class DiputacionesDAO
    {
        public async Task<DiputacionRequest> Create(DiputacionRequest request)
        {
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    Diputacion diputacion = new Diputacion()
                    {
                        Id = request.Id,
                        Partido = request.Partido,
                        Voto = request.Voto
                    };

                    await context.AddAsync(diputacion);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return request;
        }
    }
}