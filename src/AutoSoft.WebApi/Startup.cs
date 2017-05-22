using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using AutoSoft.Data.EntityFramework;
using AutoSoft.Data.Mappings;
using AutoSoft.Infrastructure.Domain;
using AutoSoft.WebApi.Infrastructure;
using AutoSoft.WebApi.Infrastructure.ExceptionHandling;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

[assembly: OwinStartup(typeof(AutoSoft.WebApi.Startup))]
namespace AutoSoft.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = BuildIoCContainer(config);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }

        private IContainer BuildIoCContainer(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(new Assembly[] {
                    typeof(AutoSoft.Domain.AuthBC.Usuarios.IUsuarioRepository).Assembly,
                    typeof(AutoSoft.Domain.CoreBC.Carros.Carro).Assembly,
                    typeof(AutoSoft.Data.Repositories.UsuarioRepository).Assembly,
                    typeof(AutoSoft.Data.EntityFramework.AutoSoftContext).Assembly,
                    typeof(AutoSoft.Infrastructure.Commands.CommandSender).Assembly
                })
                .AsImplementedInterfaces()
                .InstancePerRequest();


            builder.RegisterAssemblyTypes(new Assembly[] {
                    typeof(Domain.AuthBC.Usuarios.Validations.CriarUsuarioValidation).Assembly,
                    typeof(AutoSoft.Domain.CoreBC.Carros.Carro).Assembly
                })
                .Where(x => x.Name.EndsWith("Validation"))
                .AsSelf()
                .InstancePerRequest();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL - Register the filter provider if you have custom filters that need DI.
            // Also hook the filters up to controllers.
            //builder.RegisterWebApiFilterProvider(config);
            //builder.RegisterType<CustomActionFilter>() .AsWebApiActionFilterFor<TestController>().InstancePerRequest();

            builder.RegisterType<AutoSoftContext>()
                .As<DbContext>()
                .InstancePerRequest();

            builder.Register(x => HttpContext.Current != null ?
                new HttpContextWrapper(HttpContext.Current) :
                x.Resolve<HttpRequestMessage>().Properties["MS_HttpContext"])
                .As<HttpContextBase>()
                .InstancePerRequest();

            builder.RegisterType<UserIdentity>()
                .As<IIdentity>()
                .InstancePerRequest();

            builder.Register(x => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AuthBoundedContextMappings());
            }).CreateMapper())
            .As<IMapper>().SingleInstance();


            return builder.Build();
        }
    }
}