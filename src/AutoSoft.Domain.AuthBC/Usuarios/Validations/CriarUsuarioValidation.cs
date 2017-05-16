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
                .WithMessage(string.Format(Constantes.MensagensValidacao.CampoObrigatorio, "Login"))
                .Must(rules.ExisteUsuarioCadastrado)
                .WithMessage("Já existe o login cadastrado");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage(string.Format(Constantes.MensagensValidacao.CampoObrigatorio, "Senha"))
                .Must(rules.ValidarForcaSenha)
                .WithMessage("A senha digitada não atende aos requisitos de segurança mínimos");


            RuleFor(x => x.ConfirmarSenha)
                .NotEmpty()
                .WithMessage(string.Format(Constantes.MensagensValidacao.CampoObrigatorio, "Senha"))
                .Must(rules.SenhaDigitadaDiferente)
                .WithMessage("As senhas digitadas são diferentes");
        }
    }
}
