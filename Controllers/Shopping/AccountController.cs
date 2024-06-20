using AllBuyMyself.Models.Common;
using AllBuyMyself.Models.Shopping.MyAccount;
using AllBuyMyself.Services.Shopping;
using Microsoft.AspNetCore.Mvc;

namespace AllBuyMyself.Controllers.Shopping
{
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public ApiResult<GetAccountResp> GetAccount(string username)
        {
            GetAccountResp resp = _accountService.GetAccount(username);
            return new(resp);
        }

        [HttpPut]
        public ApiResult<bool> ModifyAccount([FromBody] ModifyAccountReq req)
        {
            bool isSuccess = _accountService.ModifyAccount(req);
            return new(isSuccess);
        }
    }
}
