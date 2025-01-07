using Restaurant.BLL.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Exceptions
{
    public class NotFoundException : Exception, IBaseException
    {
        public NotFoundException(string message = "Not found") : base(message)
        {

        }

        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.NotFound;

    }
}
