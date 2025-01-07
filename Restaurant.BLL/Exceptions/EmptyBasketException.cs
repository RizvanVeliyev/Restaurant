using Restaurant.BLL.Abstractions.Exceptions;
using System.Net;

namespace Restaurant.BLL.Exceptions
{
    public class EmptyBasketException : Exception, IBaseException
    {
        public EmptyBasketException(string message = "Səbətiniz boşdur") : base(message)
        {

        }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.NotFound;

    }
}
