using Framework.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranca.Domain.Users.UserAggregate.Entities
{

    /// <summary>
    /// اطلاعات کاربر
    /// </summary>
    public class User : IdentityUser<Guid> , IEntity
    {
        /// <summary>
        /// نام
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// زمان ورود
        /// </summary>
        public DateTime Date { get; set; }

    }
}
