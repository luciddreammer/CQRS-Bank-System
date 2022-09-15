using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CQRSBankSystem.Data;
using CQRSBankSystem.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Internal;
using CQRSBankSystem.Services;

namespace CQRSBankSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private RegistrationService _registrationService;

        public RegisterController(RegistrationService registerservices)
        {
            _registrationService = registerservices;
        }

        [HttpPost("Register-new-User")]
        public IActionResult RegisterNewUser([FromBody]UserVM newUser)
        {
            _registrationService.RegisterNewuser(newUser);
            return Ok();
        }
    }
}
