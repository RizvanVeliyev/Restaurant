using Restaurant.BLL.Abstractions.Exceptions;
using System.Net;

namespace Restaurant.BLL.Exceptions
{

    public class UnAuthorizedException : Exception, IBaseException
    {
        public UnAuthorizedException(string message = "Qeydiyyatdan keçməyən istifadəçi") : base(message)
        {

        }

        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.Unauthorized;
    }
}
