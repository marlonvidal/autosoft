using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Services
{
    public class Service : ValueObject<int>
    {
        protected Service()
        {

        }

        public string Description { get; private set; }
        public decimal Value { get; private set; }
    }
}
