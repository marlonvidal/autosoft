using AutoSoft.Domain.Colors;
using AutoSoft.Domain.Manufacturers;
using AutoSoft.Domain.Models;
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
        public Model Model { get; private set; }
        public Color Color { get; private set; }
        public string Year { get; private set; }
    }
}
