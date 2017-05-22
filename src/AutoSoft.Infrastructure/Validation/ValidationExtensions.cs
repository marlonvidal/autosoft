using AutoSoft.Infrastructure.Commands;
using AutoSoft.Infrastructure.Validation;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoSoft.Infrastructure.Domain
{
    public static class ValidationExtensions
    {
        public static void ValidateCommand<TCommand>(this IValidator<TCommand> validator, TCommand command) 
            where TCommand : ICommand
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var validationResult = validator.Validate(command);

            if (!validationResult.IsValid)
                throw new BusinessValidationException(BuildErrorMesage(validationResult.Errors), validationResult.Errors);
        }

        private static string BuildErrorMesage(IEnumerable<ValidationFailure> errors)
        {
            var errorsText = errors.Select(x => x.ErrorMessage).ToArray();
            return "Erro de validação: " + string.Join(", ", errorsText);
        }
    }
}
