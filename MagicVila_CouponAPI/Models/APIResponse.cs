using System.Net;

namespace MagicVila_CouponAPI.Models
{
    public class APIResponse
    {
        public APIResponse()
        {
            ErrorMessage = new List<string>();
        }
        public bool IsSuccess { get; set; }
        public Object Result { get; set; }
        public List<String> ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
