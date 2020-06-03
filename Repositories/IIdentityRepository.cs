using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.API.MediatR.Commands;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IdentityServer.API.Repositories.Dtos;


namespace IdentityServer.API.Repositories
{
    public interface IIdentityRepository
    {
        Task<string> RegisterUser(RegisterUserCommand command);
    }
}
