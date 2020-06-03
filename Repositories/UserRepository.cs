using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.API.Models;
using System.Security.Claims;
using System.Security.Cryptography;
using IdentityServer.API.MediatR.Queries.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using IdentityServer.API.MediatR.Commands;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IdentityServerDbContext _identityServerDbContext;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserRepository(IdentityServerDbContext identityServerDbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _identityServerDbContext = identityServerDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public bool CheckUserPasswordAsync(FindUserDto user, string password)
        {
            var AppUser = new IdentityUser { UserName = user.UserName, PasswordHash = password };
            PasswordVerificationResult verificationResult = _userManager.PasswordHasher.VerifyHashedPassword(AppUser, user.Password, password);

            if (verificationResult==PasswordVerificationResult.Success)
                return true;
            return false;
        }

        public async Task<FindUserDto> FinduserAsync(string UserName)
        {
            // var user = _identityServerDbContext.Users.FirstOrDefault(x => x.UserName == UserName);

            //var user = await (from u in _identityServerDbContext.UserTable
            //                  join
            //                  ro in _identityServerDbContext.RoleTable on u.RoleID equals ro.RoleID
            //                  select new
            //                  { u.UserName, u.Password, ro.RoleName }).FirstOrDefaultAsync(x => x.UserName == UserName);


            var user = await _userManager.FindByNameAsync(UserName);
            string userrole = string.Empty;
            if (user != null)
            {
                var RoleName = await _userManager.GetRolesAsync(user);

                userrole = RoleName.FirstOrDefault();
            }



            return user != null ? new FindUserDto { UserName = user.UserName, Password = user.PasswordHash, Role = userrole } : null;
        }

        public List<Claim> GetClaimsAsync(FindUserDto user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("UserName", user.UserName));            
            claims.Add(new Claim("Role", user.Role));

            return claims;

        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _identityServerDbContext.UserTable.ToListAsync();
        }





    }
}
