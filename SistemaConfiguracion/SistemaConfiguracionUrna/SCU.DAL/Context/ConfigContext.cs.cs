using System.Net;

namespace SCU.DAL.Context
{
    public class ConfigContext
    {
        public HttpWebRequest configuracionApi(string method)
        {
            var url = $"http://localhost:8080/item/api";
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = method;
            request.ContentType = "application/json";
            request.Accept = "application/json";
            return request;
        }
    }
}
