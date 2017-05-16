using AutoSoft.Infrastructure.Commands;
using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSoft.Domain.CoreBC.Clientes.Commands;
using FluentValidation;
using AutoSoft.Domain.CoreBC.Telefones;

namespace AutoSoft.Domain.CoreBC.Clientes
{
    public class Cliente : Entity<long>
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; private set; }
        public string Email { get; private set; }
        public string Endereco { get; private set; }
        public string Cidade { get; private set; }
        public string CpfCnpj { get; private set; }
        public IList<Telefone> Telefones { get; set; }

        protected Cliente()
        {

        }

        private Cliente(CriarClienteCommand command) : base(command.ID)
        {
            Endereco = command.Endereco;
            Cidade = command.Cidade;
            CpfCnpj = command.CpfCnpj;
            Email = command.Email;
            PrimeiroNome = command.PrimeiroNome;
            UltimoNome = command.UltimoNome;
        }

        public static Cliente Criar(CriarClienteCommand command, 
            IValidator<CriarClienteCommand> validator)
        {
            validator.ValidateCommand(command);
            return new Cliente(command);
        }
    }
}
