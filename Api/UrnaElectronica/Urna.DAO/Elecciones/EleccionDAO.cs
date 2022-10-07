using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urna.COMMON.DTOS.Elecciones;
using Urna.DAL.Context;
using Urna.DAL.Entities;

namespace Urna.DAO.Elecciones
{
    public class EleccionDAO
    {
        public async Task<EleccionRequest> Create(EleccionRequest request)
        {
			try
			{
				using (UrnaContext context = new UrnaContext())
				{
					Eleccion eleccion = new Eleccion()
					{
						TipoEleccion = request.TipoEleccion,
						Presidente = request.Presidente,
						Secretario = request.Secretario,
						PrimerEscrutador = request.PrimerEscrutador,
						SegundoEscrutador = request.SegundoEscrutador,
						CantidadBoletas = request.CantidadBoletas,
						Entidad = request.Entidad,
						Distrito = request.Distrito,
						Municipio = request.Municipio,
						SeccionElectoral = request.SeccionElectoral,
						TipoCasilla = request.TipoCasilla,
						Folio = request.Folio
					};

					await context.AddAsync(eleccion);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception ex) { }
			
			return request;
        }

		public async Task<List<EleccionDTO>> Read()
		{
			List<EleccionDTO> response = new List<EleccionDTO>();

			try
			{
				using (UrnaContext context = new UrnaContext())
				{
					var elecciones = await context.Eleccions
												  .ToListAsync();

					foreach (var e in elecciones)
					{
						response.Add(new EleccionDTO()
						{
							IdEleccion = e.Id,
							TipoEleccion = e.TipoEleccion,
							Presidente = e.Presidente,
							Secretario = e.Secretario,
							PrimerEscrutador = e.PrimerEscrutador,
							SegundoEscrutador = e.SegundoEscrutador,
							CantidadBoletas = e.CantidadBoletas,
							Entidad = e.Entidad,
							Distrito = e.Distrito,
							Municipio = e.Municipio,
							SeccionElectoral = e.SeccionElectoral,
							TipoCasilla = e.TipoCasilla,
							Folio = e.Folio,
						});
					}
				}
			}
			catch (Exception) { }

			return response;
		}

		public async Task<EleccionDTO> Read(int IdELeccion)
		{
			EleccionDTO response = new EleccionDTO();

			try
			{
				using(UrnaContext context = new UrnaContext())
				{
                    var eleccion = await context.Eleccions
												.Where(e => e.Id == IdELeccion)
												.FirstOrDefaultAsync();

					if (eleccion != null)
					{
						response.IdEleccion = eleccion.Id;
						response.TipoEleccion = eleccion.TipoEleccion;
						response.Presidente = eleccion.Presidente;
						response.Secretario = eleccion.Secretario;
						response.PrimerEscrutador = eleccion.PrimerEscrutador;
						response.SegundoEscrutador = eleccion.SegundoEscrutador;
						response.CantidadBoletas = eleccion.CantidadBoletas;
						response.Entidad = eleccion.Entidad;
						response.Distrito = eleccion.Distrito;
						response.Municipio = eleccion.Municipio;
						response.SeccionElectoral = eleccion.SeccionElectoral;
						response.TipoCasilla = eleccion.TipoCasilla;
						response.Folio = eleccion.Folio;
					}
				}
			}
			catch (Exception es) { }

			return response;
		}

		public async Task<EleccionRequest> Update(EleccionRequest request)
		{
			try
			{
				using(UrnaContext context = new UrnaContext())
				{
                    var eleccion = await context.Eleccions
												.Where(e => e.Id == request.IdEleccion)
												.FirstOrDefaultAsync();

					if (eleccion != null)
					{
						eleccion.Id = request.IdEleccion;
						eleccion.TipoEleccion = request.TipoEleccion;
						eleccion.Presidente = request.Presidente;
						eleccion.Secretario = request.Secretario;
						eleccion.PrimerEscrutador = request.PrimerEscrutador;
						eleccion.SegundoEscrutador = request.SegundoEscrutador;
						eleccion.CantidadBoletas = request.CantidadBoletas;
						eleccion.Entidad = request.Entidad;
						eleccion.Distrito = request.Distrito;
						eleccion.Municipio = request.Municipio;
						eleccion.SeccionElectoral = request.SeccionElectoral;
						eleccion.TipoCasilla = request.TipoCasilla;
						eleccion.Folio = request.Folio;
						await context.SaveChangesAsync();
					}
				}
			}
			catch (Exception ex) { }

			return request;
		}

		public async Task<EleccionRequest> Delete(int id)
		{
			try
			{
				using(UrnaContext context = new UrnaContext())
				{
                    var eleccion = await context.Eleccions
												.Where(e => e.Id == id)
												.FirstOrDefaultAsync();

					if (eleccion != null)
					{
						await context.SaveChangesAsync();
					}
				}
			}
			catch (Exception ex) { }

			return new EleccionRequest()
			{
				IdEleccion = id
			};
		}
    }
}
