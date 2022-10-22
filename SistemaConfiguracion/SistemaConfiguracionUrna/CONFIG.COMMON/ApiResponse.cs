namespace CONFIG.COMMON
{
    public class ApiResponse
    {
        public Response ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public object Data { get; set; }
    }
}
