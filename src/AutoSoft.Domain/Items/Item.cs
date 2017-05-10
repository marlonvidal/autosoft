using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Items
{
    public class Item : AggregateRoot
    {
        protected Item()
        {

        }

        public List<ItemDiscrimination> Items { get; set; }
        public decimal TotalValue { get; set; }
    }
}
