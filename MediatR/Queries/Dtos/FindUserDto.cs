using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.API.MediatR.Queries.Dtos
{
    public class FindUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
