using Domain_.Entities;
using Microsoft.AspNetCore.SignalR;

namespace PresentationAPI.Hubs
{
    public class StockHub : Hub
    {
        public async Task SendStockPrices(List<Stock> stocks)
        {
            await Clients.All.SendAsync("ReceiveStockPrices", stocks);
        }
    }
}
