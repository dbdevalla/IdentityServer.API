using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Endpoints;
using IdentityServer4;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer.API
{
    public class Config
    {

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {

                new ApiResource { Name="Api1"}
            };
        }


        public static IEnumerable<Client> GetClients()
        {

            return new List<Client>
            {
                new Client
                {
                    ClientName="ResourceOwner",
                    ClientId="RO",
                    ClientSecrets=new List<Secret>
                    {
                        new Secret("ResourceOwner".Sha256())
                    },
                    AllowedGrantTypes=IdentityServer4.Models.GrantTypes.ResourceOwnerPassword,
                    AllowedScopes=new List<string>
                    {
                       IdentityServerConstants.StandardScopes.OpenId
                    }

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

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResources.Phone(),
                new IdentityResources.Address()
            };
        }

    }
}
