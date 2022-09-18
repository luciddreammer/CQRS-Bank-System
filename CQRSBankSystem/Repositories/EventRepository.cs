using CQRSBankSystem.Data.DBContext;
using CQRSBankSystem.Data.Enums;
using CQRSBankSystem.Data.Models;
using CQRSBankSystem.Data.ViewModels;
using System.Net;

namespace CQRSBankSystem.Repositories
{
    public class EventRepository : IEventRepository
    {
        private CQRSBankSystemContext _context;

        public EventRepository(CQRSBankSystemContext context)
        {
            _context = context;
        }

        Event IEventRepository.AddEvent(TypeOfOperationEnum typeOfOperation, double ammount, int to, string cookie)
        {
            Event newEvent = new Event();
            newEvent = new Event()
            {
                TypeOfOperation = typeOfOperation,
                Ammount = ammount,
                From = _context.Users.FirstOrDefault(s => s.SessionId == double.Parse(cookie)).AccountNumber,
                To = to,
                Status = "new",
                ReasonOfCancellation = null
            };
            _context.Events.Add(newEvent);
            _context.SaveChanges();
            return newEvent;
        }

        string IEventRepository.DataVerification(Event singleEvent)
        {
            string result;
            if(_context.Users.FirstOrDefault(accNumber=>accNumber.AccountNumber == singleEvent.To)==null)
            {
                result = "No such user";
                return result;
            }
            if(_context.Users.FirstOrDefault(acN=>acN.AccountNumber==singleEvent.To).Balance-singleEvent.Ammount<0)
            {
                result = "Not enough money";
                return result;
            }
            result = "FirstVerificationPassed";
            return result;
        }

        void IEventRepository.CancelEvent(Event singleEvent,string reason)
        {
            singleEvent.ReasonOfCancellation = reason;
            singleEvent.Status = "cancelled";
            _context.Update(singleEvent);
            _context.SaveChanges();
        }

        void IEventRepository.ConfirmEvent(Event singleEvent)
        {
            singleEvent.Status = "FirstVerificationPassed";
            _context.Update(singleEvent);
            _context.SaveChanges();
        }
    }
}
