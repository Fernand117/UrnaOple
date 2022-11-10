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
		public async Task<ConfiguracionesRequest> Create(ConfiguracionesRequest request)
		{
			try
			{
				using (UrnaContext context = new UrnaContext())
				{
					string codigo = "U-" + DateTime.Now.Year+ DateTime.Now.Month+ DateTime.Now.Day+ DateTime.Now.Hour+ DateTime.Now.Minute+ DateTime.Now.Second;
					Configuracion configuracion = new Configuracion()
					{
						Fecha = DateTime.Now,
						Codigo = codigo,
						Categoria = request.Categoria,
						Configuraciones = JsonSerializer.Serialize(request.Procesos)
					};

					await context.AddAsync(configuracion);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception ex) 
			{
				request.Categoria = ex.Message;
			}

			return request;
		}

		public async Task<List<ConfiguracionesDTO>> Read()
		{
			List<ConfiguracionesDTO> response = new List<ConfiguracionesDTO>();

			try
			{
				using (UrnaContext context = new UrnaContext())
				{
					var elecciones = await context.Configuracion
													.OrderByDescending(i => i)
													.ToListAsync();

					foreach (var e in elecciones)
					{
						response.Add(new ConfiguracionesDTO()
						{
							Id = e.Id,
							Fecha= e.Fecha,
							Codigo = e.Codigo,
							Categoria = e.Categoria,
							Configuraciones = JsonSerializer.Serialize(e.Configuraciones)
						});
					}

				}
			}
			catch (Exception) { }

			return response;
		}

		public async Task<ConfiguracionesDTO> Read(string codigo)
		{
			ConfiguracionesDTO response = new ConfiguracionesDTO();

			try
			{
				using (UrnaContext context = new UrnaContext())
				{
					var eleccion = await context.Configuracion
												.Where(e => e.Codigo.Trim() == codigo.Trim())
												
												.FirstOrDefaultAsync();
					response.Fecha = eleccion.Fecha;
					response.Codigo = eleccion.Codigo;
					response.Categoria = eleccion.Categoria;
					response.Configuraciones = eleccion.Configuraciones;
				}
			}
			catch (Exception es) { }

			return response;
		}

		public async Task<ConfiguracionesRequest> Update(ConfiguracionesRequest request)
		{
			try
			{
				using (UrnaContext context = new UrnaContext())
				{
					var config = await context.Configuracion
											  .Where(e => e.Id == request.Id)
											  .FirstOrDefaultAsync();

					config.Configuraciones = JsonSerializer.Serialize(request.Procesos);

					await context.SaveChangesAsync();
				}
			}
			catch (Exception ex) { }

			return request;
		}

		public async Task<ConfiguracionesRequest> Delete(int id)
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

			return new ConfiguracionesRequest()
			{
				Id = id
			};
		}
	}
}
