using Microsoft.AspNetCore.Identity;
using System;

namespace Kestrel.IdentityServer.Models
{
    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}