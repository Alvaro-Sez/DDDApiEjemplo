using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VY.Example3.Business.Contracts.Domain
{
    public class ErrorObject
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
