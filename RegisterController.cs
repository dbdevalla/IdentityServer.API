using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API
{
    public class RegisterController : Controller
    {
        [HttpPost]
        public IActionResult Register()
        {
            return View();
        }
    }
}
