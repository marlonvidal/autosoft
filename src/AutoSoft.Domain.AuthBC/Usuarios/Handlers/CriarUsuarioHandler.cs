using AutoSoft.Domain.AuthBC.Usuarios.Commands;
using AutoSoft.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSoft.Infrastructure.Events;
using FluentValidation;

namespace AutoSoft.Domain.AuthBC.Usuarios.Handlers
{
    public class CriarUsuarioHandler : ICommandHandler<CriarUsuarioCommand>
    {
        private readonly IUsuarioRepository repository;
        private readonly IValidator<CriarUsuarioCommand> validator;

        public CriarUsuarioHandler(IUsuarioRepository repository, IValidator<CriarUsuarioCommand> validator)
        {
            this.repository = repository;
            this.validator = validator;
        }

        public IEnumerable<IEvent> Handle(CriarUsuarioCommand command)
        {
            var usuario = Usuario.Criar(command, validator);
            repository.Adicionar(usuario);

            return usuario.Events;
        }
    }
}
