using CQRSBankSystem.Data.DBContext;
using CQRSBankSystem.Data.Models;
using CQRSBankSystem.Data.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace CQRSBankSystem.Services
{
    public class LoginService
    {
        private CQRSBankSystemContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService(CQRSBankSystemContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public void LoginUser(string login, string password)
        {
            if(LoginVerification(login,password)!=true)
            {
                return;
            }
            CreateCookie(_context.Users.FirstOrDefault(l => l.Login == login));

        }
        
        public void LogoutUser()
        {
            var cookie_Id = _httpContextAccessor.HttpContext.Request.Cookies["Session_Id"].ToString();
            if(cookie_Id != null)
            {
                try
                {
                    var currentUser = _context.Users.FirstOrDefault(l => l.SessionId == double.Parse(cookie_Id));
                    _httpContextAccessor.HttpContext.Response.Cookies.Delete("Session_Id");
                    if (currentUser != null)
                    {
                        currentUser.SessionId = 0;
                        _context.Update(currentUser);
                        _context.SaveChanges();
                    }
                }
                catch
                {
                    _httpContextAccessor.HttpContext.Response.Cookies.Delete("Session_Id");
                }
            }
        }

        public void CreateCookie(User user)
        {
            var rnd = new Random();
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Secure = true;
            cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
            double randomNumber;
            do
            {
                randomNumber = rnd.Next(10, 100000000);
            } while (_context.Users.FirstOrDefault(id=>id.SessionId==randomNumber) != null);
            user.SessionId = randomNumber;
            _context.Users.Update(user);
            _context.SaveChanges();
            _httpContextAccessor.HttpContext.Response.Cookies.Append("Session_Id", randomNumber.ToString(), cookieOptions);
        }

        public bool LoginVerification(string login, string password)
        {
            var user = _context.Users.FirstOrDefault(l => l.Login == login);
            if(user==null)
            {
                return false;
            }    
            if(user.Password!=password)
            {
                return false;
            }
            return true;
        }
    }
}
