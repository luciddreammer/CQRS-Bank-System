namespace CQRSBankSystem.Data.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string TypeOfOperation { get; set; }
        public double Ammount { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public string Status { get; set; }
        public string ReasonOfCancellation { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
