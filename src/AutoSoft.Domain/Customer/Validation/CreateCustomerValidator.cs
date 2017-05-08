using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Customer.Validation
{
    public class CreateCustomerValidator : AbstractValidator<Customer>
    {
        public CreateCustomerValidator()
        {
        }
    }
}
