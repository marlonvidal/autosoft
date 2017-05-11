using AutoSoft.Domain.CoreBC.Cores;
using AutoSoft.Domain.CoreBC.Fabricantes;
using AutoSoft.Domain.CoreBC.Modelos;
using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.CoreBC.Carros
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
