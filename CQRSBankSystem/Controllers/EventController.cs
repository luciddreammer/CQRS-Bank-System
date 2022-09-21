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

        public EventController(EventService eventService)
        {
            _eventService = eventService;
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
