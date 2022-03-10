using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Pranca.WebApp.Localization.Resources
{
    public class FactoryLoaclizer
    {
        public IStringLocalizer Set(IStringLocalizerFactory factory,Type typeSharedResource)
        {
            var assemblyName = new AssemblyName(typeSharedResource .GetTypeInfo().Assembly.FullName);
            return factory.Create("SharedResource", assemblyName.Name);
        }

        public IStringLocalizer Set(IServiceCollection services, Type typeSharedResource)
        {
            var factory = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
            var assemblyName = new AssemblyName(typeSharedResource.GetTypeInfo().Assembly.FullName);
            return factory.Create("SharedResource", assemblyName.Name);
        }
    }
}
