using AutoSoft.Domain.Customer.Command;
using AutoSoft.Domain.Customer.Validation;
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
        private CreateCustomerCommand _command;
        private IValidator<CreateCustomerCommand> _validator;

        public CreateCustomerTests()
        {
            _command = new CreateCustomerCommand();
            _validator = new CreateCustomerValidation();
        }


        [TestMethod]
        [ExpectedException(typeof(BusinessValidationException))]
        public void Should_not_create_customer_with_empty_email()
        {
            var customer = AutoSoft.Domain.Customer.Customer.Create(_command, _validator);
        }
    }
}
