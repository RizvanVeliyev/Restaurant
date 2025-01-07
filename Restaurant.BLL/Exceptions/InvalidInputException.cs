using Restaurant.BLL.Abstractions.Exceptions;
using System.Net;

namespace Restaurant.BLL.Exceptions
{
    public class InvalidInputException : Exception, IBaseException
    {
        public InvalidInputException(string message) : base(message)
        {

        }

        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;

    }
}
