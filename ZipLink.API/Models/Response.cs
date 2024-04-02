namespace ZipLink.API.Models
{
    public class Response
    {
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public object Data { get; set; }
    }
}
