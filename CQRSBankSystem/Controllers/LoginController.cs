using CQRSBankSystem.Data.ViewModels;
using CQRSBankSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace CQRSBankSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("Login")]
        public IActionResult LoginUser(string login, string password)
        {
            _loginService.LoginUser(login, password);
            return Ok();
        }

        [HttpPost("Logout")]
        public IActionResult LogoutUser()
        {
            _loginService.LogoutUser();
            return Ok();
        }

    }
}
