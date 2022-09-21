using CQRSBankSystem.Data.DBContext;
using CQRSBankSystem.Data.Dictionaires;
using CQRSBankSystem.Data.Enums;
using CQRSBankSystem.Data.Models;

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
            if(_context.Users.FirstOrDefault(s => s.SessionId == double.Parse(cookie)).AccountNumber==null)
            {
                return null;
            }
            Event newEvent = new Event();
            newEvent = new Event()
            {
                TypeOfOperation = typeOfOperation,
                Ammount = ammount,
                From = _context.Users.FirstOrDefault(s => s.SessionId == double.Parse(cookie)).AccountNumber,
                To = to,
                Status = StatusDictionary.Statuses["New"],
                ReasonOfCancellation = null
            };
            _context.Events.Add(newEvent);
            _context.SaveChanges();
            return newEvent;
        }

        string IEventRepository.DataVerification(Event singleEvent)
        {
            if(_context.Users.FirstOrDefault(accNumber=>accNumber.AccountNumber == singleEvent.To)==null)
            {
                return StatusDictionary.Reasons["NoSuchUser"]; 
            }
            if(_context.Users.FirstOrDefault(acN=>acN.AccountNumber==singleEvent.From).Balance-singleEvent.Ammount<0)
            {
                return StatusDictionary.Reasons["NotEnoughMoney"]; 
            }
            return StatusDictionary.Reasons["FirstVerificationPassed"];
        }

        void IEventRepository.CancelEvent(Event singleEvent,string reason)
        {
            singleEvent.ReasonOfCancellation = reason;
            singleEvent.Status = StatusDictionary.Statuses["Cancelled"];
            _context.Update(singleEvent);
            _context.SaveChanges();
        }

        void IEventRepository.ConfirmEvent(Event singleEvent)
        {
            singleEvent.Status = StatusDictionary.Statuses["Approved"];
            _context.Update(singleEvent);
            _context.SaveChanges();
        }
    }
}
