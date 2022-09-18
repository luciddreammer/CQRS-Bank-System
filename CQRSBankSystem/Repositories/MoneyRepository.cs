using CQRSBankSystem.Data.DBContext;
using CQRSBankSystem.Data.Models;
using System.Reflection.Metadata.Ecma335;

namespace CQRSBankSystem.Repositories
{
    public class MoneyRepository : IMoneyRepository
    {
        private CQRSBankSystemContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MoneyRepository(CQRSBankSystemContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        Event IMoneyRepository.NewMoneyTransfer()
        {
            var newEvent = _context.Events.FirstOrDefault(s => s.Status == "FirstVerificationPassed");
            if(newEvent == null)
            {
                return null;
            }
            return newEvent;
        }
        bool IMoneyRepository.DoubleVerification(Event singleEvent, MoneyTransfer newMoneyTransfer)
        {
            var cookieString = double.Parse(_httpContextAccessor.HttpContext.Request.Cookies["Session_id"]);
            var user = _context.Users.FirstOrDefault(s => s.AccountNumber == singleEvent.From);
            var receiver = _context.Users.FirstOrDefault(t => t.AccountNumber == singleEvent.To);
            if(cookieString != user.SessionId)
            {
                singleEvent.Status = "cancelled";
                singleEvent.ReasonOfCancellation = "AuthorizationFailed";
                newMoneyTransfer.Status = "cancelled";
                newMoneyTransfer.ReasonOfCancellation = "AuuthorizationFailed";
                _context.MoneyTransfers.Add(newMoneyTransfer);
                _context.Update(singleEvent);
                _context.SaveChanges();
                return false;
            }
            if(user.Balance - singleEvent.Ammount<0)
            {
                singleEvent.Status = "cancelled";
                singleEvent.ReasonOfCancellation = "NotEnoughMoney";
                newMoneyTransfer.Status = "cancelled";
                newMoneyTransfer.ReasonOfCancellation = "NotEnoughMoney";
                _context.MoneyTransfers.Add(newMoneyTransfer);
                _context.Update(singleEvent);
                _context.SaveChanges();
                return false;
            }
            if(receiver == null)
            {
                singleEvent.Status = "cancelled";
                singleEvent.ReasonOfCancellation = "NoSuchUser(Receiver)";
                newMoneyTransfer.Status = "cancelled";
                newMoneyTransfer.ReasonOfCancellation = "NoSuchUser(Receiver)";
                _context.MoneyTransfers.Add(newMoneyTransfer);
                _context.Update(singleEvent);
                _context.SaveChanges();
                return false;
            }
            return true;
        }

        void IMoneyRepository.TransferMoney(Event singleEvent, MoneyTransfer newMoneyTransfer)
        {
            var sender = _context.Users.FirstOrDefault(accN => accN.AccountNumber == singleEvent.From);
            var receiver = _context.Users.FirstOrDefault(accNu => accNu.AccountNumber == singleEvent.To);
            sender.Balance -= (int)singleEvent.Ammount;
            receiver.Balance += (int)singleEvent.Ammount;
            _context.Update(sender);
            _context.Update(receiver);
            _context.SaveChanges();

        }

        void IMoneyRepository.StatusChange(Event singleEvent, MoneyTransfer newMoneyTransfer)
        {
            singleEvent.Status = "Successfully";
            newMoneyTransfer.Status = "Successfully";
            _context.Update(singleEvent);
            _context.MoneyTransfers.Add(newMoneyTransfer);
            _context.SaveChanges();
        }
    }

}
