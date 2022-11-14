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
                    TipoCasilla = request.TipoCasilla,
                    Distrito = request.Distrito,
                    Entidad = request.Entidad,
                    Folio = request.Folio,
                    Municipio = request.Municipio,
                    SeccionElectoral = request.SeccionElectoral,
                    TipoEleccion = request.TipoEleccion,
                    Presidente = request.Presidente,
                    Secretario = request.Secretario,
                    PrimerEscrutador = request.PrimerEscrutador,
                    SegundoEscrutador = request.SegundoEscrutador,
                    Partidos = request.Partidos
                };

                ImprimirTickets imprimirTickets = new ImprimirTickets();
                imprimirTickets.imprimirBoletaCeros(boletaInicialRequest);

                /*MensajesLCD mensajesLcd = new MensajesLCD();
                mensajesLcd.sendMensaje("Imprimiendo boleta inicial");*/
            }
            catch (Exception e)
            {
                request.TipoEleccion = e.Message;
            }
            return request;
        }

        public async Task<BoletaInicialMecanismosRequest> ImprimirBoletaInicialMecanismos(BoletaInicialMecanismosRequest request)
        {
            try
            {
                BoletaInicialMecanismosRequest boletaInicialRequest = new BoletaInicialMecanismosRequest()
                {
                    Distrito = request.Distrito,
                    Entidad = request.Entidad,
                    Folio = request.Folio,
                    Municipio = request.Municipio,
                    SeccionElectoral = request.SeccionElectoral,
                    MecanismoTipo = request.MecanismoTipo,
                    Presidente = request.Presidente,
                    Secretario = request.Secretario,
                    PrimerEscrutador = request.PrimerEscrutador,
                    SegundoEscrutador = request.SegundoEscrutador,
                    Preguntas = request.Preguntas
                };

                ImprimirTickets imprimirTickets = new ImprimirTickets();
                imprimirTickets.imprimirBoletaCerosMecanismos(boletaInicialRequest);

                /*MensajesLCD mensajesLcd = new MensajesLCD();
                mensajesLcd.sendMensaje("Imprimiendo boleta inicial");*/
            }
            catch (Exception e)
            {
                request.MecanismoTipo = e.Message;
            }
            return request;
        }

        public async Task<BoletaInicialRequest> ImprimirBoletaInicialEscolares(BoletaInicialRequest request)
        {
            try
            {
                BoletaInicialRequest boletaInicialRequest = new BoletaInicialRequest()
                {
                    Presidente = request.Presidente,
                    Secretario = request.Secretario,
                    PrimerEscrutador = request.PrimerEscrutador,
                    SegundoEscrutador = request.SegundoEscrutador,
                    Partidos = request.Partidos
                };

                ImprimirTickets imprimirTickets = new ImprimirTickets();
                imprimirTickets.imprimirBoletaCerosEscolares(boletaInicialRequest);

                /*MensajesLCD mensajesLcd = new MensajesLCD();
                mensajesLcd.sendMensaje("Imprimiendo boleta inicial");*/
            }
            catch (Exception e)
            {
                request.TipoEleccion = e.Message;
            }
            return request;
        }

        public async Task<BoletaFinalRequest> ImprimirBoletaFinal(BoletaFinalRequest request)
        {
            try
            {
                BoletaFinalRequest boletaFinalRequest = new BoletaFinalRequest()
                {
                    CantidadBoletas = request.CantidadBoletas,
                    TipoCasilla = request.TipoCasilla,
                    Distrito = request.Distrito,
                    Entidad = request.Entidad,
                    Folio = request.Folio,
                    Municipio = request.Municipio,
                    SeccionElectoral = request.SeccionElectoral,
                    TipoEleccion = request.TipoEleccion,
                    Presidente = request.Presidente,
                    Secretario = request.Secretario,
                    PrimerEscrutador = request.PrimerEscrutador,
                    SegundoEscrutador = request.SegundoEscrutador,
                    Partidos = request.Partidos
                };

                ImprimirTickets imprimirTickets = new ImprimirTickets();
                imprimirTickets.imprimirBoletaCierre(boletaFinalRequest);

                /*MensajesLCD mensajesLcd = new MensajesLCD();
                mensajesLcd.sendMensaje("Imprimiendo boleta de clausura");*/
            }
            catch (Exception e)
            {
                request.TipoEleccion = e.Message;
            }
            return request;
        }

        public async Task<BoletaInicialMecanismosRequest> ImprimirBoletaFinalMecanismos(BoletaInicialMecanismosRequest request)
        {
            try
            {
                BoletaInicialMecanismosRequest boletaInicialRequest = new BoletaInicialMecanismosRequest()
                {
                    Distrito = request.Distrito,
                    Entidad = request.Entidad,
                    Folio = request.Folio,
                    Municipio = request.Municipio,
                    SeccionElectoral = request.SeccionElectoral,
                    MecanismoTipo = request.MecanismoTipo,
                    Presidente = request.Presidente,
                    Secretario = request.Secretario,
                    PrimerEscrutador = request.PrimerEscrutador,
                    SegundoEscrutador = request.SegundoEscrutador,
                    Preguntas = request.Preguntas
                };

                ImprimirTickets imprimirTickets = new ImprimirTickets();
                imprimirTickets.imprimirBoletaCierreMecanismos(boletaInicialRequest);

                /*MensajesLCD mensajesLcd = new MensajesLCD();
                mensajesLcd.sendMensaje("Imprimiendo boleta de clausura");*/
            }
            catch (Exception e)
            {
                request.MecanismoTipo = e.Message;
            }
            return request;
        }

        public async Task<BoletaFinalRequest> ImprimirBoletaFinalEscolares(BoletaFinalRequest request)
        {
            try
            {
                BoletaFinalRequest boletaFinalRequest = new BoletaFinalRequest()
                {
                    Presidente = request.Presidente,
                    Secretario = request.Secretario,
                    PrimerEscrutador = request.PrimerEscrutador,
                    SegundoEscrutador = request.SegundoEscrutador,
                    Partidos = request.Partidos
                };

                ImprimirTickets imprimirTickets = new ImprimirTickets();
                imprimirTickets.imprimirBoletaCierreEscolares(boletaFinalRequest);

                /*MensajesLCD mensajesLcd = new MensajesLCD();
                mensajesLcd.sendMensaje("Imprimiendo boleta de clausura");*/
            }
            catch (Exception e)
            {
                request.TipoEleccion = e.Message;
            }
            return request;
        }
        public async Task<BoletasRequest> Delete()
        {
            try
            {
                using (VotoContext context = new VotoContext())
                {
                    var boletas = await context.Boletas.ToListAsync();
                    var ayuntamientos = await context.Ayuntamientos.ToListAsync();
                    var consulta = await context.ConsultasPopulares.ToListAsync();
                    var diputacion = await context.Diputaciones.ToListAsync();
                    var escolares = await context.Escolares.ToListAsync();
                    var gubernatura = await context.Gubernaturas.ToListAsync();
                    var presbicito = await context.Presbicitos.ToListAsync();
                    var referendum = await context.Referendums.ToListAsync();
                    
                    context.Boletas.RemoveRange(boletas);
                    context.Ayuntamientos.RemoveRange(ayuntamientos);
                    context.ConsultasPopulares.RemoveRange(consulta);
                    context.Diputaciones.RemoveRange(diputacion);
                    context.Escolares.RemoveRange(escolares);
                    context.Gubernaturas.RemoveRange(gubernatura);
                    context.Presbicitos.RemoveRange(presbicito);
                    context.Referendums.RemoveRange(referendum);

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return new BoletasRequest()
            {
                Id = 0
            };
        }
    }
}