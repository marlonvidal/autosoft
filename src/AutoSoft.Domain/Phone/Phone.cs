using AutoSoft.Domain.Phones.Command;
using AutoSoft.Domain.Phones.Validation;
using AutoSoft.Infrastructure.Domain;

namespace AutoSoft.Domain.Phones
{
    public class Phone : ValueObject<int>
    {
        public string DDD { get; private set; }
        public string Number { get; private set; }

        protected Phone()
        {

        }

        protected Phone(CreatePhoneCommand command) : base(command.ID)
        {
            DDD = command.DDD;
            Number = command.Number;
        }

        public static Phone Create(CreatePhoneCommand command, CreatePhoneValidation validator)
        {
            validator.ValidateCommand(command);
            return new Phone(command);
        }
    }
}
