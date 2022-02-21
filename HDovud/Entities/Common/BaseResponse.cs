using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HDovud.Entities.Common
{
    public class BaseResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Payload { get; set; }

        public BaseResponse(HttpStatusCode statusCode, T result, string message = null)
        {
            StatusCode = (int)statusCode;
            Payload = result;
            Message = message;
        }

        public BaseResponse(HttpStatusCode statusCode, T result)
        {
            StatusCode = (int)statusCode;
            Payload = result;
        }

        public BaseResponse(HttpStatusCode statusCode)
        {
            StatusCode = (int)statusCode;
        }

        public BaseResponse()
        {

        }
    }
}
