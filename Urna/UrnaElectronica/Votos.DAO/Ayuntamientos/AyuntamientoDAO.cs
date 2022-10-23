using System;
using System.Collections.Generic;
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
    }
}
