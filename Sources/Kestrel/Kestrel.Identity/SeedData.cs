﻿using System;
using System.Linq;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Kestrel.IdentityServer;
using Kestrel.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System.Collections.Generic;
using System.Text;
using Kestrel.Identity.Helpers;
using Kestrel.Identity;

namespace Kestrel.Identity
{
    public class SeedData
    {
        private static string GitJsonFileFormat = "https://gitee.com/laozhangIsPhi/Blog.Data.Share/raw/master/BlogCore.Data.json/{0}.tsv";

        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {
            //1.dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb
            //2.dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb
            //3.dotnet ef migrations add AppDbMigration -c ApplicationDbcontext -o Data
            //4.dotnet run /seed
            Console.WriteLine("Seeding database...");

            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                {
                    var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                    context.Database.Migrate();
                    EnsureSeedData(context);
                }

                {
                    var context = scope.ServiceProvider.GetService<ApplicationDbcontext>();
                    context.Database.Migrate();

                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                    var BlogCore_Users = JsonHelper.ParseFormByJson<List<sysUserInfo>>(GetNetData.Get(string.Format(GitJsonFileFormat, "sysUserInfo")));
                    var BlogCore_Roles = JsonHelper.ParseFormByJson<List<Role>>(GetNetData.Get(string.Format(GitJsonFileFormat, "Role")));
                    var BlogCore_UserRoles = JsonHelper.ParseFormByJson<List<UserRole>>(GetNetData.Get(string.Format(GitJsonFileFormat, "UserRole")));

                    foreach (var user in BlogCore_Users)
                    {
                        if (user == null || user.uLoginName == null)
                        {
                            continue;
                        }
                        var userItem = userMgr.FindByNameAsync(user.uLoginName).Result;
                        var rid = BlogCore_UserRoles.FirstOrDefault(d => d.UserId == user.uID)?.RoleId;
                        var rName = BlogCore_Roles.Where(d => d.Id == rid).Select(d => d.Id).ToList();
                        var roleName = BlogCore_Roles.FirstOrDefault(d => d.Id == rid)?.Name;

                        if (userItem == null)
                        {
                            if (rid > 0 && rName.Count > 0)
                            {
                                userItem = new ApplicationUser
                                {
                                    UserName = user.uLoginName,
                                    LoginName = user.uRealName,
                                    sex = user.sex,
                                    age = user.age,
                                    birth = user.birth,
                                    addr = user.addr,
                                    tdIsDelete = user.tdIsDelete

                                };

                                //var result = userMgr.CreateAsync(userItem, "BlogIdp123$" + item.uLoginPWD).Result;

                                // 因为导入的密码是 MD5密文，所以这里统一都用初始密码了
                                var pwdInit = "123@Abc";
                                //if (userItem.UserName== "blogadmin")
                                //{
                                //    pwdInit = "#InitPwd";
                                //}
                                var result = userMgr.CreateAsync(userItem, pwdInit).Result;
                                if (!result.Succeeded)
                                {
                                    throw new Exception(result.Errors.First().Description);
                                }

                                var claims = new List<Claim>{
                                    new Claim(JwtClaimTypes.Name, user.uRealName),
                                    new Claim(JwtClaimTypes.Email, $"{user.uLoginName}@email.com"),
                                    new Claim("rolename", roleName),
                                };

                                claims.AddRange(rName.Select(s => new Claim(JwtClaimTypes.Role, s.ToString())));


                                result = userMgr.AddClaimsAsync(userItem, claims).Result;


                                if (!result.Succeeded)
                                {
                                    throw new Exception(result.Errors.First().Description);
                                }
                                Console.WriteLine($"{userItem?.UserName} created");//AspNetUserClaims 表

                            }
                            else
                            {
                                Console.WriteLine($"{user?.uLoginName} doesn't have a corresponding role.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{userItem?.UserName} already exists");
                        }

                    }

                    foreach (var role in BlogCore_Roles)
                    {
                        if (role == null || role.Name == null)
                        {
                            continue;
                        }
                        var roleItem = roleMgr.FindByNameAsync(role.Name).Result;

                        if (roleItem != null)
                        {
                            role.Name = role.Name + Guid.NewGuid().ToString("N");
                        }

                        roleItem = new ApplicationRole
                        {
                            CreateBy = role.CreateBy,
                            Description = role.Description,
                            IsDeleted = role.IsDeleted != null ? (bool)role.IsDeleted : true,
                            CreateId = role.CreateId,
                            CreateTime = role.CreateTime,
                            Enabled = role.Enabled,
                            Name = role.Name,
                            OrderSort = role.OrderSort,
                        };

                        var result = roleMgr.CreateAsync(roleItem).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        Console.WriteLine($"{roleItem?.Name} created");//AspNetUserClaims 表

                    }

                }
            }

            Console.WriteLine("Done seeding database.");
            Console.WriteLine();
        }

        private static void EnsureSeedData(ConfigurationDbContext context)
        {
            if (!context.Clients.Any())
            {
                Console.WriteLine("Clients being populated");

                foreach (var client in Config.GetClients().ToList())

                {
                    context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Clients already populated");
            }

            if (!context.IdentityResources.Any())
            {
                Console.WriteLine("IdentityResources being populated");
                foreach (var resource in Config.GetIdentityResources().ToList())
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("IdentityResources already populated");
            }

            if (!context.ApiResources.Any())
            {
                Console.WriteLine("ApiResources being populated");
                foreach (var resource in Config.GetApiResources().ToList())
                {
                    context.ApiResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("ApiResources already populated");
            }
        }
    }
}
