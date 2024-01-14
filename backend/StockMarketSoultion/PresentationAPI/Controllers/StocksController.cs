using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace PresentationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly StockService _stockService;

        public StockController(StockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public IActionResult GetStocks()
        {
            var stocks = _stockService.GetStocks();
            return Ok(stocks);
        }
    }
}
