using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Pranca.Domain.Users.RoleAggregate.Entities;
using Pranca.Domain.Users.UserAggregate.Entities;
using Pranca.Infrastructure.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pranca.Infrastructure.Core.Configuraction
{
    public static class IdentityConfiguration
    {
        public static IdentityBuilder AddCustomIdentitiy(this IServiceCollection services)
        {
            return services.AddIdentity<User, Role>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = true;

                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_@";
                options.User.RequireUniqueEmail = true;

                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequiredLength = 6;

                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0,15,0);
                options.Lockout.MaxFailedAccessAttempts = 3;
            })
               .AddEntityFrameworkStores<DatabaseContext>()
               .AddDefaultTokenProviders();
        }
    }
}
