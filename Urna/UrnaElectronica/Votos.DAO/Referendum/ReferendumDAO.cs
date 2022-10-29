using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Votos.COMMON.DTOS.Referendum;
using Votos.DAL.Context;
using Votos.DAL.Entities.MecanismoReferendum;

namespace Votos.DAO.Referendum
{
    public class ReferendumDAO
    {
        public async Task<ReferendumRequest> Create(ReferendumRequest request)
        {
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var voto = await context.Referendums
                        .Where(v => v.Pregunta == request.Pregunta)
                        .FirstOrDefaultAsync();

                    if (voto == null)
                    {
                        Referendums referendum = new Referendums()
                        {
                            Id = request.Id,
                            Pregunta = request.Pregunta,
                            RespuestaSi = request.RespuestaSi,
                            RespuestaNo = request.RespuestaNo
                        };

                        await context.AddAsync(referendum);
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        int votoActualSi = int.Parse(voto.RespuestaSi);
                        int votoActualNo = int.Parse(voto.RespuestaNo);

                        if (int.Parse(request.RespuestaSi) > 0)
                        {
                            votoActualSi++;
                            voto.RespuestaSi = votoActualSi.ToString();
                        }

                        if (int.Parse(request.RespuestaNo) > 0)
                        {
                            votoActualNo++;
                            voto.RespuestaNo = votoActualNo.ToString();
                        }

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

        public async Task<List<ReferendumDTO>> Read()
        {
            List<ReferendumDTO> response = new List<ReferendumDTO>();
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var votos = await context.Referendums.ToListAsync();
                    foreach (var v in votos)
                    {
                        response.Add(new ReferendumDTO()
                        {
                            Id = v.Id,
                            Pregunta = v.Pregunta,
                            RespuestaSi = v.RespuestaSi,
                            RespuestaNo = v.RespuestaNo
                        });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return response;
        }
    }
}