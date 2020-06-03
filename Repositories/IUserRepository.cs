using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using IdentityServer.API.MediatR.Queries.Dtos;

namespace IdentityServer.API.Repositories
{
    public interface IUserRepository
    {
        Task<FindUserDto> FinduserAsync(string UserName);

        bool CheckUserPasswordAsync(FindUserDto user, string password);

      //  Task<List<FindUserDto>> GetUsersAsync();

        List<Claim> GetClaimsAsync(FindUserDto user);

    }
}
