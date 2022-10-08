using CONFIG.COMMON.DTOS.Elecciones;
using System;
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
            Console.WriteLine(request);
            return request;
        }
    }
}
