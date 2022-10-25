using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Votos.COMMON.DTOS.Ayuntamientos;
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
			catch (Exception) { }

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

		//Este metodo esta en periodo de prueba NO SE ECUENTRA FUNCIONAL
		//Gracias por informar acerca de este método, estaremos verificando el funcionamiento del mismo, tqm :')

		//public async Task<AyuntamientoRequest> Update(AyuntamientoRequest request)
		//{
		//	try
		//	{
		//		using (VotoContext context = new VotoContext())
		//		{

		//			var nombre = await context.Ayuntamientos
		//									  .Include(a => a.Voto == request.Voto)
		//									  .Where(a => a.Id == request.Id)
		//									  .AnyAsync(a => a.Partido == request.Partido);

		//			if (nombre)
		//			{
		//				request.Partido = nombre.ToString();
		//				await context.SaveChangesAsync();
		//			}
		//			else
		//			{
		//				request.Voto = request.Voto;
		//			}
		//		}
		//	}
		//	catch (Exception ex) { }

		//	return request;
		//}
    }
}
