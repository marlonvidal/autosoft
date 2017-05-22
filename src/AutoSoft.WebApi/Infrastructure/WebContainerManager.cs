using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace AutoSoft.WebApi.Infrastructure
{
    public static class WebContainerManager
    {
        private static HttpConfiguration _config;

        public static IDependencyResolver GetDependencyResolver()
        {
            if (_config == null)
                throw new InvalidOperationException("The configuration has not been initialized");

            var dependencyResolver = _config.DependencyResolver;
            if (dependencyResolver != null)
            {
                return dependencyResolver;
            }
            throw new InvalidOperationException("The dependency resolver has not been set.");
        }

        public static void SetConfiguration(HttpConfiguration config)
        {
            _config = config;
        }

        public static T Get<T>()
        {
            var service = GetDependencyResolver().GetService(typeof(T));

            if (service == null)
                throw new NullReferenceException(string.Format("Requested service of type {0}, but null was found.", typeof(T).FullName));

            return (T)service;
        }

        public static IEnumerable<T> GetAll<T>()
        {
            var services = GetDependencyResolver().GetServices(typeof(T)).ToList();

            if (!services.Any())
                throw new NullReferenceException(string.Format("Requested services of type {0}, but none were found.", typeof(T).FullName));

            return services.Cast<T>();
        }
    }
}