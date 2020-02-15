
using Kestrel.EntityModel.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Kestrel.IdentityServer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<Guid>
    {

        public string LoginName { get; set; }

        public string RealName { get; set; }

        public int Sex { get; set; } = 0;

        public int Age { get; set; }

        public DateTime Birth { get; set; } = DateTime.Now;

        public string Addr { get; set; }

        public bool TdIsDelete { get; set; }


       
        public ICollection<ApplicationUserRole> UserRoles { get; set; }

        public virtual KestrelMusicUser MusicUser { get; set; }
    }
}
