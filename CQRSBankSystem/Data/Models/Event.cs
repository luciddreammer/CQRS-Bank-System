using CQRSBankSystem.Data.Enums;

namespace CQRSBankSystem.Data.Models
{
    public class Event
    {
        public int Id { get; set; }
        public TypeOfOperationEnum TypeOfOperation { get; set; }
        public double? Ammount { get; set; }
        public int? From { get; set; }
        public int? To { get; set; }
        public string Status { get; set; }
        public string? ReasonOfCancellation { get; set; }
    }
}
