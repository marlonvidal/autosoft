using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Domain.AuthBC.Usuarios
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        bool ExisteUsuarioCadastrado(string login);
        void Adicionar(Usuario usuario);
        Usuario EncontrarPor(Guid id);
        Usuario Autenticar(string login, string senha);
    }
}
