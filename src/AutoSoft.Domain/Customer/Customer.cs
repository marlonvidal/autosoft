using AutoSoft.Infrastructure.Domain;
using AutoSoft.Domain.Phone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSoft.Domain.Customer.Command;

namespace AutoSoft.Domain.Customer
{
    public class Customer : Entity<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string CpfCnpj { get; private set; }

        protected Customer()
        {

        }

        public static Customer Create(CreateCustomerCommand command)
        {
            var customer = new Customer();
            customer.ID = command.ID;
            customer.Address = command.Address;
            customer.City = command.City;
            customer.CpfCnpj = command.CpfCnpj;
            customer.Email = command.Email;
            customer.FirstName = command.FirstName;
            customer.LastName = command.LastName;

            return customer;
        }
    }
}
