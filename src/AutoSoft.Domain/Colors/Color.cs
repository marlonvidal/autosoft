using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Colors
{
    public class Color : ValueObject<int>
    {
        public string Name { get; private set; }
    }
}
