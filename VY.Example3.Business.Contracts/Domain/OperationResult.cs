using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VY.Example3.Business.Contracts.Domain
{
    public class OperationResult
    {
        private readonly List<ErrorObject> _errors = new List<ErrorObject>();
        public IEnumerable<ErrorObject> Errors { get { return _errors; } }
        public void AddErrors ( Exception ex ) => _errors.Add ( new ErrorObject { Exception = ex , Message = ex.Message} );
        public void AddErrors(ErrorObject err) => _errors.Add(err);
        public bool HasSomeException () => _errors.Any(e => e.Exception != null);
        public bool HasErrors () => _errors.Count > 0;

    }

    public class OperationResult<T> : OperationResult
    {
        public T Result { get; set; }
        public void SetResult (T result) => Result = result;
    }
}
