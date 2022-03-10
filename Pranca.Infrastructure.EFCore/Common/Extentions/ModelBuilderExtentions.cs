using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pranca.Infrastructure.EFCore.Common.Extentions
{
    public static class ModelBuilderExtentions
    {
        public static void RegisterAllEntities<BaseType>(this ModelBuilder modelBuilder,params Assembly[] assemblies)
        {
            IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(BaseType).IsAssignableFrom(c));
            foreach (var type in types)
            {
                modelBuilder.Entity(type);
            }
        }
        public static void RegisterEntityTypeConfiguration(this ModelBuilder modelBuilder, params Assembly[] assemblies)
        {
            MethodInfo methodInfo = typeof(ModelBuilder).GetMethods().First(s => s.Name == nameof(ModelBuilder.ApplyConfiguration));
            IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic);

            foreach (Type type in types)
            {
                foreach (var ifacce in type.GetInterfaces())
                {
                    if (ifacce.IsConstructedGenericType && ifacce.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    {
                        MethodInfo method = methodInfo.MakeGenericMethod(ifacce.GenericTypeArguments[0]);
                        method.Invoke(modelBuilder, new object[] { Activator.CreateInstance(type) });
                    }
                }
            }
        }
    }
}
