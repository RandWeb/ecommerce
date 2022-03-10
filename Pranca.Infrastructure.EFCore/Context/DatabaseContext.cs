using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pranca.Domain.Users.RoleAggregate.Entities;
using Pranca.Domain.Users.UserAggregate.Entities;
using Pranca.Infrastructure.EFCore.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pranca.Infrastructure.EFCore.Common.Extentions;
using Framework.Domain;

namespace Pranca.Infrastructure.EFCore.Context
{
    public class DatabaseContext : IdentityDbContext<User, Role, Guid>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        /// <summary>
        /// زمانی که تغییرات برای دیتابیس فرستاده می شود
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var domainAssembly = typeof(IEntity).Assembly;
            builder.RegisterAllEntities<IEntity>(domainAssembly);
            var entitiesAssemly = typeof(ISignConfiguration).Assembly;
            builder.RegisterEntityTypeConfiguration(entitiesAssemly);
        }
        /// <summary>
        /// تنظمیات اجرا شدن DatabaseContext
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
