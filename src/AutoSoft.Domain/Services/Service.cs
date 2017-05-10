using AutoSoft.Domain.Services.Commands;
using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Services
{
    public class Service : AggregateRoot
    {
        protected Service()
        {

        }

        private Service(CreateServiceCommand command) : base(command.Id)
        {

        }

        public List<ServiceDiscrimination> Services { get; private set; }

        public decimal TotalPrice { get; private set; }

        public void CalculateTotalPrice(decimal? discount)
        {
            TotalPrice += Services.Sum(x => x.Value);

            if (discount.HasValue)
                TotalPrice -= discount.Value;
        }
    }
}
