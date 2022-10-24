using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
					Ayuntamiento ayuntamiento = new Ayuntamiento()
					{
						Id = request.Id,
						Partido = request.Partido,
						Voto = request.Voto
					};

					await context.AddAsync(ayuntamiento);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception) { }

			return request;
        }

		//Este metodo esta en periodo de prueba NO SE ECUENTRA FUNCIONAL

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
