using System.Net;

namespace TPBitwise.Models
{
    public class RespuestaAPI
    {
        public RespuestaAPI()
        {
            ErrorMensagges = new List<string>();
        }

        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMensagges { get; set; }
        public object Result { get; set; }
    }
}
