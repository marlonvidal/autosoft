using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.CoreBC.Produtos
{
    public class VendaProduto : AggregateRoot
    {
        protected VendaProduto()
        {

        }

        public List<DiscriminacaoProduto> DescriminacaoProdutos { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
