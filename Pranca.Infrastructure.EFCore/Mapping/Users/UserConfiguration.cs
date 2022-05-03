using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pranca.Domain.Users.UserAggregate.Entities;
using Pranca.Infrastructure.EFCore.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranca.Infrastructure.EFCore.Mapping.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>, ISignConfiguration
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(s => s.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(s => s.LastName).IsRequired().HasMaxLength(100);
            builder.HasOne(a => a.UserAccessLevel)
                 .WithMany(a => a.AccessUser)
                 .HasPrincipalKey(a => a.Id)
                 .HasForeignKey(a=>a.AccessLevelId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Users");
        }
    }
}
