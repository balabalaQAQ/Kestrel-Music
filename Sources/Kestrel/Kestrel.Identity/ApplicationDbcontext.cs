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
            #region GUID
            var role1ID = Guid.NewGuid();
            var role2ID = Guid.NewGuid();
            var role3ID = Guid.NewGuid();
            var user1ID = Guid.NewGuid();
            var user2ID = Guid.NewGuid();
            var user3ID = Guid.NewGuid();
            var creadteid = Guid.NewGuid();
            #endregion

            #region  角色 Role
            List<ApplicationRole> Role = new List<ApplicationRole>
            {
               new   ApplicationRole()
               {
                  Id = role1ID,
                  Name = "user",
                  NormalizedName = "USER",
                  CreateId = creadteid,
                  CreateBy="Kestrel",
                  CreateTime=DateTime.Now
                },
               new   ApplicationRole()
               {
                Id = role2ID,
                Name = "admin",
                NormalizedName = "ADMIN",
                CreateId = creadteid,
                CreateBy = "Kestrel",
                CreateTime = DateTime.Now
                },
               new   ApplicationRole()
               {
                Id = role3ID,
                Name = "KestrelAdmin",
                NormalizedName = "KestrelAdmin",
                CreateId = creadteid,
                CreateBy = "Kestrel",
                CreateTime = DateTime.Now
                },
            };


            #endregion

            #region 用户 User
            List<ApplicationUser> User = new List<ApplicationUser>
            {
              new ApplicationUser()
             {
                 Id = user1ID,
                 UserName = "User",
                 LoginName = "User",
             },
                  new ApplicationUser()
             {
                   Id = user2ID,
                UserName = "Admin",
                LoginName = "Admin",
             },
                      new ApplicationUser()
             {
                 Id = user3ID,
                UserName = "KestrelAdmin",
                LoginName = "KestrelAdmin",
             },
        };
            #endregion

            #region 用户与角色 UserRole

            List<ApplicationUserRole> UserRole = new List<ApplicationUserRole>
            {
                new ApplicationUserRole
                {
                    Role= Role[1],
                    RoleId =Role[1].Id,
                    User=User[1],
                    UserId=User[1].Id
                },
                new ApplicationUserRole
                {
                    Role= Role[2],
                    RoleId =Role[2].Id,
                    User=User[2],
                    UserId=User[2].Id
                },
                new ApplicationUserRole
                {
                    Role= Role[3],
                    RoleId =Role[3].Id,
                    User=User[31],
                    UserId=User[3].Id
                },
            };
            #endregion
            builder.Entity<ApplicationRole>();
            builder.Entity<ApplicationUser>();
            builder.Entity<ApplicationUserRole>();

            //  .ToTable("Role");


        }
       
    }
}
