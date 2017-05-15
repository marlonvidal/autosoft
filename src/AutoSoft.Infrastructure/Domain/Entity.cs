using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Infrastructure.Domain
{
    public abstract class Entity<TKeyType> : IEntity<TKeyType>
    {
        public TKeyType ID { get; private set; }

        protected Entity()
        {
            ID = default(TKeyType);
        }

        protected Entity(TKeyType id)
        {
            ID = id;
        }
    }
}
