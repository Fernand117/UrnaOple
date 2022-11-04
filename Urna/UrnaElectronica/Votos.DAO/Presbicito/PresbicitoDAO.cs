using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Votos.COMMON.DTHW;
using Votos.COMMON.DTOS.Boletas;
using Votos.COMMON.DTOS.Presbicito;
using Votos.DAL.Context;
using Votos.DAL.Entities.MecanismoPresbicito;

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

                    BoletasDTO boletasDto = new BoletasDTO()
                    {
                        Partido = request.Pregunta,
                        TipoEleccion = request.TipoEleccion,
                        Entidad = request.Entidad,
                        Distrito = request.Distrito,
                        Municipio = request.Municipio,
                        Seccion = request.Seccion,
                        Casilla = request.Casilla,
                        Folio = request.Folio
                    };

                    MensajesLCD mensajesLCD = new MensajesLCD();
                    mensajesLCD.sendMensaje("Votando.");

                    ImprimirTickets imprimirTickets = new ImprimirTickets();
                    imprimirTickets.imprimirComprobante(boletasDto);

                    if (voto == null)
                    {
                        Presbicitos presbicito = new Presbicitos()
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

                        else
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