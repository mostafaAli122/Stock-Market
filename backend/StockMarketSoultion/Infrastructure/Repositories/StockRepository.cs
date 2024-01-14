using Domain_.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(StockDbContext context) : base(context) { }

        public IEnumerable<Stock> GetAllStocks()
        {
            return GetAll();
        }

        public Stock GetStockById(int id)
        {
            return GetById(id);
        }
    }

}
