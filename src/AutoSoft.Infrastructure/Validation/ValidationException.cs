using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Infrastructure.Validation
{
    [Serializable]
    public class BusinessValidationException : Exception
    {
        public BusinessValidationException() { }
        public BusinessValidationException(string message) : base(message) { }
        public BusinessValidationException(string message, Exception inner) : base(message, inner) { }
        protected BusinessValidationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
