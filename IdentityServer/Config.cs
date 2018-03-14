using System;
using System.Collections.Generic;
using IdentityServer4.Models;

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
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                }
            });
            return clients;
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            List<ApiResource> apiResources = new List<ApiResource>();
            apiResources.Add(new ApiResource("api1", "First API"));

            return apiResources;
        }
    }
}
