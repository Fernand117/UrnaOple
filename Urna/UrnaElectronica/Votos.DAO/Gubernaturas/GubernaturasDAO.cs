using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Votos.COMMON.DTOS.Gubernaturas;
using Votos.DAL.Context;
using Votos.DAL.Entities.Gubernaturas;

namespace Votos.DAO.Gubernaturas
{
    public class GubernaturasDAO
    {
        public async Task<GubernaturaRequest> Create(GubernaturaRequest request)
        {
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    Gubernatura gubernatura = new Gubernatura()
                    {
                        Id = request.Id,
                        Partido = request.Partido,
                        Voto = request.Voto
                    };

                    await context.AddAsync(gubernatura);
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