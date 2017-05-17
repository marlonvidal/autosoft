using AutoSoft.Domain.AuthBC.Usuarios.Commands;
using AutoSoft.Domain.AuthBC.Usuarios.Rules;
using AutoSoft.Infrastructure.Util;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.AuthBC.Usuarios.Validations
{
    public class CriarUsuarioValidation : AbstractValidator<CriarUsuarioCommand>
    {
        public CriarUsuarioValidation(IUsuarioRules rules)
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage(MensagensValidacao.LOGIN_OBRIGATORIO)
                .Must(rules.ExisteUsuarioCadastrado)
                .WithMessage(MensagensValidacao.EXISTE_LOGIN_CADASTRADO);

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage(MensagensValidacao.SENHA_OBRIGATORIA)
                .Must(rules.ValidarForcaSenha)
                .WithMessage(MensagensValidacao.SENHA_NAO_ATENDE_REQUISITOS_SEGURANCA);


            RuleFor(x => x.ConfirmarSenha)
                .NotEmpty()
                .WithMessage(MensagensValidacao.SENHA_OBRIGATORIA)
                .Must(rules.SenhaDigitadaDiferente)
                .WithMessage(MensagensValidacao.SENHAS_DIGITADAS_DIFERENTES);
        }

        public static class MensagensValidacao
        {
            public static string LOGIN_OBRIGATORIO = string.Format(Constantes.MensagensValidacao.CampoObrigatorio, "Login");
            public static string SENHA_OBRIGATORIA = string.Format(Constantes.MensagensValidacao.CampoObrigatorio, "Senha");

            public const string EXISTE_LOGIN_CADASTRADO = "Já existe o login cadastrado";
            public const string SENHA_NAO_ATENDE_REQUISITOS_SEGURANCA = "A senha digitada não atende aos requisitos de segurança mínimos";
            public const string SENHAS_DIGITADAS_DIFERENTES = "As senhas digitadas são diferentes";
        }
    }
}
