using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Urna.COMMON.DTOS.Elecciones;
using Urna.COMMON.DTOS.Escolares;
using Urna.DAL.Context;
using Urna.DAL.Entities;

namespace Urna.DAO.Escolares
{
    public class EscolarDAO
    {
        public async Task<EscolarRequest> Create(EscolarRequest request)
        {
			try
			{
				using (UrnaContext context = new UrnaContext())
				{
					string codigo = "U-" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
					Configuracion configuracion = new Configuracion()
					{
						Fecha = DateTime.Now,
						Codigo = codigo,
						Categoria = request.Categoria,
						Configuraciones = JsonSerializer.Serialize(request)
					};

					await context.AddAsync(configuracion);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception ex) { }
			
			return request;
        }

		public async Task<List<ConfiguracionesDTO>> Read()
		{
			List<ConfiguracionesDTO> response = new List<ConfiguracionesDTO>();
			try
			{
				using (UrnaContext context = new UrnaContext())
				{
					var escolares = await context.Configuracion
												 .ToListAsync();

					foreach (var e in escolares)
					{
						response.Add(new ConfiguracionesDTO()
						{
							Id = e.Id,
							Fecha = e.Fecha,
							Codigo= e.Codigo,
							Categoria = e.Categoria,
							Configuraciones = JsonSerializer.Serialize(e)
						});
					}
				}
			}
			catch (Exception ex) { }

			return response;
		}

		public async Task<ConfiguracionesDTO> Read(string codigo)
		{
			ConfiguracionesDTO response = new ConfiguracionesDTO();

			try
			{
				using (UrnaContext context = new UrnaContext())
				{
					var escolar = await context.Configuracion
											   .Where(e => e.Codigo.Trim() == codigo.Trim())
											   .FirstOrDefaultAsync();

					response.Fecha = escolar.Fecha;
					response.Codigo = escolar.Codigo;
					response.Categoria = escolar.Categoria;
					response.Configuraciones = escolar.Configuraciones;
				}
			}
			catch (Exception ex) { }

			return response;
		}

		public async Task<EscolarRequest> Update(EscolarRequest request)
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

		public async Task<EscolarRequest> Delete(int id)
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

			return new EscolarRequest()
			{
				Id = id
			};
		}
    }
}
