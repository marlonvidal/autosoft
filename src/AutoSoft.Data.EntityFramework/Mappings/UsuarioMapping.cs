using AutoSoft.Domain.AuthBC.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Data.EntityFramework.Mappings
{
    public class UsuarioMapping : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMapping()
        {
            ToTable("Usuarios");
            HasKey(x => x.Id);
            Property(x => x.Login).IsRequired().HasMaxLength(20);
            Property(x => x.Senha).IsRequired();
        }
    }
}
