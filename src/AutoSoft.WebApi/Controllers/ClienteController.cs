using AutoSoft.Data;
using AutoSoft.Domain.AuthBC.Usuarios.Commands;
using AutoSoft.Infrastructure.Commands;
using AutoSoft.Infrastructure.Queries;
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
        
        [Route("", Name = "GetCliente"), AcceptVerbs("GET")]
        public IHttpActionResult Get()
        {
            var cmd = new CriarUsuarioCommand();
            cmd.Id = Guid.NewGuid();
            cmd.Login = "usuario";
            cmd.Senha = "123456";
            cmd.ConfirmarSenha = "123456";

            _commandSender.Send(cmd, false);

            return Ok();
        }

    }
}