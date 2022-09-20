using CQRSBankSystem.Data.DBContext;
using CQRSBankSystem.Data.Models;
using CQRSBankSystem.Repositories;

namespace CQRSBankSystem.Services
{
    public class MoneyService
    {

        private IMoneyRepository _moneyRepository;

        public MoneyService(IMoneyRepository repository)
        {
            _moneyRepository = repository;  
        }

        public MoneyService()
        {

        }

        public void NewMoneyTransfer(Event newData)
        {
            var newEvent = _moneyRepository.NewMoneyTransfer(newData);
            var newMoneyTransfer = EventToTranfer(newEvent);
            if (newEvent==null)
            {
                return;
            }
            if (_moneyRepository.DoubleVerification(newEvent, newMoneyTransfer) == false)
            {
                return;
            }
            _moneyRepository.TransferMoney(newEvent,newMoneyTransfer);
            _moneyRepository.StatusChange(newEvent, newMoneyTransfer);
        }

        private MoneyTransfer EventToTranfer(Event newEvent)
        {
            MoneyTransfer newMoneyTransfer = new MoneyTransfer()
            {
                From = (int)newEvent.From,
                To = (int)newEvent.To,
                Ammount = (int)newEvent.Ammount,
            };
            return newMoneyTransfer;
        }

    }
}
