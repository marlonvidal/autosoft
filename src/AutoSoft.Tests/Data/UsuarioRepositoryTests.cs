using Autofac;
using AutoSoft.Data.Repositories;
using AutoSoft.Domain.AuthBC.Usuarios;
using AutoSoft.Domain.AuthBC.Usuarios.Commands;
using AutoSoft.Domain.AuthBC.Usuarios.Validations;
using AutoSoft.Infrastructure.Commands;
using AutoSoft.Infrastructure.Validation;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Tests.Data
{
    [TestClass]
    public class UsuarioRepositoryTests : BaseTest
    {
        private IUsuarioRepository _repositorio;
        private CriarUsuarioValidation _validator;

        private Usuario usuarioCriado;
        private Guid idUsuario;
        private string loginUsuario
        {
            get
            {
                if (idUsuario == null)
                    return "";

                return "usuario" + idUsuario.ToString().Split('-')[0];
            }
        }

        [TestInitialize]
        public void ConfigInitialization()
        {
            _repositorio = Resolve<IUsuarioRepository>();
            _validator = Resolve<CriarUsuarioValidation>();

            idUsuario = Guid.NewGuid();

            var cmd = new CriarUsuarioCommand();
            cmd.Id = idUsuario;
            cmd.Login = loginUsuario;
            cmd.Senha = "123456";
            cmd.ConfirmarSenha = "123456";

            var usuario = Usuario.Criar(cmd, _validator);
            _repositorio.Adicionar(usuario);
            usuarioCriado = usuario;
        }
        [TestMethod]
        public void Test_nao_pode_inserir_usuario_duplicado()
        {
            try
            {
                var cmd = new CriarUsuarioCommand();
                cmd.Id = idUsuario;
                cmd.Login = loginUsuario;
                cmd.Senha = "123456";
                cmd.ConfirmarSenha = "123456";

                var usuario = Usuario.Criar(cmd, _validator);
                _repositorio.Adicionar(usuario);
            }
            catch (BusinessValidationException ex)
            {
                var nomeExistente = ex.Message.Contains(CriarUsuarioValidation.MensagensValidacao.EXISTE_LOGIN_CADASTRADO);
                Assert.AreEqual(nomeExistente, true);
            }
        }

        [TestMethod]
        public void Teste_dados_usuarios_foram_persistidos_corretamente()
        {
            var usuario = _repositorio.EncontrarPor(usuarioCriado.Id);

            Assert.IsNotNull(usuario);
            Assert.AreEqual(usuario.Login, usuarioCriado.Login);
            Assert.AreEqual(usuario.Senha, usuarioCriado.Senha);
        }
    }
}
