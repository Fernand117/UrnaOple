using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Urna.COMMON.DTOS.Resultados;
using Urna.DAL.Context;
using Urna.DAL.Entities;

namespace Urna.DAO.Resultados
{
    public class ResultadosDAO
    {
        public async Task<ResultadosRequest> Create(ResultadosRequest request)
        {
            try
            {
                using (UrnaContext context = new UrnaContext())
                {
                    ResultadosVotacion resultadosVotacion = new ResultadosVotacion()
                    {
                        Fecha = DateTime.Now,
                        Codigo = request.Codigo,
                        Categoria = request.Categoria,
                        QrCode = request.QrCode,
                        Resultados = JsonSerializer.Serialize(request.Resultados)
                    };

                    await context.AddAsync(resultadosVotacion);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                request.Categoria = e.Message;
            }
            return request;
        }

        public async Task<List<ResultadosDTO>> Read(string codigo)
        {
            List<ResultadosDTO> response = new List<ResultadosDTO>();
            try
            {
                using (UrnaContext context = new UrnaContext())
                {
                    var resultados = await context.Resultados
                        .Where(r => r.Codigo == codigo)
                        .OrderByDescending(i => i)
                        .ToListAsync();

                    foreach (var i in resultados)
                    {
                        response.Add(new ResultadosDTO()
                        {
                            Id = i.Id,
                            Fecha = i.Fecha,
                            Codigo = i.Codigo,
                            Categoria = i.Categoria,
                            QrCode = i.QrCode,
                            Resultados = JsonSerializer.Serialize(i.Resultados)
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