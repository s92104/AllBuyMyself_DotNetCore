using AllBuyMyself.Models.Common;
using AllBuyMyself.Models.Shopping.SaveList;
using AllBuyMyself.Services.Shopping;
using Microsoft.AspNetCore.Mvc;

namespace AllBuyMyself.Controllers.Shopping
{
    public class SaveController
    {
        private readonly SaveService _saveService;
        public SaveController(SaveService saveService)
        {
            _saveService = saveService;
        }

        [HttpPost]
        public ApiResult<bool> ChangeSave([FromBody] ChangeSaveReq req)
        {
            bool isSuccess = _saveService.ChangeSave(req);
            return new(isSuccess);
        }

        [HttpGet]
        public ApiResult<IEnumerable<GetSavesResp>> GetSaves(string username)
        {
            IEnumerable<GetSavesResp> resp = _saveService.GetSaves(username);
            return new(resp);
        }
    }
}
