using MediatR;
using Serilog.Enrichers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.API.MediatR.Commands
{
    public class RegisterUserCommand:IRequest<string>
    {
        public string  UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string UserRole { get; set; }
    }
}
