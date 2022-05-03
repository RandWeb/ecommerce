﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pranca.Domain.Users.RoleAggregate.Entities;
using Pranca.Infrastructure.EFCore.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranca.Infrastructure.EFCore.Mapping.Users
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(p => p.ParentId).IsRequired(false).HasMaxLength(450);
            builder.Property(p => p.PageName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
            new SeedRole().Run(builder);
            builder.ToTable("Roles");
        }
    }
}
