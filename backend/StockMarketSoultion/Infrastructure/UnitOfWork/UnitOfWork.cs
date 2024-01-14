using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StockDbContext _context;
        private IStockRepository _stockRepository;
        private IOrderRepository _orderRepository;

        public UnitOfWork(StockDbContext context)
        {
            _context = context;
        }

        public IStockRepository StockRepository
        {
            get
            {
                return _stockRepository ??= new StockRepository(_context);
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                return _orderRepository ??= new OrderRepository(_context);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
