using CQRSBankSystem.Data;
using CQRSBankSystem.Data.Models;
using Microsoft.Extensions.Logging;

namespace CQRSBankSystem.Repositories
{
    public interface IMoneyRepository
    {
        Event NewMoneyTransfer();
        bool DoubleVerification(Event singleEvent, MoneyTransfer newMoneyTransfer);
        void TransferMoney(Event singleEvent, MoneyTransfer newMoneyTransfer);
        void StatusChange(Event singleEvent, MoneyTransfer newMoneyTransfer);
    }
}
