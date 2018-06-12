using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Models;

namespace EventsApi
{
    public class IdentityProviderSeedData
    {
        public static IEnumerable<ApiResource> GetApiResourceses()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "events_api",
                    ApiSecrets = {new Secret("api_secret".Sha256())},
                    Scopes = {new Scope("events_api") }
                }
            };
        }


        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "test_client",
                    AllowedGrantTypes = {GrantType.ClientCredentials},
                    ClientSecrets = {new Secret("client_secret".Sha256())},
                    AllowedScopes = {"events_api"},
                    AccessTokenType = AccessTokenType.Reference,
                    Claims = {new Claim(JwtClaimTypes.Role, "events_api.admin") }
                }
            };
        }
    }
}