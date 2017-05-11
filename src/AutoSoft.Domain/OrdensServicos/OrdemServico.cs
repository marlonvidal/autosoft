using AutoSoft.Domain.Carros;
using AutoSoft.Domain.Clientes;
using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.OrdensServicos
{
    public class OrdemServico : AggregateRoot
    {
        public Cliente Cliente { get; private set; }
        public Carro Carro { get; private set; }
    }
}
