namespace CQRSBankSystem.Data.ViewModels
{
    public class UserVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int AccountNumber { get; set; }
        public double Balance { get; set; }
        public double SessionId { get; set; }
    }
}
