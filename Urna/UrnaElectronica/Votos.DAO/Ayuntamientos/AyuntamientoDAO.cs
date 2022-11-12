using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Votos.COMMON.DTHW;
using Votos.COMMON.DTOS.Ayuntamientos;
using Votos.COMMON.DTOS.Boletas;
using Votos.DAL.Context;
using Votos.DAL.Entities.Ayuntamientos;

namespace Votos.DAO.Ayuntamientos
{
    public class AyuntamientoDAO
    {
        public async Task<AyuntamientoRequest> Create(AyuntamientoRequest request)
        {

            try
            {
				using (VotoContext context = new VotoContext())
				{
					var voto = await context.Ayuntamientos
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
						Ayuntamiento ayuntamiento = new Ayuntamiento()
						{
							Id = request.Id,
							Partido = request.Partido,
							Voto = request.Voto
						};

						await context.AddAsync(ayuntamiento);
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
			catch (Exception e) {
				request.Partido = "Erro: " + e.ToString();
			}

			return request;
        }

        public async Task<List<AyuntamientoDTO>> Read()
        {
	        List<AyuntamientoDTO> response = new List<AyuntamientoDTO>();
	        try
	        {
		        using (VotoContext context = new VotoContext())
		        {
			        var votos = await context.Ayuntamientos.ToListAsync();

			        foreach (var v in votos)
			        {
				        response.Add(new AyuntamientoDTO()
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
