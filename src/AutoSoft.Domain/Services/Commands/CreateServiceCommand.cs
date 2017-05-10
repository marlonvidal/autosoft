using AutoSoft.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Services.Commands
{
    public class CreateServiceCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
