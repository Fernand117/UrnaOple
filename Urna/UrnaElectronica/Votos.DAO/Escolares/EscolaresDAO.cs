using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Votos.COMMON.DTHW;
using Votos.COMMON.DTOS.Boletas;
using Votos.COMMON.DTOS.Escolares;
using Votos.DAL.Context;
using Votos.DAL.Entities.Escolares;

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

                    BoletasDTO boletasDto = new BoletasDTO()
                    {
                        Partido = request.Partido,
                        TipoEleccion = request.TipoEleccion,
                        Entidad = request.Entidad,
                        Distrito = request.Distrito,
                        Municipio = request.Municipio,
                        Seccion = request.Seccion,
                        Casilla = request.Casilla,
                        Folio = request.Folio
                    };

                    /*MensajesLCD mensajesLCD = new MensajesLCD();
                    mensajesLCD.sendMensaje("Votando.");*/

                    ImprimirTickets imprimirTickets = new ImprimirTickets();
                    imprimirTickets.imprimirComprobanteEscolares(boletasDto);

                    if (voto == null)
                    {
                        Escolar escolaresDto = new Escolar()
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
        
        public async Task<EscolaresRequest> GuardarCandidatos(EscolaresRequest request)
        {
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var voto = await context.Escolares
                        .Where(v => v.Partido == request.Partido)
                        .FirstOrDefaultAsync();

                    BoletasDTO boletasDto = new BoletasDTO()
                    {
                        Partido = request.Partido,
                        TipoEleccion = request.TipoEleccion,
                        Entidad = request.Entidad,
                        Distrito = request.Distrito,
                        Municipio = request.Municipio,
                        Seccion = request.Seccion,
                        Casilla = request.Casilla,
                        Folio = request.Folio
                    };
                    
                    if (voto == null)
                    {
                        Escolar escolaresDto = new Escolar()
                        {
                            Id = request.Id,
                            Partido = request.Partido,
                            Voto = request.Voto
                        };

                        await context.AddAsync(escolaresDto);
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

        public async Task<List<EscolaresDTO>> Read()
        {
            List<EscolaresDTO> response = new List<EscolaresDTO>();
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var votos = await context.Escolares.ToListAsync();
                    foreach (var v in votos)
                    {
                        response.Add(new EscolaresDTO()
                        {
                            Id = v.Id,
                            Partido = v.Partido,
                            Voto = v.Voto
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