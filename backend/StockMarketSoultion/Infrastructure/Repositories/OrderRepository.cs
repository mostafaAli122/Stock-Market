using Domain_.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public StockDbContext Context { get; }

        public OrderRepository(StockDbContext context) : base(context)
        {
            Context = context;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return Context.Orders.Include(x => x.Stock).ToList();
        }
        public void AddOrder(Order order)
        {
            Add(order);
        }
    }
}
