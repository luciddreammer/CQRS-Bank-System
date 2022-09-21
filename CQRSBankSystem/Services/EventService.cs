using CQRSBankSystem.Data.Dictionaires;
using CQRSBankSystem.Data.Enums;
using CQRSBankSystem.Data.Models;
using CQRSBankSystem.Repositories;

namespace CQRSBankSystem.Services
{
    public class EventService
    {
        private IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }   

        public void NewEvent(TypeOfOperationEnum typeOfOperation, double ammount, int to,string cookie)
        {
            Event newEvent = _eventRepository.AddEvent(typeOfOperation, ammount, to, cookie);
            if(newEvent == null)
            {
                return;
            }
            string result = _eventRepository.DataVerification(newEvent);
            if(result != StatusDictionary.Reasons["FirstVerificationPassed"])
            {
                _eventRepository.CancelEvent(newEvent, result);
                return;
            }
            _eventRepository.ConfirmEvent(newEvent);
        }
    }
}
