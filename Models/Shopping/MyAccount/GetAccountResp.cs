using AllBuyMyself.Models.Common.Table;

namespace AllBuyMyself.Models.Shopping.MyAccount
{
    public class GetAccountResp
    {
        public string Password { get; set; } = string.Empty;
        public string? Cellphone { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? Address { get; set; } = null;

        public GetAccountResp(Account account)
        {
            Password = account.Password;
            Cellphone = account.Cellphone;
            Email = account.Email;
            Address = account.Address;
        }
    }
}
