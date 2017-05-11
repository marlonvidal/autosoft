using AutoSoft.Domain.CoreBC.Carros;
using AutoSoft.Domain.CoreBC.Clientes;
using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.CoreBC.OrdensServicos
{
    public class OrdemServico : AggregateRoot
    {
        public Cliente Cliente { get; private set; }
        public Carro Carro { get; private set; }
    }
}
