using AllBuyMyself.Models.Common.Table;
using AllBuyMyself.Models.Shopping.MyAccount;

namespace AllBuyMyself.Services.Shopping
{
    public class AccountService
    {
        private readonly AllBuyMyselfDbContext _context;
        public AccountService(AllBuyMyselfDbContext context)
        {
            _context = context;
        }

        public GetAccountResp GetAccount(string username)
        {
            Account account = _context.Accounts
                .Where(x => x.Username == username)
                .First();

            GetAccountResp resp = new(account);

            return resp;
        }

        public bool ModifyAccount(ModifyAccountReq req)
        {
            Account account = _context.Accounts
                .Where(x => x.Username == req.Username)
                .First();

            account.Password = req.Password;
            account.Cellphone = req.Cellphone;
            account.Email = req.Email;
            account.Address = req.Address;

            _context.SaveChanges();

            return true;
        }
    }
}
