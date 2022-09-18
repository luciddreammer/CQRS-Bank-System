using CQRSBankSystem.Data.DBContext;
using CQRSBankSystem.Data.Enums;
using CQRSBankSystem.Repositories;

namespace CQRSBankSystem.Data.Models
{
    public class MoneyTransfer
    {
        public int Id { get; set; }
        public double? Ammount { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string Status { get; set; }
        public string? ReasonOfCancellation { get; set; }

    }
}
