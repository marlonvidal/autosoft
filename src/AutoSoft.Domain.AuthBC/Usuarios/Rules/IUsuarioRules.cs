using AutoSoft.Domain.AuthBC.Usuarios.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.AuthBC.Usuarios.Rules
{
    public interface IUsuarioRules
    {
        bool SenhaDigitadaDiferente(CriarUsuarioCommand cmd, string senhaConfirmada);
        bool ExisteUsuarioCadastrado(string login);
        bool ValidarForcaSenha(string senha);
    }
}
