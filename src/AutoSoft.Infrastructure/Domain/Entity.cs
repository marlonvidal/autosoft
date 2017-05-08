using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Infrastructure.Domain
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T ID { get; protected set; }

        protected Entity()
        {
            ID = default(T);
        }

        protected Entity(T id)
        {
            ID = id;
        }
    }
}
