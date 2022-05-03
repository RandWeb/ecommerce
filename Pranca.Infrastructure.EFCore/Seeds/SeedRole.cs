using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pranca.Domain.Users.RoleAggregate.Entities;
using Pranca.Infrastructure.EFCore.Common.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranca.Infrastructure.EFCore.Seeds
{
    public class SeedRole
    {

        public void Run(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role()
            {
                Id = new Guid().SequentialGuid(),
                ParentId = Guid.Empty,
                PageName = "FullControl",
                Sort = 0,
                Name = "FullControl",
                NormalizedName = "FullControl".ToUpper(),
                Description = "دسترسی مدیر کل"
            });
        }
    }
}
