using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Items
{
    public class DiscriminacaoItem : ValueObject<int>
    {
        protected DiscriminacaoItem()
        {

        }

        public string Descricao { get; private set; }
        public UnidadeMedida UnidadeMedida { get; private set; }
        public decimal Valor { get; private set; }
    }
}
