using AutoSoft.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.CoreBC.Servicos.Commands
{
    public class CriarServicoCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
