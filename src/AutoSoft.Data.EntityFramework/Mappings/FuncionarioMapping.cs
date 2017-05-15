using AutoSoft.Domain.CoreBC.Funcionarios;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Data.EntityFramework.Mappings
{
    public class FuncionarioMapping : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioMapping()
        {
            ToTable("Funcionarios");
            HasKey(x => x.ID);
            Property(x => x.Nome).IsRequired().HasMaxLength(100);
            Property(x => x.Cargo).IsRequired().HasMaxLength(100);
            Property(x => x.Ativo).IsRequired();
        }
    }
}
