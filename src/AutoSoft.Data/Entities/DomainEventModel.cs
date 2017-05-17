using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Data.Entities
{
    public class DomainEventModel
    {
        public Guid DomainAggregateId { get; set; }
        public int SequenceNumber { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid UserId { get; set; }

        public virtual DomainAggregateModel DomainAggregate { get; set; }
    }
}
