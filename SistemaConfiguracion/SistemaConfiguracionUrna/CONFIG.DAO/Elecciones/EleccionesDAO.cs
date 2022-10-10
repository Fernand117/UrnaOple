using CONFIG.COMMON.DTOS.Elecciones;
using CONFIG.COMMON.DTOS.Partidos;
using CONFIG.DAL.Context;
using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace CONFIG.DAO.Elecciones
{
    public class EleccionesDAO
    {
        public async Task<EleccionesRequest> Create(EleccionesRequest request)
        {
            ConfiContext config = new ConfigContext();
            var options = new JsonSerializerOptions { WriteIndented = true };
            string result = System.Text.Json.JsonSerializer.Serialize(request, options);
            try
            {
                using (WebResponse response = config.configuracionApi("POST").GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        if (stream == null) return null;

                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            string responseBody = streamReader.ReadToEnd();
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            } 
            catch (WebException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine(result);
            return request;
        }
    }
}
