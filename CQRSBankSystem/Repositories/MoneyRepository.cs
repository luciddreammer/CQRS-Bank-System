using CQRSBankSystem.Data.DBContext;
using CQRSBankSystem.Data.Dictionaires;
using CQRSBankSystem.Data.Models;
using System.Reflection.Metadata.Ecma335;

namespace CQRSBankSystem.Repositories
{
    public class MoneyRepository : IMoneyRepository
    {
        private CQRSBankSystemContext _context;

        public MoneyRepository(CQRSBankSystemContext context)
        {
            _context = context;
        }

        Event IMoneyRepository.NewMoneyTransfer(Event newEvent)
        {
            if(newEvent == null)
            {
                return null;
            }
            return newEvent;
        }
        bool IMoneyRepository.DoubleVerification(Event singleEvent, MoneyTransfer newMoneyTransfer)
        {
            var user = _context.Users.FirstOrDefault(s => s.AccountNumber == singleEvent.From);
            var receiver = _context.Users.FirstOrDefault(t => t.AccountNumber == singleEvent.To);
            if(user.Balance - singleEvent.Ammount<0)
            {
                singleEvent.Status = StatusDictionary.Statuses["Cancelled"];
                singleEvent.ReasonOfCancellation = StatusDictionary.Reasons["NotEnoughMoney"];
                newMoneyTransfer.Status = StatusDictionary.Statuses["Cancelled"];
                newMoneyTransfer.ReasonOfCancellation = StatusDictionary.Reasons["NotEnoughMoney"];
                _context.MoneyTransfers.Add(newMoneyTransfer);
                _context.Update(singleEvent);
                _context.SaveChanges();
                return false;
            }
            if(receiver == null)
            {
                singleEvent.Status = StatusDictionary.Statuses["Cancelled"];
                singleEvent.ReasonOfCancellation = StatusDictionary.Statuses["NoSuchUser"];
                newMoneyTransfer.Status = StatusDictionary.Statuses["Cancelled"];
                newMoneyTransfer.ReasonOfCancellation = StatusDictionary.Statuses["NoSuchUser"];
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
            singleEvent.Status = StatusDictionary.Statuses["TransferSuccessfull"];
            newMoneyTransfer.Status = StatusDictionary.Statuses["TransferSuccessfull"];
            _context.Update(singleEvent);
            _context.MoneyTransfers.Add(newMoneyTransfer);
            _context.SaveChanges();
        }
    }

}
