using CQRSBankSystem.Data.DBContext;
using CQRSBankSystem.Data.Enums;
using CQRSBankSystem.Data.Models;
using CQRSBankSystem.Repositories;

namespace CQRSBankSystem.Services
{
    public class EventService
    {
        private IEventRepository _eventRepository;
        private MoneyService _moneyService;

        public EventService(IEventRepository eventRepository, IMoneyRepository moneyrepo)
        {
            _eventRepository = eventRepository;
            _moneyService = new MoneyService(moneyrepo);
        }   

        public void NewEvent(TypeOfOperationEnum typeOfOperation, double ammount, int to,string cookie)
        {
            //observer pattern??
            _moneyService.NewMoneyTransfer();
            Event newEvent = _eventRepository.AddEvent(typeOfOperation, ammount, to, cookie);
            string result = _eventRepository.DataVerification(newEvent);
            if(result != "FirstVerificationPassed")
            {
                _eventRepository.CancelEvent(newEvent, result);
                return;
            }
            _eventRepository.ConfirmEvent(newEvent);
        }
    }
}
