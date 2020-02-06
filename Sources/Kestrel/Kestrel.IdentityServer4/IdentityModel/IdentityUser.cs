using Kestrel.EntityModel.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kestrel.IdentityServer4.IdentityModel
{
    public class IdentityUser
    {
        public Guid Id { get; set; }     

        [Required]
        public int Account { get; set; }//账号

        [Required]
        public string Password { get; set; }    // 密码
        public bool RememberLogin { get; set; } // 是否记住
        public string ReturnUrl { get; set; }   // 成功后返回的路径

        public virtual IdentityRole Role { get; set; }//角色

        public string RoleID { get; set; }

       // public User User { get; set; }

        public string UserID { get; set; }
    }
}
