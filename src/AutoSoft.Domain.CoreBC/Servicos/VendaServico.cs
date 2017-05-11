using AutoSoft.Domain.CoreBC.Servicos.Commands;
using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.CoreBC.Servicos
{
    public class VendaServico : AggregateRoot
    {
        protected VendaServico()
        {

        }

        private VendaServico(CriarServicoCommand command) : base(command.Id)
        {

        }

        public List<DiscriminacaoServico> DiscriminacaoServicos { get; private set; }

        public decimal PrecoTotal { get; private set; }

        public void CalcularPrecoTotal(decimal? desconto)
        {
            PrecoTotal += DiscriminacaoServicos.Sum(x => x.Valor);

            if (desconto.HasValue)
                PrecoTotal -= desconto.Value;
        }
    }
}
