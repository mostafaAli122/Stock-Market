using Domain_.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_.Entities
{
    public class Order : Entity
    {
        [ForeignKey("Stock")]
        public int StockId { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public string PersonName { get; private set; }
        public Stock Stock { get; set; }
        private Order() { } 

        public Order(int stockID, decimal price, int quantity, string personName)
        {
            StockId = stockID;
            Price = price;
            Quantity = quantity;
            PersonName = personName;
        }
    }
}
