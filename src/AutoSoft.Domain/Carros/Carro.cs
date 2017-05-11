using AutoSoft.Domain.Cores;
using AutoSoft.Domain.Fabricantes;
using AutoSoft.Domain.Modelos;
using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Carros
{
    public class Carro : ValueObject<int>
    {
        public string Placa { get; private set; }
        public Fabricante Fabricante { get; private set; }
        public Modelo Modelo { get; private set; }
        public Cor Cor { get; private set; }
        public string Ano { get; private set; }
    }
}
