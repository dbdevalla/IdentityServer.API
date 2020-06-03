using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using IdentityServer.API.MediatR.Queries;
using IdentityServer.API.MediatR.Queries.Dtos;
using IdentityServer.API.Repositories;

namespace IdentityServer.API.MediatR.Handler
{
    public class FindUserQueryHandler: IRequestHandler<FindUserQuery, FindUserResult>
    {
        private IUserRepository _userRepository;

        public FindUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<FindUserResult> Handle(FindUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FinduserAsync(request.UserName.ToString());
            if (user != null && _userRepository.CheckUserPasswordAsync(user, request.Password))
            {
                return new FindUserResult { UserName = user.UserName, Password = user.Password, Claims = _userRepository.GetClaimsAsync(user) };
            }

            return null;
        }
    }
}
