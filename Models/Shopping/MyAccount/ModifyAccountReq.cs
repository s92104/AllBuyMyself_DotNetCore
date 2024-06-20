namespace AllBuyMyself.Models.Shopping.MyAccount
{
    public class ModifyAccountReq
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Cellphone { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? Address { get; set; } = null;
    }
}
