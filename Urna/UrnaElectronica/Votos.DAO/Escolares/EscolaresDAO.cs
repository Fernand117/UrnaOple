using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Votos.COMMON.DTOS.Escolares;
using Votos.DAL.Context;

namespace Votos.DAO.Escolares
{
    public class EscolaresDAO
    {
        public async Task<EscolaresRequest> Create(EscolaresRequest request)
        {
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var voto = await context.Escolares
                        .Where(v => v.Partido == request.Partido)
                        .FirstOrDefaultAsync();

                    if (voto == null)
                    {
                        DAL.Entities.Escolares.Escolares escolaresDto = new DAL.Entities.Escolares.Escolares()
                        {
                            Id = request.Id,
                            Partido = request.Partido,
                            Voto = request.Voto
                        };

                        await context.AddAsync(escolaresDto);
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        int votoActual = int.Parse(voto.Voto);
                        votoActual++;
                        voto.Voto = votoActual.ToString();

                        await context.SaveChangesAsync();
                    }
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