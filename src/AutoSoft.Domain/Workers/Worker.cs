using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Workers
{
    public class Worker : Entity<int>
    {
        public string Name { get; private set; }
        public string Role { get; private set; }
        public bool Active { get; private set; }

        protected Worker()
        {

        }
    }
}
