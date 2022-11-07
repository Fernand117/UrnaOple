using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Votos.COMMON.DTHW;
using Votos.COMMON.DTOS.Ayuntamientos;
using Votos.COMMON.DTOS.Boletas;
using Votos.DAL.Context;
using Votos.DAL.Entities.ContadorBoletas;

namespace Votos.DAO.Boletas
{
    public class BoletasDAO
    {
        public async Task<BoletasRequest> Create(BoletasRequest request)
        {
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var boleta = await context.Boletas
                        .Where(b => b.TipoEleccion == request.TipoEleccion)
                        .FirstOrDefaultAsync();

                    if (boleta == null)
                    {
                        BoletasContador boletas = new BoletasContador()
                        {
                            Id = request.Id,
                            CantidadBoletas = request.CantidadBoletas,
                            TipoEleccion = request.TipoEleccion
                        };

                        await context.AddAsync(boletas);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception e)
            {
                request.TipoEleccion = e.Message;
            }
            return request;
        }

        public async Task<BoletasRequest> Update(BoletasRequest request)
        {
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var boleta = await context.Boletas
                        .Where(b => b.TipoEleccion == request.TipoEleccion)
                        .FirstOrDefaultAsync();

                    int cantidadBoletasActual = int.Parse(boleta.CantidadBoletas);
                    cantidadBoletasActual--;
                    boleta.CantidadBoletas = cantidadBoletasActual.ToString();
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                request.TipoEleccion = e.Message;
            }
            return request;
        }

        public async Task<List<BoletasDTO>> Read()
        {
            List<BoletasDTO> response = new List<BoletasDTO>();
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var boletas = await context.Boletas.ToListAsync();

                    foreach (var v in boletas)
                    {
                        response.Add(new BoletasDTO()
                        {
                            Id = v.Id,
                            TipoEleccion = v.TipoEleccion,
                            CantidadBoletas = v.CantidadBoletas
                        });
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return response;
        }

        public async Task<BoletaInicialRequest> ImprimirBoletaInicial(BoletaInicialRequest request)
        {
            try
            {
                BoletaInicialRequest boletaInicialRequest = new BoletaInicialRequest()
                {
                    CantidadBoletas = request.CantidadBoletas,
                    Casilla = request.Casilla,
                    Distrito = request.Distrito,
                    Entidad = request.Entidad,
                    Folio = request.Folio,
                    Municipio = request.Municipio,
                    Seccion = request.Seccion,
                    TipoEleccion = request.TipoEleccion,
                    Presidente = request.Presidente,
                    Secretario = request.Secretario,
                    PrimerEscrutador = request.PrimerEscrutador,
                    SegundoEscrutador = request.SegundoEscrutador,
                    Partidos = request.Partidos
                };

                ImprimirTickets imprimirTickets = new ImprimirTickets();
                imprimirTickets.imprimirBoletaCeros(boletaInicialRequest);

                MensajesLCD mensajesLcd = new MensajesLCD();
                mensajesLcd.sendMensaje("Imprimiendo voleta inicial");
            }
            catch (Exception e)
            {
                request.TipoEleccion = e.Message;
            }
            return request;
        }
    }
}