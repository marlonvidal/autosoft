using AutoSoft.Domain.AuthBC.Usuarios.Commands;
using AutoSoft.Infrastructure.Util;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.AuthBC.Usuarios.Validations
{
    public class AutenticarUsuarioValidation : AbstractValidator<AutenticarUsuarioCommand>
    {
        public AutenticarUsuarioValidation()
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage(MensagemValidacao.LOGIN_OBRIGATORIO);

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage(MensagemValidacao.SENHA_OBRIGATORIA);
        }

        public static class MensagemValidacao
        {
            public static string LOGIN_OBRIGATORIO = string.Format(Constantes.MensagensValidacao.CampoObrigatorio, "Login");
            public static string SENHA_OBRIGATORIA = string.Format(Constantes.MensagensValidacao.CampoObrigatorio, "Senha");
        }
    }
}
