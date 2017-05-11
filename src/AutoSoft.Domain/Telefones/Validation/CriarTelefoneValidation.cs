using AutoSoft.Domain.Telefones.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Telefones.Validation
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
