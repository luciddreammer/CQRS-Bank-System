using Microsoft.AspNetCore.Mvc;
using CQRSBankSystem.Data.ViewModels;
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
