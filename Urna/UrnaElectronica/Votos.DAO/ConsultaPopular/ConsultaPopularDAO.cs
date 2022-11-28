using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Votos.COMMON.DTHW;
using Votos.COMMON.DTOS.Boletas;
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

                    BoletasDTO boletasDto = new BoletasDTO()
                    {
                        Partido = request.Pregunta,
                        TipoEleccion = request.TipoEleccion,
                        Entidad = request.Entidad,
                        Distrito = request.Distrito,
                        Municipio = request.Municipio,
                        Seccion = request.Seccion,
                        Casilla = request.Casilla,
                        Folio = request.Folio,
                        RespuestaSi = request.RespuestaSi
                    };

                    /*MensajesLCD mensajesLCD = new MensajesLCD();
                    mensajesLCD.sendMensaje("Votando.");*/

                    ImprimirTickets imprimirTickets = new ImprimirTickets();
                    imprimirTickets.imprimirComprobanteMecanismos(boletasDto);

                    if (voto == null)
                    {
                        if (int.Parse(request.RespuestaSi) > 0)
                        {
                            Consulta consultaPopular = new Consulta()
                            {
                                Id = request.Id,
                                Pregunta = request.Pregunta,
                                RespuestaSi = "1",
                                RespuestaNo = "0"
                            };
                            await context.AddAsync(consultaPopular);
                            await context.SaveChangesAsync();
                        }
                        else if(int.Parse(request.RespuestaSi) == 0) {
                            Consulta consultaPopular = new Consulta()
                            {
                                Id = request.Id,
                                Pregunta = request.Pregunta,
                                RespuestaSi = "0",
                                RespuestaNo = "1"
                            };
                            await context.AddAsync(consultaPopular);
                            await context.SaveChangesAsync();
                        }
                        else
                        {
                            Consulta consultaPopular = new Consulta()
                            {
                                Id = request.Id,
                                Pregunta = request.Pregunta,
                                RespuestaSi = "1",
                                RespuestaNo = "0"
                            };
                            await context.AddAsync(consultaPopular);
                            await context.SaveChangesAsync();
                        }
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
                    imprimirTickets.imprimirSeparador();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return request;
        }
        
        public async Task<ConsultaPopularRequest> GuardarConsulta(ConsultaPopularRequest request)
        {
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var voto = await context.ConsultasPopulares
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
                        Folio = request.Folio,
                        RespuestaSi = request.RespuestaSi
                    };

                    if (voto == null)
                    {
                        Consulta consultaPopular = new Consulta()
                        {
                            Id = request.Id,
                            Pregunta = request.Pregunta,
                            RespuestaSi = "0",
                            RespuestaNo = "0"
                        };
                        await context.AddAsync(consultaPopular);
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