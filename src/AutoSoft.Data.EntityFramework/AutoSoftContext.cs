using AutoSoft.Domain.AuthBC.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Data.EntityFramework
{
    public class AutoSoftContext : DbContext
    {
        public AutoSoftContext()
            : base("AutoSoftConnectionString")
        {
            Database.SetInitializer(new AutoSoftInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
