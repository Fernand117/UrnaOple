using System.Net;

namespace CONFIG.DAL.Context
{
    public class ConfiContext
    {
        public HttpWebRequest configuracionApi(string method)
        {
            var url = $"http://localhost:5000/api/eleccion";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.ContentType = "application/json";
            request.Accept = "application/json";
            return request;
        }
    }
}
