using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoSoft.WebApi.Infrastructure
{
    public static class AutofacConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Mapper>().As<IMapper>();

            var container = builder.Build();
            //DependecyResoler
        }
    }
}