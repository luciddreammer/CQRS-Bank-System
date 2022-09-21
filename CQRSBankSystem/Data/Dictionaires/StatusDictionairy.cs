namespace CQRSBankSystem.Data.Dictionaires
{
    public class StatusDictionary
    {
        public static Dictionary<string, string> Reasons = new Dictionary<string, string>()
        {
            { "NoSuchUser", "No such user" },
            { "NotEnoughMoney", "Not Enough Money" },
            { "FirstVerificationPassed", "First Verification Passed" },
        };

        public static Dictionary<string, string> Statuses = new Dictionary<string, string>()
        {
            { "New", "New" },
            { "Cancelled", "Cancelled" },
            { "Approved", "Approved" },
            { "TransferSuccessfull", "Transfer Successfull" }
        };
    }
}
