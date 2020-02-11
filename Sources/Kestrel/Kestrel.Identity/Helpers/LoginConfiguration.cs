using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kestrel.Identity.Helpers
{
    public class LoginConfiguration
    {
        public LoginResolutionPolicy ResolutionPolicy { get; set; } = LoginResolutionPolicy.Username;
    }
}
