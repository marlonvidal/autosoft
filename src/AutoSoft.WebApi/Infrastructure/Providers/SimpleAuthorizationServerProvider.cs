using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using AutoSoft.Domain.AuthBC.Usuarios;
using System.Security.Claims;

namespace AutoSoft.WebApi.Infrastructure.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUsuarioRepository _repository;

        public SimpleAuthorizationServerProvider(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                context.Validated();
            });
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                var usuario = _repository.Autenticar(context.UserName, context.Password);

                if (usuario == null)
                    context.SetError("invalid_grant", "Usuário e/ou senha inválidos");

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("login", context.UserName));
                identity.AddClaim(new Claim("role", "usuario"));

                context.Validated(identity);
            });
        }
    }
}