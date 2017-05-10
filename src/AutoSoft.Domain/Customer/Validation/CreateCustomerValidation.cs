using AutoSoft.Domain.Customers.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Customers.Validation
{
    public class CreateCustomerValidation : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidation()
        {
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
