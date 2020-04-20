// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace QuickstartIdentityServer
{
    public class InMemoryInitConfig
    {
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
                new IdentityServer.LdapExtension.Models.Roles(),

            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                // OpenID Connect 
                new Client
                {
                    ClientId = "PLAYGROUND",
                    ClientName = "PLAYGROUND",
                    AllowedGrantTypes = GrantTypes.Code,

                    ClientSecrets =
                    {
                        new Secret("MyPlaygroundSecret".Sha256())
                    },

                    RedirectUris = { 
                        "http://localhost:8181/apex/apex_authentication.callback",
                        "http://localhost:8080/ords/apex_authentication.callback",
                        "https://dev.rammelhof.at/ords/apex_authentication.callback"
                    },
                    PostLogoutRedirectUris = {
                        "http://localhost:8181/apex/f?p=100",
                        "http://localhost:8080/ords/f?p=100",
                        "https://dev.rammelhof.at/ords/f?p=100" 
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Phone,
                        "roles",
                        "api1"
                    },
                    AllowOfflineAccess = true
                }
            };
        }
    }
}