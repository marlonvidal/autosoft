using AutoSoft.Domain.AuthBC.Usuarios.Commands;
using AutoSoft.Domain.AuthBC.Usuarios.Events;
using AutoSoft.Domain.AuthBC.Usuarios.Validations;
using AutoSoft.Infrastructure.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.AuthBC.Usuarios
{
    public class Usuario : AggregateRoot
    {
        public string Login { get; private set; }
        public string Senha { get; private set; }

        public Usuario() { }

        protected Usuario(CriarUsuarioCommand cmd) : base(cmd.Id)
        {
            Login = cmd.Login;
            Senha = cmd.Senha;

            AddEvent(new UsuarioCriadoEvent()
            {
                AggregateRootId = Id,
                UsuarioId = cmd.Id
            });
        }

        public static Usuario Criar(CriarUsuarioCommand cmd, IValidator<CriarUsuarioCommand> validation)
        {
            validation.ValidateCommand(cmd);
            return new Usuario(cmd);            
        }
    }
}
