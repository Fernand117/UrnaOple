using CONFIG.COMMON.DTOS.Elecciones;
using CONFIG.COMMON.DTOS.Partidos;
using CONFIG.DAL.Context;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace CONFIG.DAO.Elecciones
{
    public class EleccionesDAO
    {
        public async Task<EleccionesRequest> Create(EleccionesRequest request)
        {
            ConfiContext config = new ConfiContext();
            var options = new JsonSerializerOptions { WriteIndented = true };
            string result = System.Text.Json.JsonSerializer.Serialize(request, options);

            using (StreamWriter streamWriter = new StreamWriter(config.configuracionApi("POST").GetRequestStream()))
            {
                streamWriter.Write(result);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (WebResponse response = config.configuracionApi("POST").GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            string json = streamReader.ReadToEnd();
                            Console.WriteLine(json);
                        }
                    }
                }
            } 
            catch (WebException ex)
            {
                Console.WriteLine(ex);
            }
            return request;
        }
    }
}
