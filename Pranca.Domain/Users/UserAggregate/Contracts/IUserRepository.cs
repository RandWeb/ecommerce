using Framework.Domain;
using Pranca.Domain.Users.UserAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranca.Domain.Users.UserAggregate.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
