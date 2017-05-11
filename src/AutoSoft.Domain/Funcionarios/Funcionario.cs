using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.CoreBC.Funcionarios
{
    public class Funcionario : Entity<int>
    {
        public string Nome { get; private set; }
        public string Cargo { get; private set; }
        public bool Ativo { get; private set; }

        protected Funcionario()
        {

        }
    }
}
