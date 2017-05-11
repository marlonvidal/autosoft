using AutoSoft.Domain.Clientes;
using AutoSoft.Domain.Clientes.Command;
using AutoSoft.Domain.Clientes.Validation;
using AutoSoft.Infrastructure.Validation;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.Tests.Customer
{
    [TestClass]
    public class CreateCustomerTests
    {
        private CriarClienteCommand _command;
        private IValidator<CriarClienteCommand> _validator;

        public CreateCustomerTests()
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
