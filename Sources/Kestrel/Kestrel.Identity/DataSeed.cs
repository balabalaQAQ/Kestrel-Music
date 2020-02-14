using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using Kestrel.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kestrel.Identity
{
    public class DataSeed
    {
        #region 种子数据配置   EnsureSeedData(IServiceProvider serviceProvider)
        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();


                //var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                //context.Database.Migrate();
                //EnsureSeedData(context);

                var context = scope.ServiceProvider.GetService<ApplicationDbcontext>();
                context.Database.Migrate();

                var userMgnagger = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleMgnagger = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();


                List<ApplicationRole> roles = Role();
                List<ApplicationUser> users = User();
                List<ApplicationUserRole> userRoles = UserRole(roles, users);
              //List<Claim> claims = Claims(roles, users);
              //claims.AddRange(roles.Select(s => new Claim(JwtClaimTypes.Role, s.ToString())));

                for (int i = 0; i < 3; i++)
                {
                    userMgnagger.CreateAsync(users[i], "123@Abc") ;
                   // userMgnagger.AddClaimAsync(users[i], claims[i]) ;
                    roleMgnagger.CreateAsync(roles[i]);
                    context.UserRoles.Add(userRoles[i]);
                  
                };
                context.SaveChanges();
            }
        }

        private static List<Claim> Claims(List<ApplicationRole> roles, List<ApplicationUser> users)
        {
            return new List<Claim>{
                    new Claim(JwtClaimTypes.Name, users[1].RealName),
                    new Claim(JwtClaimTypes.Email, $"{users[1].LoginName}@email.com"),
                    new Claim("rolename", roles[1].Name),
                    };
        }
        #endregion
        #region 用户与角色
        private static List<ApplicationRole> Role()
        {
            var carateId = Guid.NewGuid();
            return new List<ApplicationRole>
            {
               new   ApplicationRole()
               {
                  Id = Guid.NewGuid(),
                  Name = "user",
                  NormalizedName = "USER",
                  CreateId =carateId,
                  CreateBy="Kestrel",
                  CreateTime=DateTime.Now
                },
               new   ApplicationRole()
               {
                Id = Guid.NewGuid(),
                Name = "admin",
                NormalizedName = "ADMIN",
                CreateId =carateId,
                CreateBy = "Kestrel",
                CreateTime = DateTime.Now
                },
               new   ApplicationRole()
               {
                Id = Guid.NewGuid(),
                Name = "KestrelAdmin",
                NormalizedName = "KestrelAdmin",
                CreateId = carateId,
                CreateBy = "Kestrel",
                CreateTime = DateTime.Now
                },
            };
        }

        private static List<ApplicationUser> User()
        {
            return new List<ApplicationUser>
            {
                  new ApplicationUser()
                 {
                     Id =  Guid.NewGuid(),
                     UserName = "User",
                     LoginName = "User",
                     RealName="普通用户"
                 },
                  new ApplicationUser()
                 {
                    Id =  Guid.NewGuid(),
                    UserName = "Admin",
                    LoginName = "Admin",
                    RealName="普通管理员"
                 },
                  new ApplicationUser()
                 {
                    Id =  Guid.NewGuid(),
                    UserName = "KestrelAdmin",
                    LoginName = "KestrelAdmin",
                    RealName="Kestrel级管理员"
                 },
             };
        }

        private static List<ApplicationUserRole> UserRole(List<ApplicationRole> Role, List<ApplicationUser> User)
        {
            return new List<ApplicationUserRole>
            {
                new ApplicationUserRole
                {
                    Role= Role[0],
                    RoleId =Role[0].Id,
                    User=User[0],
                    UserId=User[0].Id
                },
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
            };
        }
        #endregion  

    }
}
