using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace IdentityServer.API.MediatR.Queries
{
    public class FindUserResult
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<Claim> Claims { get; set; }
    }
}
