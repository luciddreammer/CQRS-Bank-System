using CQRSBankSystem.Data.DBContext;
using CQRSBankSystem.Data.Models;

namespace CQRSBankSystem.Repositories
{
    public class MoneyRepository : IMoneyRepository
    {
        private CQRSBankSystemContext _context;

        public MoneyRepository(CQRSBankSystemContext context)
        {
            _context = context; 
        }

        bool IMoneyRepository.DoubleVerification(Event singleEvent)
        {
            return false;
        }

        void IMoneyRepository.TransferMoney(Event singleEvent)
        {

        }

        bool IMoneyRepository.BalanceCheck(Event singleEvent)
        {
            return false;
        }

        void IMoneyRepository.StatusChange(Event singleEvent)
        {

        }
    }

}
