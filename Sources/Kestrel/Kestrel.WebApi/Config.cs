using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace Kestrel.Identity
{
    public static class Config
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

                    AllowedGrantTypes=GrantTypes.ResourceOwnerPasswordAndClientCredentials,

                    ClientSecrets={ new Secret("secret".Sha256())},

                    //客户端可以授权的范围
                    AllowedScopes={ "music_api" },
               }
        };
        }
        public static List<TestUser> User =>
        new List<TestUser>
        {
                new  TestUser
                {
                    SubjectId="1",
                    Username="admin",
                    Password="123456"
                }
        };

    }
}
