using AllBuyMyself.Models.Authentication;
using AllBuyMyself.Models.Common;
using AllBuyMyself.Services.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AllBuyMyself.Controllers.Authentication
{
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;
        public AuthenticationController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public ApiResult<bool> Register([FromBody] RegisterReq req)
        {
            bool isSuccess = _authenticationService.Register(req);
            return new(isSuccess);
        }

        [HttpPost]
        public ApiResult<bool> Login([FromBody] LoginReq req)
        {
            bool isSuccess = _authenticationService.Login(req);
            return new(isSuccess);
        }
    }
}
