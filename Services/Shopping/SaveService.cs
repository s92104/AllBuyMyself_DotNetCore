using AllBuyMyself.Models.Common.Table;
using AllBuyMyself.Models.Shopping.SaveList;

namespace AllBuyMyself.Services.Shopping
{
    public class SaveService
    {
        private readonly AllBuyMyselfDbContext _context;
        public SaveService(AllBuyMyselfDbContext context)
        {
            _context = context;
        }

        public bool ChangeSave(ChangeSaveReq req)
        {
            Save? save = _context.Saves
                .Where(x => x.Username == req.Username && x.ProductId == req.ProductId)
                .FirstOrDefault();

            if(save is not null)
            {
                _context.Saves.Remove(save);
            }
            else
            {
                Save newSave = new()
                {
                    Username = req.Username,
                    ProductId = req.ProductId,
                };

                _context.Saves.Add(newSave);
            }

            _context.SaveChanges();

            return true;
        }

        public IEnumerable<GetSavesResp> GetSaves(string username)
        {
            List<GetSavesResp> resp = _context.Saves
                .Where(x => x.Username == username)
                .Join(_context.Products, save => save.ProductId, product => product.Id, (save, product) => new GetSavesResp
                {
                    Id = save.ProductId,
                    Name = product.Name,
                    Price = product.Price,
                    Image_path = product.Image_path,
                })
                .ToList();

            return resp;
        }
    }
}
