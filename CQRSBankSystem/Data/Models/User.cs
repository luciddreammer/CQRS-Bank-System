namespace CQRSBankSystem.Data.Models
{
    public class User
    {
        public int Id { get; set; }
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
