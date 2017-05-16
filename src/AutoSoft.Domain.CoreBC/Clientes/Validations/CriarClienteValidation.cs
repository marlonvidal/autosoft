using AutoSoft.Domain.CoreBC.Clientes.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.CoreBC.Clientes.Validations
{
    public class CriarClienteValidation : AbstractValidator<CriarClienteCommand>
    {
        public CriarClienteValidation()
        {
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
