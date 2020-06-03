using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using IdentityServer.API.MediatR.Queries.Dtos;
using IdentityServer.API.MediatR.Queries;

namespace IdentityServer.API.MediatR.Queries
{
    public class FindUserQuery : IRequest<FindUserResult>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
