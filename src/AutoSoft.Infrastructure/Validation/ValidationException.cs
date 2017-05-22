using FluentValidation.Results;
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
        public List<string> Messages { get; private set; }

        public BusinessValidationException() { }

        public BusinessValidationException(string message) : base(message) { }

        public BusinessValidationException(string message, List<string> messages) : base(message)
        {
            this.Messages = messages;
        }

        public BusinessValidationException(string message, IEnumerable<ValidationFailure> messages) : base(message)
        {
            if (messages != null)
                this.Messages = messages.Select(x => x.ErrorMessage).ToList();
        }

        public BusinessValidationException(string message, Exception inner) : base(message, inner) { }

        protected BusinessValidationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
