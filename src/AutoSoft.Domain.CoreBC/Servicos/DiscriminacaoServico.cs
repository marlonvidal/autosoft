using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.CoreBC.Servicos
{
    public class DiscriminacaoServico : ValueObject<int>
    {
        protected DiscriminacaoServico()
        {

        }

        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
    }
}
