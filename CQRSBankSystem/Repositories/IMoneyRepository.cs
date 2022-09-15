using CQRSBankSystem.Data;
using CQRSBankSystem.Data.Models;
using Microsoft.Extensions.Logging;

namespace CQRSBankSystem.Repositories
{
    public interface IMoneyRepository
    {
        bool DoubleVerification(Event singleEvent);
        void TransferMoney(Event singleEvent);
        bool BalanceCheck(Event singleEvent);
        void StatusChange(Event singleEvent);
    }
}
