namespace CQRSBankSystem.Data.ViewModels
{
    public class EventsVM
    {
        public int Id { get; set; }
        public string TypeOfOperation { get; set; }
        public double Ammount { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public string Status { get; set; }
        public string ReasonOfCancellation { get; set; }
    }
}
