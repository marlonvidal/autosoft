using AutoSoft.Domain.Cars;
using AutoSoft.Domain.Customers;
using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Orders
{
    public class Order : AggregateRoot
    {
        public Customer Customer { get; private set; }
        public Car Car { get; private set; }
    }
}
