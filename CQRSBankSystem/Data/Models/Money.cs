using CQRSBankSystem.Data.DBContext;
using CQRSBankSystem.Repositories;

namespace CQRSBankSystem.Data.Models
{
    public class Money
    {
        private double AccountBalance { get; set; }
        private string Currency { get; set; }
        private IMoneyRepository _moneyRepository;

        public Money( CQRSBankSystemContext context)
        {
            _moneyRepository = new MoneyRepository(context);
        }

        public Money()
        {

        }

        public Money CheckBalance(int Id)
        {
            return new Money();
        }
    }
}
