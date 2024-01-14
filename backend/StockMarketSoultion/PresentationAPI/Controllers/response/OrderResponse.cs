namespace PresentationAPI.Controllers.response
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string StockName{ get; set; }
        public string PersonName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
