using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Modelos
{
    public class Modelo : ValueObject<int>
    {
        public string Nome { get; private set; }
    }
}
