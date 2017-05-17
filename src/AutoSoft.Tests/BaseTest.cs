using Autofac;
using AutoSoft.Data;
using AutoSoft.Data.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Tests
{
    [TestClass]
    public class BaseTest
    {
        private IContainer _container;

        [TestInitialize]
        public void ConfigDependencies()
        {
            if (this._container == null)
            {
                var builder = new ContainerBuilder();

                builder.RegisterAssemblyTypes(new Assembly[] {
                        typeof(AutoSoft.Domain.AuthBC.Usuarios.IUsuarioRepository).Assembly,
                        typeof(AutoSoft.Domain.CoreBC.Carros.Carro).Assembly,
                        typeof(AutoSoft.Data.Repositories.UsuarioRepository).Assembly,
                        typeof(AutoSoft.Data.EntityFramework.AutoSoftContext).Assembly
                    })
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

                builder.RegisterAssemblyTypes(new Assembly[] {
                    typeof(AutoSoft.Domain.AuthBC.Usuarios.Validations.CriarUsuarioValidation).Assembly,
                    typeof(AutoSoft.Domain.CoreBC.Carros.Carro).Assembly
                    })
                    .Where(x => x.Name.EndsWith("Validation"))
                    .AsSelf()
                    .InstancePerLifetimeScope();                

                builder.RegisterType<EntityFrameworkUnitOfWork>().As<IUnitOfWork>();
                builder.RegisterType<AutoSoftContext>().As<DbContext>();

                _container = builder.Build();
            }
        }

        protected TEntity Resolve<TEntity>()
        {
            return _container.Resolve<TEntity>();
        }
    }
}
