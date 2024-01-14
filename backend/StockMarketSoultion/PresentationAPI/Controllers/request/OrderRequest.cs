namespace PresentationAPI.Controllers.request
{
    public class OrderRequest
    {
        public int StockId { get; set; }
        public string PersonName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
     }
}
