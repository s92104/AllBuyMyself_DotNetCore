namespace AllBuyMyself.Models.Shopping.SaveList
{
    public class GetSavesResp
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; } = 0;
        public string? Image_path { get; set; } = string.Empty;
    }
}
