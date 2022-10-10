using CONFIG.COMMON.DTOS.Elecciones;
using CONFIG.COMMON.DTOS.Partidos;
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
            /*ConfigContext config = new ConfigContext();
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
            }*/
            var options = new JsonSerializerOptions { WriteIndented = true };
            string result = System.Text.Json.JsonSerializer.Serialize(request, options);


            Console.WriteLine(result);
            return request;
        }
    }
}
