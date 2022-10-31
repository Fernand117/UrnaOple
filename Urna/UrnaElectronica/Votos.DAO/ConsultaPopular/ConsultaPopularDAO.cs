using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Votos.COMMON.DTOS.ConsultaPopular;
using Votos.DAL.Context;
using Votos.DAL.Entities.ConsultasPopulares;

namespace Votos.DAO.ConsultaPopular
{
    public class ConsultaPopularDAO
    {
        public async Task<ConsultaPopularRequest> Create(ConsultaPopularRequest request)
        {
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var voto = await context.ConsultasPopulares
                        .Where(v => v.Pregunta == request.Pregunta)
                        .FirstOrDefaultAsync();

                    if (voto == null)
                    {
                        Consulta consultaPopular = new Consulta()
                        {
                            Id = request.Id,
                            Pregunta = request.Pregunta,
                            RespuestaSi = request.RespuestaSi,
                            RespuestaNo = request.RespuestaNo
                        };

                        await context.AddAsync(consultaPopular);
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        int votoSiActual = int.Parse(voto.RespuestaSi);
                        int votoNoActual = int.Parse(voto.RespuestaNo);

                        if (int.Parse(request.RespuestaSi) > 0)
                        {
                            votoSiActual++;
                            voto.RespuestaSi = votoSiActual.ToString();
                        }

                        else
                        {
                            votoNoActual++;
                            voto.RespuestaNo = votoNoActual.ToString();
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

        public async Task<List<ConsultaPopularDTO>> Read()
        {
            List<ConsultaPopularDTO> response = new List<ConsultaPopularDTO>();
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var votos = await context.ConsultasPopulares.ToListAsync();
                    foreach (var v in votos)
                    {
                        response.Add(new ConsultaPopularDTO()
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