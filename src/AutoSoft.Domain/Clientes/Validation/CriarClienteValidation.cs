using AutoSoft.Domain.CoreBC.Clientes.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.CoreBC.Clientes.Validation
{
    public class CriarClienteValidation : AbstractValidator<CriarClienteCommand>
    {
        public CriarClienteValidation()
        {
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
