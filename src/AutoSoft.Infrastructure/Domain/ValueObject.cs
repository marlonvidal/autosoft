using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Infrastructure.Domain
{
    public class ValueObject<T> : IValueObject<T>
    {
        public T ID { get; private set; }

        protected ValueObject()
        {
            ID = default(T);
        }

        protected ValueObject(T id)
        {
            ID = id;
        }
    }
}
