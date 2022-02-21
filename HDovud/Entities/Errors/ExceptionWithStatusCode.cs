using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HDovud.Entities.Errors
{
    public class ExceptionWithStatusCode : Exception
    {
        public ExceptionWithStatusCode(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}
