using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pranca.Infrastructure.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranca.Infrastructure.Core.Configuraction
{
    public static class Bootstraper
    {
        public static void Config(this IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options=> {
                options.UseSqlServer("Server=.;Database=BeautyDb;Trusted=true");
            });
        }
    }
}
