using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Validation;
using IdentityServer.API.Repositories;
using IdentityServer.API.Models;
using IdentityServer.API.MediatR.Handler;
using IdentityServer.API.MediatR.Queries;
using MediatR;

namespace IdentityServer.API.Authentication
{
    public class ResoureOwmerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public IUserRepository _userRepository;
        private IMediator _mediator;

        public ResoureOwmerPasswordValidator(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            string UName = Convert.ToString(context.Request.Raw["username"]);
            string Pwd= Convert.ToString(context.Request.Raw["password"]);
            var query = new FindUserQuery() { UserName = UName, Password=Pwd};

            FindUserResult result = await _mediator.Send(query);

            //User user = _userRepository.FinduserAsync(context.Request.Raw["username"]);
            //if (user != null && _userRepository.CheckUserPasswordAsync(user, context.Request.Raw["password"].ToString()))
            //{
            if (result != null)
            {

                context.Result = new GrantValidationResult(result.UserName.ToString(), "password", result.Claims);

            }

            //  Task.FromResult(0);
        }
    }
}
