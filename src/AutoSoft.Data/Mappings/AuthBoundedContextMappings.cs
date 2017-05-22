using AutoMapper;
using AutoSoft.Data.Model;
using AutoSoft.Domain.AuthBC.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Data.Mappings
{
    public class AuthBoundedContextMappings : Profile
    {
        public AuthBoundedContextMappings()
        {
            CreateMap<UsuarioModel, Usuario>().ConstructUsing(x =>  new Usuario());
            CreateMap<Usuario, UsuarioModel>();
        }
    }
}
