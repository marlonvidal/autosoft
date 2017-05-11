using AutoSoft.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.CoreBC.Telefones.Command
{
    public class CriarTelefoneCommand : ICommand
    {
        public int ID { get; set; }
        public string DDD { get; set; }
        public string Number { get; set; }
    }
}
