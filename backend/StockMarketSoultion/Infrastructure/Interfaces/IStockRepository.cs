using Domain_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IStockRepository : IRepository<Stock>
    {
        IEnumerable<Stock> GetAllStocks();
        Stock GetStockById(int id);
    }
}
