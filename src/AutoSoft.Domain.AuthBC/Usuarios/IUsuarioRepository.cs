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
        Usuario Adicionar(Usuario usuario);
    }
}
