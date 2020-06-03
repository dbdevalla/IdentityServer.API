using IdentityServer.API.MediatR.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IdentityServer.API.Repositories.Dtos;

namespace IdentityServer.API.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public IdentityRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<string> RegisterUser(RegisterUserCommand command)
        {
            var user = new IdentityUser { UserName = command.UserName, PasswordHash = command.Password, Email = command.Email };

            var userExists = await _userManager.FindByNameAsync(command.UserName);
            if (userExists != null)
            {
                return "User Already Exists";
            }
            else
            {
                var response = await _userManager.CreateAsync(user, user.PasswordHash);
                if (response.Succeeded)
                {
                    var roleexist = await _roleManager.FindByNameAsync(command.UserRole);


                    if (roleexist == null)
                    {
                        var roleresult = await _roleManager.CreateAsync(new IdentityRole { Name = command.UserRole });
                        if (roleresult.Succeeded)
                        {
                            var rolresult = _userManager.AddToRoleAsync(user, command.UserRole);
                        }
                    }
                    else
                    {

                        var rolresult =await _userManager.AddToRoleAsync(user, command.UserRole);
                    }
                    return "User Registered Successfully";
                }
            }
            return "User Registration Failed";
        }
    }
}
