using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Votos.COMMON.DTOS.Presbicito;
using Votos.DAL.Context;

namespace Votos.DAO.Presbicito
{
    public class PresbicitoDAO
    {
        public async Task<PresbicitoRequest> Create(PresbicitoRequest request)
        {
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var voto = await context.Presbicitos
                        .Where(v => v.Pregunta == request.Pregunta)
                        .FirstOrDefaultAsync();

                    if (voto == null)
                    {
                        DAL.Entities.Presbicito.Presbicito presbicito = new DAL.Entities.Presbicito.Presbicito()
                        {
                            Id = request.Id,
                            Pregunta = request.Pregunta,
                            RespuestaSi = request.RespuestaSi,
                            RespuestaNo = request.RespuestaNo
                        };

                        await context.AddAsync(presbicito);
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

        public async Task<List<PresbicitoDTO>> Read()
        {
            List<PresbicitoDTO> response = new List<PresbicitoDTO>();
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var votos = await context.Presbicitos.ToListAsync();
                    foreach (var v in votos)
                    {
                        response.Add(new PresbicitoDTO()
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