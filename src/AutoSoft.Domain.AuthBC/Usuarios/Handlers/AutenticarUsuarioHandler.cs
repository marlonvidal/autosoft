using AutoSoft.Domain.AuthBC.Usuarios.Commands;
using AutoSoft.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSoft.Infrastructure.Events;

namespace AutoSoft.Domain.AuthBC.Usuarios.Handlers
{
    public class AutenticarUsuarioHandler : ICommandHandler<AutenticarUsuarioCommand>
    {
        private readonly IUsuarioRepository _repository;

        public AutenticarUsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<IEvent> Handle(AutenticarUsuarioCommand command)
        {
            //if (_repository.Autenticar(command.Login, command.Senha))
            //    throw new UnauthorizedAccessException("Usuário/senha inválidos");

            return null;
        }
    }
}
