using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Urna.COMMON.DTOS.Elecciones;
using Urna.COMMON.DTOS.Mecanismos;
using Urna.DAL.Context;
using Urna.DAL.Entities;

namespace Urna.DAO.Mecanismos
{
    public class MecanismoDAO
    {
        public async Task<MecanismoRequest> Create(MecanismoRequest request)
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
					var mecanismos = await context.Configuracion
												  .ToListAsync();

					foreach (var m in mecanismos)
					{
						response.Add(new ConfiguracionesDTO()
						{
							Id = m.Id,
							Fecha = m.Fecha,
							Codigo = m.Codigo,
							Categoria = m.Categoria,
							Configuraciones = JsonSerializer.Serialize(m)
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
					var mecanismo = await context.Configuracion
												 .Where(m => m.Codigo.Trim() == codigo.Trim())
												 .FirstOrDefaultAsync();

					response.Fecha = mecanismo.Fecha;
					response.Codigo = mecanismo.Codigo;
					response.Categoria = mecanismo.Categoria;
					response.Configuraciones = mecanismo.Configuraciones;
				}
			}
			catch (Exception ex) { }

			return response;
		}

		public async Task<MecanismoRequest> Update(MecanismoRequest request)
		{
			try
			{
				using (UrnaContext context = new UrnaContext())
				{
					var config = await context.Configuracion
											  .Where(m => m.Id == request.Id)
											  .FirstOrDefaultAsync();

					config.Configuraciones = JsonSerializer.Serialize(request);

					await context.SaveChangesAsync();
				}
			}
			catch (Exception ex) { }

			return request;
		}

		public async Task<MecanismoRequest> Delete(int id)
		{
			try
			{
				using (UrnaContext context = new UrnaContext())
				{
					var configuracion = await context.Configuracion
													 .Where(m => m.Id == id)
													 .FirstOrDefaultAsync();

					if (configuracion != null)
					{
						context.Entry(configuracion).State = EntityState.Deleted;
						await context.SaveChangesAsync();
					}
				}
			}
			catch (Exception ex) { }

			return new MecanismoRequest()
			{
				Id = id
			};
		}
    }
}
