using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer.API.MediatR.Commands;
using MediatR;
using IdentityServer.API.Models;
using IdentityServer.API.Repositories;

namespace IdentityServer.API.MediatR.Handler
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,string>
    {
        private IIdentityRepository _identityRepository;

        public RegisterUserCommandHandler(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return _identityRepository.RegisterUser(request);

        }
    }
}
