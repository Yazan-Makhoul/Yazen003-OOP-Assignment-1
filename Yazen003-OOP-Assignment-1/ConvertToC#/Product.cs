namespace Yazen003_OOP_Assignment_1.ConvertToC_
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; }
        public double Price { get; private set; }
        public int Stock { get; private set; }

        public Product(int id, string name, double price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public void DeductStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be positive.");

            if (Stock < quantity)
                throw new InvalidOperationException("Not enough stock.");

            Stock -= quantity;
        }

        public void UpdatePrice(double newPrice)
        {
            if (newPrice < 0)
                throw new ArgumentException("Price cannot be negative.", nameof(newPrice));

            Price = newPrice;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"{Id}  {Name}  price={Price}  stock={Stock}");
        }
    }
}
  
