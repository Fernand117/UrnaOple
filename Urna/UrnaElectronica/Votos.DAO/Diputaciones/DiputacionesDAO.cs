using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Votos.COMMON.DTHW;
using Votos.COMMON.DTOS.Boletas;
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
                    var voto = await context.Diputaciones
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
                    imprimirTickets.imprimirComprobante(boletasDto);

                    if (voto == null)
                    {
                        Diputacion diputacion = new Diputacion()
                        {
                            Id = request.Id,
                            Partido = request.Partido,
                            Voto = request.Voto,
                            Tipo = request.Tipo
                        };

                        await context.AddAsync(diputacion);
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

        public async Task<DiputacionRequest> GuardarCandidatos(DiputacionRequest request)
        {
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var voto = await context.Diputaciones
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
                        Diputacion diputacion = new Diputacion()
                        {
                            Id = request.Id,
                            Partido = request.Partido,
                            Voto = request.Voto,
                            Tipo = request.Tipo
                        };

                        await context.AddAsync(diputacion);
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
        
        public async Task<List<DiputacionDTO>> Read()
        {
            List<DiputacionDTO> response = new List<DiputacionDTO>();
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var votos = await context.Diputaciones.ToListAsync();
                    foreach (var v in votos)
                    {
                        response.Add(new DiputacionDTO()
                        {
                            Id = v.Id,
                            Partido = v.Partido,
                            Voto = v.Voto,
                            Tipo = v.Tipo
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