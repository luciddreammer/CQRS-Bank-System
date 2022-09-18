using CQRSBankSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CQRSBankSystem.Data.Models;
using CQRSBankSystem.Services;
using CQRSBankSystem.Data.Enums;
using System.Net;

namespace CQRSBankSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private EventService _eventService;
        private MoneyService _moneyService;

        public EventController(EventService eventService, MoneyService moneyService)
        {
            _eventService = eventService;
            _moneyService = moneyService;
        }

        [HttpPost("New-Money-Transfer")]
        public IActionResult NewEvent([FromBody]TypeOfOperationEnum typeOfOperation, double ammount, int to)
        {
            var cookie = HttpContext.Request.Cookies["Session_Id"];
            if (cookie==null)
            {
                return Unauthorized();
            }
            _eventService.NewEvent(typeOfOperation, ammount, to, cookie);
            return Ok();
        }
    }
}
