using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kestrel.Identity
{
    // 自定义属性
    public class ApplicationUser : IdentityUser
    {
        //名字
        public string Name { get; set; }
        //简介
        public string Description { get; set; }
        //性别
        public int Sex { get; set; } = 0;
    }
    public class ApplicationDbcontext : IdentityDbContext<IdentityUser  >
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
        }
    }
}
