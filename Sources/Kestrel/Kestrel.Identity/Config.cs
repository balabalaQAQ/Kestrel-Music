
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kestrel.Identity
{
    public   class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource("roles", "角色", new List<string> { JwtClaimTypes.Role }),
                new IdentityResource("rolename", "角色名", new List<string> { "rolename" }),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource> {
                new ApiResource("music_api", " Music_API") {
                    // include the following using claims in access token (in addition to subject id)
                    //requires using using IdentityModel;
                    UserClaims = { JwtClaimTypes.Name, JwtClaimTypes.Role },
                    ApiSecrets = new List<Secret>()
                    {
                        new Secret("api_secret".Sha256())
                    },
                }
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            // client
            return new List<Client> {
                // blog.vue 前端vue项目
                new Client {
                    ClientId = "music",
                    ClientName = "kestrel_music",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    ClientSecrets={ new Secret("secret".Sha256())},
                    //RedirectUris =           {
                    //    "http://vueblog.neters.club/callback",
                    //    "http://apk.neters.club/oauth2-redirect.html"
                    //},
                    //PostLogoutRedirectUris = { "http://vueblog.neters.club" },
                    //AllowedCorsOrigins =     { "http://vueblog.neters.club" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "music_api"
                    }
                },
                // blog.admin 前端vue项目
                new Client {
                    ClientId = "blogadminjs",
                    ClientName = "Blog.Admin JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
              
                    RedirectUris =
                    {
                        "http://vueadmin.neters.club/callback",
                        "http://apk.neters.club/oauth2-redirect.html"
                    },
                    PostLogoutRedirectUris = { "http://vueadmin.neters.club" },
                    AllowedCorsOrigins =     { "http://vueadmin.neters.club" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "blog.core.api"
                    }
                },
                // nuxt.tbug 前端nuxt项目
                new Client {
                    ClientId = "tibugnuxtjs",
                    ClientName = "Nuxt.tBug JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "http://tibug.neters.club/callback" },
                    PostLogoutRedirectUris = { "http://tibug.neters.club" },
                    AllowedCorsOrigins =     { "http://tibug.neters.club" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "blog.core.api"
                    }
                },
                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "chrisdddmvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = false,
                    RequirePkce = true,
                    AlwaysIncludeUserClaimsInIdToken=true,//将用户所有的claims包含在IdToken内
                
                    // where to redirect to after login
                    RedirectUris = { "http://ddd.neters.club/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "http://ddd.neters.club/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "roles",
                        "rolename",
                    }
                }
            };
        }
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[] { };

        public static IEnumerable<Client> Clients =>
            new Client[] { };
    }

}
