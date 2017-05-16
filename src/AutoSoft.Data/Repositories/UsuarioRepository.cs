using AutoSoft.Domain.AuthBC.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IUnitOfWork uow) : base(uow) { }

        public bool ExisteUsuarioCadastrado(string login)
        {
            return _uow.QueryableFor<Usuario>().Where(x => x.Login.ToLower() == login.ToLower()).Count() > 0;
        }

        public Usuario Adicionar(Usuario usuario)
        {
            var novoUsuario = Add(usuario);
            _uow.SaveChanges();

            return novoUsuario;
        }
    }
}
