using Domain_.Entities;
using Microsoft.AspNetCore.Mvc;
using PresentationAPI.Controllers.request;
using PresentationAPI.Controllers.response;
using Service;

namespace PresentationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly StockService _stockService;

        public OrderController(OrderService orderService, StockService stockService)
        {
            _orderService = orderService;
             _stockService = stockService;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _orderService.GetOrders();
            orders.Select((x) =>
            new OrderResponse{
                Id = x.Id,
               PersonName = x.PersonName,
               Quantity = x.Quantity,
               Price = x.Price,
               StockName = x.Stock.Name
            }).ToList();
            return Ok(orders);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderRequest order)
        {
            if (order == null)
            {
                return BadRequest("Invalid order data");
            }
            var newOrder = new Order(order.StockId, order.Price, order.Quantity, order.PersonName);

            _orderService.CreateOrder(newOrder);
            var stock = this._stockService.GetStockById(order.StockId);

            var res = new OrderResponse
            {
                Id = newOrder.Id,
                PersonName = newOrder.PersonName,
                Price = newOrder.Price,
                Quantity = newOrder.Quantity,
                StockName = stock.Name
            };

            return CreatedAtAction(nameof(GetOrders), res);
        }
    }
}
