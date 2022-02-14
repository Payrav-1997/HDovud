using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDovud.Entities.Errors
{
    public class ExceptionWithStatusCode : Exception
    {
        public int StatusCode { get; set; }
    }
}
