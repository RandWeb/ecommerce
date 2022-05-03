
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Pranca.Domain.Users.UserAggregate.Contracts;
using Pranca.Domain.Users.UserAggregate.Entities;
using Pranca.Infrastructure.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranca.Infrastructure.EFCore.Repositories.Users
{
    public class UserRepository : BaseRepository<User>,IUserRepository
    {
        public UserRepository(DatabaseContext _dbContext) : base(_dbContext)
        {
        }
    }
}
