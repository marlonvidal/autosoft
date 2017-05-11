using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.CoreBC.Items
{
    public class Item : AggregateRoot
    {
        protected Item()
        {

        }

        public List<DiscriminacaoItem> Items { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
