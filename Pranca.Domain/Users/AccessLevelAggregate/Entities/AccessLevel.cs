using Framework.Domain;
using Pranca.Domain.Users.UserAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranca.Domain.Users.AccessLevelAggregate.Entities
{
    public class AccessLevel : IEntity
    {
        public Guid Id { get; set; }

        /// <summary>
        /// نام سطح دسترسی
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// کاربرهایی که این دسترسی را دارند
        /// </summary>
        public virtual ICollection<User> AccessUser { get; set; }
    }
}
