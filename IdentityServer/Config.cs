using System;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            List<Client> clients = new List<Client>();

            // Client 1
            clients.Add(new Client()
            {
                ClientId = "Client1",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },

                AllowedScopes =
                {
                    "api1"
                }
            });

            clients.Add(new Client()
            {
                ClientId = "mvc",
                ClientName = "MVC",
                AllowedGrantTypes = GrantTypes.Implicit,

                // where to redirect to after login
                RedirectUris = { "http://localhost:6600/signin-oidc" },

                // where to redirect to after logout
                PostLogoutRedirectUris = { "http://localhost:6600/signout-callback-oidc" },

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "roles"
                },
                AlwaysIncludeUserClaimsInIdToken = true

            });
            return clients;
        }

        //Defining the InMemory API's
        public static IEnumerable<ApiResource> GetApiResources()
        {
            List<ApiResource> apiResources = new List<ApiResource>();
            apiResources.Add(new ApiResource("api1", "First API"));

            return apiResources;
        }

        //Defining the InMemory User's
        public static List<TestUser> GetUsers()
        {
            List<TestUser> testUsers = new List<TestUser>();

            testUsers.Add(new TestUser()
            {
                SubjectId = "1",
                Username = "admin",
                Password = "password",

                Claims = new List<Claim>
                {
                    new Claim("role","admin"),
                }
            });
            testUsers.Add(new TestUser()
            {
                SubjectId = "2",
                Username = "editor",
                Password = "password2",

                Claims = new List<Claim>
                {
                    new Claim("role","editor"),
                }
            });

            return testUsers;
        }



        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            List<IdentityResource> resources = new List<IdentityResource>();

            resources.Add(new IdentityResources.OpenId());
            resources.Add(new IdentityResources.Profile());
            resources.Add(new IdentityResource("roles", new[] { "roles" }));

            return resources;
        }

    }
}
