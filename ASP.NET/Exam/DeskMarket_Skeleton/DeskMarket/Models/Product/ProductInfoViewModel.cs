namespace DeskMarket.Models.Product
{
    public class ProductInfoViewModel
    {
        public int Id {  get; set; }
        public required string ProductName { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsSeller {  get; set; }
        public bool HasBought {  get; set; }
    }
}
