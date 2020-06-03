using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdentityServer.API.MediatR.Commands;
using MediatR;
using Newtonsoft.Json;
using IdentityServer.API.Repositories;
using IdentityServer.API.Repositories.Dtos;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private IMediator _mediator;
        private IIdentityRepository _identityRepository;

        public RegisterController(IMediator mediator, IIdentityRepository identityRepository)
        {
            _mediator = mediator;
            _identityRepository = identityRepository;
        }

        [HttpGet]
        public string getValue()
        {
            return   "test";
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            try
            {
                 //var _command = new RegisterUserCommand() { Email = command.Email, Password = command.Password, UserName = command.UserName, UserRole = command.UserRole };
                 var response = await _mediator.Send(command);

                //var user = new ApplicationUser { UserName = command.UserName, PasswordHash = command.Password, Email = command.Email, UserRole = command.UserRole };
               //var response = await _identityRepository.RegisterUser(user);
                return Ok(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}
