using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
					string codigo = "U-" + DateTime.Now.Year+ DateTime.Now.Month+ DateTime.Now.Day+ DateTime.Now.Hour+ DateTime.Now.Minute+ DateTime.Now.Second;
					Configuracion configuracion = new Configuracion()
					{
						Fecha = DateTime.Now,
						Configuraciones = JsonSerializer.Serialize(request),
						codigo = codigo
						
					};

					await context.AddAsync(configuracion);
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
					var elecciones = await context.Configuracion
												  .ToListAsync();

				}
			}
			catch (Exception) { }

			return response;
		}

		public async Task<EleccionDTO> Read(string codigo)
		{
			EleccionDTO response = new EleccionDTO();

			try
			{
				using (UrnaContext context = new UrnaContext())
				{
					var eleccion = await context.Configuracion
												.Where(e => e.codigo.Trim() == codigo.Trim())
												
												.FirstOrDefaultAsync();
					response.Fecha = eleccion.Fecha;
					response.codigo = eleccion.codigo;
					response.Configuraciones = eleccion.Configuraciones;




				}
			}
			catch (Exception es) { }

			return response;
		}

		public async Task<EleccionRequest> Update(EleccionRequest request)
		{
			try
			{
				using (UrnaContext context = new UrnaContext())
				{
					var config = await context.Configuracion
											  .Where(e => e.Id == request.Id)
											  .FirstOrDefaultAsync();

					config.Configuraciones = JsonSerializer.Serialize(request);

					await context.SaveChangesAsync();
				


                }
			}
			catch (Exception ex) { }

			return request;
		}

		public async Task<EleccionRequest> Delete(int id)
		{
			try
			{
				using (UrnaContext context = new UrnaContext())
				{
					var configuracion = await context.Configuracion
												.Where(e => e.Id == id)
												.FirstOrDefaultAsync();

					if (configuracion != null)
					{
						context.Entry(configuracion).State = EntityState.Deleted;
						await context.SaveChangesAsync();
					}
				}
			}
			catch (Exception ex) { }

			return new EleccionRequest()
			{
				Id = id
			};
		}
	}
}
