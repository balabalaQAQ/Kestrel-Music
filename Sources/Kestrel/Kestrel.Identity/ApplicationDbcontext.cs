using Kestrel.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kestrel.Identity
{


    public class ApplicationDbcontext
   : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, IdentityUserClaim<Guid>,
   ApplicationUserRole, IdentityUserLogin<Guid>,
   IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //// 就是这里，我们可以修改下表名等其他任意操作
            base.OnModelCreating(builder);
            builder.Entity<ApplicationRole>();
            builder.Entity<ApplicationUser>();
            builder.Entity<ApplicationUserRole>();

            //  .ToTable("Role");
        }
       
    }
}
