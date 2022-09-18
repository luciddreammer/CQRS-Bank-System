using CQRSBankSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSBankSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyQueryController : ControllerBase
    {
        private MoneyService _moneyService;

        public MoneyQueryController(MoneyService moneyService)
        {
            _moneyService = moneyService;
        }


    }   
}
