using AutoSoft.Domain.CoreBC.Carros;
using AutoSoft.Domain.CoreBC.Clientes;
using AutoSoft.Domain.CoreBC.Funcionarios;
using AutoSoft.Domain.CoreBC.Produtos;
using AutoSoft.Domain.CoreBC.Servicos;
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
        public Funcionario Funcionario { get; private set; }
        public VendaServico VendaServico { get; private set; }
        public VendaProduto VendaProduto { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }
        public string Observacoes { get; private set; }
    }
}
