using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Votos.COMMON.DTHW;
using Votos.COMMON.DTOS.Boletas;
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
                    var voto = await context.Gubernaturas
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
                    mensajesLCD.sendMensaje("Votando.");

                    ImprimirTickets imprimirTickets = new ImprimirTickets();
                    imprimirTickets.imprimirComprobante(boletasDto);*/

                    if (voto == null)
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

        public async Task<List<GubernaturaDTO>> Read()
        {
            List<GubernaturaDTO> response = new List<GubernaturaDTO>();
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var votos = await context.Gubernaturas.ToListAsync();
                    foreach (var v in votos)
                    {
                        response.Add(new GubernaturaDTO()
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