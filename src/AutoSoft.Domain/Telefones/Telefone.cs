using AutoSoft.Domain.Telefones.Command;
using AutoSoft.Domain.Telefones.Validation;
using AutoSoft.Infrastructure.Domain;

namespace AutoSoft.Domain.Telefones
{
    public class Telefone : ValueObject<int>
    {
        public string DDD { get; private set; }
        public string Numero { get; private set; }

        protected Telefone()
        {

        }

        protected Telefone(CriarTelefoneCommand command) : base(command.ID)
        {
            DDD = command.DDD;
            Numero = command.Number;
        }

        public static Telefone Create(CriarTelefoneCommand command, CriarTelefoneValidation validator)
        {
            validator.ValidateCommand(command);
            return new Telefone(command);
        }
    }
}
