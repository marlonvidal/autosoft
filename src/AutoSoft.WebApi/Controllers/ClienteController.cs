using AutoSoft.Data;
using AutoSoft.Domain.AuthBC.Usuarios.Commands;
using AutoSoft.Infrastructure.Commands;
using AutoSoft.Infrastructure.Queries;
using AutoSoft.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AutoSoft.WebApi.Controllers
{
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

        [Route("", Name = "PostCliente"), HttpPost]
        public IHttpActionResult Post([FromBody]UsuarioViewModel viewModel)
        {
            var cmd = new CriarUsuarioCommand();
            cmd.Id = Guid.NewGuid();
            cmd.Login = viewModel.Login;
            cmd.Senha = viewModel.Senha;

            _commandSender.Send(cmd, false);

            return Ok(new SuccessResponse());
        }
    }
}