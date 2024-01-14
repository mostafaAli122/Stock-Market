using Infrastructure.Interfaces;
using Microsoft.AspNetCore.SignalR;
using PresentationAPI.Hubs;
using Service;

namespace PresentationAPI.Services
{
    public class StockPriceGenerator : BackgroundService
    {
        private readonly IHubContext<StockHub> _hubContext;
        private readonly IServiceProvider _services;
        private readonly Random _random;

        public StockPriceGenerator(IHubContext<StockHub> hubContext, IServiceProvider services)
        {
            _hubContext = hubContext;
            _services = services;
            _random = new Random();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _services.CreateScope())
                {
                    var StockService =
                        scope.ServiceProvider
                            .GetRequiredService<StockService>();

                    var stocks = StockService.GetStocks();
                    foreach (var stock in stocks)
                    {
                        stock.UpdatePrice(Convert.ToDecimal(_random.Next(1, 101))); // Random price between 1 and 100
                    }

                    await _hubContext.Clients.All.SendAsync("ReceiveStockPrices", stocks);

                    await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                }
            }
        }

    }
}
