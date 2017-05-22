using AutoSoft.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.AuthBC.Usuarios.Commands
{
    public class AutenticarUsuarioCommand : ICommand
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
