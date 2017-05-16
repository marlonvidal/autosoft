using AutoSoft.Domain.CoreBC.Telefones.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.CoreBC.Telefones.Validations
{
    public class CriarTelefoneValidation : AbstractValidator<CriarTelefoneCommand>
    {
        public CriarTelefoneValidation()
        {
            RuleFor(x => x.DDD).NotEmpty();
            RuleFor(x => x.Number).NotEmpty();
        }
    }
}
