using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kestrel.IdentityServer4
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
              new  IdentityResources.OpenId()
            };
        }
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
               new ApiResource ("api1","My API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
               new Client
               {
                    ClientId="demo_001",

                    AllowedGrantTypes=GrantTypes.ClientCredentials,

                    ClientSecrets={ new Secret("secret".Sha256())},

                    //客户端可以授权的范围
                    AllowedScopes={ "api1" },
               }
        };
        }
    }
}
