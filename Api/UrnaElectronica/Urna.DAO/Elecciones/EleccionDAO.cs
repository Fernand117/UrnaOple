using System;
using System.Collections.Generic;
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
    }
}
