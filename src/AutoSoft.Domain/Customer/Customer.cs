using AutoSoft.Infrastructure.Commands;
using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSoft.Domain.Customers.Command;
using AutoSoft.Domain.Customers.Validation;
using FluentValidation;
using AutoSoft.Domain.Phones;

namespace AutoSoft.Domain.Customers
{
    public class Customer : Entity<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string CpfCnpj { get; private set; }
        public IList<Phone> MyProperty { get; set; }

        protected Customer()
        {

        }

        private Customer(CreateCustomerCommand command) : base(command.ID)
        {
            Address = command.Address;
            City = command.City;
            CpfCnpj = command.CpfCnpj;
            Email = command.Email;
            FirstName = command.FirstName;
            LastName = command.LastName;
        }

        public static Customer Create(CreateCustomerCommand command, 
            IValidator<CreateCustomerCommand> validator)
        {
            validator.ValidateCommand(command);
            return new Customer(command);
        }
    }
}
