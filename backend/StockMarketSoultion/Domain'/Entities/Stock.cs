using Domain_.Common;

namespace Domain_.Entities
{
    public class Stock : Entity
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        private Stock() { } 

        public Stock(int id,string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public void UpdatePrice(decimal newPrice)
        {
            Price = newPrice;
        }
    }
}
