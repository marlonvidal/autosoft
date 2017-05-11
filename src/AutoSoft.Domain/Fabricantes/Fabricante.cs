using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Fabricantes
{
    public class Fabricante : ValueObject<int>
    {
        public string Nome { get; private set; }
    }
}
