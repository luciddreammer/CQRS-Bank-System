namespace CQRSBankSystem.Data.ViewModels
{
    public class EventsVM
    {
        public string TypeOfOperation { get; set; }
        public double Ammount { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string Status { get; set; }
        public string ReasonOfCancellation { get; set; }
    }
}
