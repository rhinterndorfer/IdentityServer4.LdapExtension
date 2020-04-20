using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.LdapExtension.Models
{
    public class Roles : IdentityResource
    {
        public Roles()
        {
            
            this.Name = "roles";
            this.DisplayName = "Your roles";
            this.Description = "Your group memberships/roles (ex. apexUsers, Administrators)";
            this.Emphasize = true;
            this.Required = true;
            this.UserClaims = new String[] {"role"};
        }
    }
}
