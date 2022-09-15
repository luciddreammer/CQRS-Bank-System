using CQRSBankSystem.Data.DBContext;
using CQRSBankSystem.Data.Models;
using CQRSBankSystem.Data.ViewModels;

namespace CQRSBankSystem.Services
{
    public class RegistrationService
    {
        private CQRSBankSystemContext _context;

        public RegistrationService(CQRSBankSystemContext context)
        {
            _context = context;
        }

        public void RegisterNewuser(UserVM userVm)
        {
            var newUser = new User()
            {
                FirstName = userVm.FirstName,
                LastName = userVm.LastName,
                City = userVm.City,
                Street = userVm.Street,
                PostalCode = userVm.PostalCode,
                Login = userVm.Login,
                Password = userVm.Password,
                AccountNumber = userVm.AccountNumber,
                Balance = 0
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
