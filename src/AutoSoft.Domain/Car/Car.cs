using AutoSoft.Domain.Manufacturers;
using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Cars
{
    public class Car : ValueObject<int>
    {
        public string Plate { get; private set; }
        public Manufacturer Manufacturer { get; private set; }
    }
}
