using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.CoreBC.Services
{
    public class ServiceDiscrimination : ValueObject<int>
    {
        protected ServiceDiscrimination()
        {

        }

        public string Description { get; private set; }
        public decimal Value { get; private set; }
    }
}
