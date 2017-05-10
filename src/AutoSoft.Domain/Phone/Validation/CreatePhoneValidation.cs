using AutoSoft.Domain.Phones.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Phones.Validation
{
    public class CreatePhoneValidation : AbstractValidator<CreatePhoneCommand>
    {
        public CreatePhoneValidation()
        {
            RuleFor(x => x.DDD).NotEmpty();
            RuleFor(x => x.Number).NotEmpty();
        }
    }
}
