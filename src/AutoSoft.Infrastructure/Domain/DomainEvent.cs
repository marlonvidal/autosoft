using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Infrastructure.Domain
{
    public class DomainEvent : IDomainEvent
    {
        public Guid AggregateRootId { get; set; }
        public int Version { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public Guid UserId { get; set; }
    }
}
