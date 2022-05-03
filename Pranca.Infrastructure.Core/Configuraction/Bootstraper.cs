﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Pranca.Domain.Users.UserAggregate.Contracts;
using Pranca.Infrastructure.EFCore.Context;
using Pranca.Infrastructure.EFCore.Repositories.Users;
using Pranca.Infrastructure.Logger.Contracts;
using Pranca.Infrastructure.SeriLogger;
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
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer("Server=.;Database=BeautyDb;Trusted_Connection=true");
            });

            services.AddScoped<ILogger,Serilogger>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
