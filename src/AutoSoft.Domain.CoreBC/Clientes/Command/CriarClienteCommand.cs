using AutoSoft.Domain.CoreBC.Telefones;
using AutoSoft.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.CoreBC.Clientes.Command
{
    public class CriarClienteCommand : ICommand
    {
        public long ID { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string CpfCnpj { get; set; }
        public List<Telefone> Telefones { get; set; }
    }
}
