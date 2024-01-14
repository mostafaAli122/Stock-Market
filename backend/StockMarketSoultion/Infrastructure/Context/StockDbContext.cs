using Domain_.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class StockDbContext : DbContext
    {
       public StockDbContext(DbContextOptions<StockDbContext> options) : base(options) { }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed default stock data
           modelBuilder.Entity<Stock>().HasData(LoadStocks());
        }
        private ICollection<Stock> LoadStocks()
        {
            return new List<Stock>() {
             new Stock(1, "Vianet", 50),
                new Stock(2, "Agritek", 12),
                new Stock(3, "Akamai", 45),
                new Stock(4, "Baidu", 35),
                new Stock(5, "Blinkx", 78),
                new Stock(6, "Blucora", 94),
                new Stock(7, "Boingo", 10),
                new Stock(8, "Brainybrawn", 85),
                new Stock(9, "Carbonite", 10),
                new Stock(10, "China Finance", 2),
                new Stock(11, "ChinaCache", 89),
                new Stock(12, "ADR", 100),
                new Stock(13, "ChitrChatr", 99),
                new Stock(14, "Cnova", 12),
                new Stock(15, "Cogent", 61),
                new Stock(16, "Crexendo", 21),
                new Stock(17, "CrowdGather", 23),
                new Stock(18, "EarthLink", 18),
                new Stock(19, "Eastern", 19),
                new Stock(20, "ENDEXX", 74),
                new Stock(21, "Envestnet", 7),
                new Stock(22, "Epazz", 5),
                new Stock(23, "Vianet", 16),
                new Stock(24, "FlashZero", 35),
                new Stock(25, "Genesis", 98),
                new Stock(26, "InterNAP", 67),
                new Stock(27, "MeetMe", 80),
                new Stock(28, "MeetMe", 90),
                new Stock(29, "Qihoo", 29)
            // Add more default stocks as needed
            };

               
            
        }
    }
}
