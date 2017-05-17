using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Data.Entities
{
    public class DomainAggregateModel
    {
        public Guid Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<DomainEventModel> DomainEvents { get; set; } = new List<DomainEventModel>();
    }
}
