using AutoSoft.Domain.AuthBC.Usuarios;
using AutoSoft.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AutoSoft.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<UsuarioModel>, IUsuarioRepository
    {
        private readonly IMapper _mapper;

        public UsuarioRepository(IUnitOfWork uow, IMapper mapper) : base(uow)
        {
            _mapper = mapper;
        }

        public void Adicionar(Usuario usuario)
        {
            var model = _mapper.Map<UsuarioModel>(usuario);
            Add(model);
        }

        public Usuario EncontrarPor(Guid id)
        {
            var result = FindBy(x => x.Id == id).FirstOrDefault();
            return _mapper.Map<Usuario>(result);
        }

        public bool ExisteUsuarioCadastrado(string login)
        {
            var result = _uow.QueryableFor<UsuarioModel>().Where(x => x.Login.ToLower() == login.ToLower()).Count();
            return result > 0;
        }

        public Usuario Autenticar(string login, string senha)
        {
            var usuario = _uow.QueryableFor<UsuarioModel>().FirstOrDefault(x => x.Login == login && x.Senha == senha);
            return _mapper.Map<Usuario>(usuario);
        }
    }
}
