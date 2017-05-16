using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSoft.Domain.AuthBC.Usuarios.Commands;

namespace AutoSoft.Domain.AuthBC.Usuarios.Rules
{
    public class UsuarioRules : IUsuarioRules
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioRules(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public bool ExisteUsuarioCadastrado(string login)
        {
            return _repository.ExisteUsuarioCadastrado(login);
        }

        public bool SenhaDigitadaDiferente(CriarUsuarioCommand cmd, string senhaConfirmada)
        {
            return cmd.Senha == senhaConfirmada;
        }

        public bool ValidarForcaSenha(string senha)
        {
            if (senha.Length < 5)
                return false;

            return true;
        }
    }
}
