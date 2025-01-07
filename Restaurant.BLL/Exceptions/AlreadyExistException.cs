using Restaurant.BLL.Abstractions.Exceptions;
using System.Net;

namespace Restaurant.BLL.Exceptions
{
    public class AlreadyExistException : Exception, IBaseException
    {
        public AlreadyExistException(string message) : base(message)
        {
        }

        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.Conflict;

    }
}
