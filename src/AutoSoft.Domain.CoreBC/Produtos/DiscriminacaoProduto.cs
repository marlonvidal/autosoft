using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.CoreBC.Produtos
{
    public class DiscriminacaoProduto : ValueObject<int>
    {
        protected DiscriminacaoProduto()
        {

        }

        public string Descricao { get; private set; }
        public UnidadeMedida UnidadeMedida { get; private set; }
        public decimal Valor { get; private set; }
    }
}
