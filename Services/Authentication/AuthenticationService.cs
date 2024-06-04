using AllBuyMyself.Models.Authentication;
using AllBuyMyself.Models.Common.Table;

namespace AllBuyMyself.Services.Authentication
{
    public class AuthenticationService
    {
        private readonly AllBuyMyselfDbContext _context;
        public AuthenticationService(AllBuyMyselfDbContext context)
        {
            _context = context;
        }

        public bool Register(RegisterReq req)
        {
            bool isExist = CheckAccountExist(req.Username);
            if(isExist)
            {
                return false;
            }

            Account account = new Account
            {
                Username = req.Username,
                Password = req.Password,
            };

            _context.Accounts.Add(account);
            _context.SaveChanges();

            return true;
        }

        public bool CheckAccountExist(string username)
        {
            bool isExist = _context.Accounts.Any(x => x.Username == username);
            return isExist;
        }

        public bool Login(LoginReq req)
        {
            bool isCorrect = _context.Accounts.Any(x => x.Username == req.Username && x.Password == req.Password);
            return isCorrect;
        }
    }
}
