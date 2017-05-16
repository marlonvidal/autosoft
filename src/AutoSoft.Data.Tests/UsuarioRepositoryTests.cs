using AutoSoft.Data.Repositories;
using AutoSoft.Domain.AuthBC.Usuarios;
using AutoSoft.Domain.AuthBC.Usuarios.Commands;
using AutoSoft.Domain.AuthBC.Usuarios.Validations;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Data.Tests
{
    [TestClass]
    public class UsuarioRepositoryTests : BaseTest
    {
        [TestMethod]
        public void Test_deve_inserir_um_usuario()
        {
            var _repositorio = Resolve<IUsuarioRepository>();
            var _validator = Resolve<CriarUsuarioValidation>();

            var cmd = new CriarUsuarioCommand();
            cmd.Id = Guid.NewGuid();
            cmd.Login = "josecarlos";
            cmd.Senha = "";
            cmd.ConfirmarSenha = "123";

            var usuario = Usuario.Criar(cmd, _validator);
            var novoUsuario = _repositorio.Adicionar(usuario);

            Assert.IsNotNull(novoUsuario);
        }
    }
}
