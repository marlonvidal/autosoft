using AutoSoft.Data;
using AutoSoft.Domain.AuthBC.Usuarios.Commands;
using AutoSoft.Infrastructure.Commands;
using AutoSoft.Infrastructure.Queries;
using AutoSoft.WebApi.Infrastructure;
using AutoSoft.WebApi.Infrastructure.Validation;
using AutoSoft.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AutoSoft.WebApi.Controllers
{
    [ValidateRequest]
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        private readonly ICommandSender _commandSender;
        private readonly IQueryDispatcher _queryDispatcher;

        public ClienteController(ICommandSender commandSender, IQueryDispatcher queryDispatcher)
        {
            _commandSender = commandSender;
            _queryDispatcher = queryDispatcher;
        }

        [Authorize(Roles = Roles.Admin)]
        [Route("", Name = "PostCliente"), HttpPost]
        public IHttpActionResult CriarUsuario([FromBody]UsuarioViewModel viewModel)
        {
            var cmd = new CriarUsuarioCommand();
            cmd.Id = Guid.NewGuid();
            cmd.Login = viewModel.Login;
            cmd.Senha = viewModel.Senha;

            _commandSender.Send(cmd, false);

            return Ok(SuccessResponse.Instance);
        }
    }
}