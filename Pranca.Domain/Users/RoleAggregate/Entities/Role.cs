using Framework.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranca.Domain.Users.RoleAggregate.Entities
{
    /// <summary>
    /// نقش کاربر
    /// </summary>
    public class Role : IdentityRole<Guid>,IEntity
    {
        /// <summary>
        /// توضیحات نقش
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// برای مرتب سازی نقش ها
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// نام صفحه ای که این دسترسی برایش نوشته شده ست
        /// </summary>
        public string PageName { get; set; }
        /// <summary>
        /// شناسه والد نقش
        /// </summary>
        public Guid? ParentId { get; set; }
    }
}
