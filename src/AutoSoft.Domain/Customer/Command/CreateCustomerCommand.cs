using AutoSoft.Domain.Phones;
using AutoSoft.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Customers.Command
{
    public class CreateCustomerCommand : ICommand
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string CpfCnpj { get; set; }
        public Phone Phone { get; set; }
    }
}
