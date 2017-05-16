using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Data.Tests
{
    [TestClass]
    public class BaseTest
    {
        private IContainer _container;

        [TestInitialize]
        public void Config()
        {
            if (this._container == null)
            {
                var builder = new ContainerBuilder();

                builder.RegisterAssemblyTypes(new Assembly[] {
                    typeof(AutoSoft.Domain.AuthBC.Usuarios.IUsuarioRepository).Assembly,
                    typeof(AutoSoft.Data.Repositories.UsuarioRepository).Assembly,
                })
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

                builder.RegisterAssemblyTypes(typeof(AutoSoft.Domain.AuthBC.Usuarios.Rules.IUsuarioRules).Assembly)
                    .Where(x => x.Name.EndsWith("Rules"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

                builder.RegisterAssemblyTypes(typeof(Domain.AuthBC.Usuarios.Validations.CriarUsuarioValidation).Assembly)
                    .Where(x => x.Name.EndsWith("Validation"))
                    .AsSelf()
                    .InstancePerLifetimeScope();

                

                builder.RegisterType<EntityFramework.EntityFrameworkUnitOfWork>().As<IUnitOfWork>();
                builder.RegisterType<EntityFramework.AutoSoftContext>().As<DbContext>();

                _container = builder.Build();
            }
        }

        protected TEntity Resolve<TEntity>()
        {
            return _container.Resolve<TEntity>();
        }
    }
}
