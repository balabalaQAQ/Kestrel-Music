
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kestrel._Identity
{
    public class Config
    {
        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource>
         {
            new ApiResource("music_api", "Kestrel API")
         };
          public static IEnumerable<Client> Clients =>
            new List<Client>
         {
         new Client
         {
            ClientId = "client",

            // no interactive user, use the clientid/secret for authentication
            AllowedGrantTypes = GrantTypes.ClientCredentials,

            // secret for authentication
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },

            // scopes that client has access to
            AllowedScopes = { "music_api" }
        }
       };

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
               new ApiResource ("music_api","Kestrel API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
               new Client
               {
                    ClientId="music_id",

                    AllowedGrantTypes=GrantTypes.ClientCredentials,

                    ClientSecrets={ new Secret("secret".Sha256())},

                    //客户端可以授权的范围
                    AllowedScopes={ "music_api" },
               }
        };
        }
    }
}
