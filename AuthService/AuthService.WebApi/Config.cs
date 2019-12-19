using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace AuthService.WebApi
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("profileapi", "Profile Api")
                {
                    Scopes = {new Scope("apiread")}
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client {

                    RequireConsent = false,

                    ClientId = "mycastlespalocal",

                    ClientName = "MyCastle Spa Local",

                    AllowedGrantTypes = GrantTypes.Implicit,

                    AllowedScopes = { "openid", "profile", "email", "apiread" },

                    RedirectUris = {"http://localhost:4200/auth-callback"},

                    PostLogoutRedirectUris = {"http://localhost:4200/"},

                    AllowedCorsOrigins = {"http://localhost:4200"},

                    AllowAccessTokensViaBrowser = true,

                    AccessTokenLifetime = 3600,
                },

                new Client
                {
                    RequireConsent = false,

                    ClientId = "mycastlespa",

                    ClientName = "MyCastle Spa",

                    AllowedGrantTypes = GrantTypes.Implicit,

                    AllowedScopes = { "openid", "profile", "email", "apiread" },

                    RedirectUris = {"https://oursuperhomeservices.web.app/auth-callback"},

                    PostLogoutRedirectUris = {"https://oursuperhomeservices.web.app/"},

                    AllowedCorsOrigins = {"https://oursuperhomeservices.web.app"},

                    AllowAccessTokensViaBrowser = true,

                    AccessTokenLifetime = 3600,
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password"
                }
            };
        }
    }
}
