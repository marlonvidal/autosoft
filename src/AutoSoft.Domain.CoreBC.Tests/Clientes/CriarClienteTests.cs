using AutoSoft.Domain.CoreBC.Clientes;
using AutoSoft.Domain.CoreBC.Clientes.Commands;
using AutoSoft.Domain.CoreBC.Clientes.Validations;
using AutoSoft.Infrastructure.Validation;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.CoreBC.Tests.Clientes
{
    [TestClass]
    public class CriarClienteTests
    {
        private CriarClienteCommand _command;
        private IValidator<CriarClienteCommand> _validator;

        public CriarClienteTests()
        {
            _command = new CriarClienteCommand();
            _validator = new CriarClienteValidation();
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessValidationException))]
        public void Should_not_create_customer_with_empty_email()
        {
            var customer = Cliente.Criar(_command, _validator);
        }
    }
}
