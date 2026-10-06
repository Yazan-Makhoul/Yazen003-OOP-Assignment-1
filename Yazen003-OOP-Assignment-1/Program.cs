using Yazen003_OOP_Assignment_1.ConvertToC_;

namespace Yazen003_OOP_Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderSystem storage = new OrderSystem();

            Customer mona = new Customer(1 , "Mona Ali", "mona@example.com", "Cairo", isVip: true);
            Product usb = new Product(101, "USB Cable", 50.0, stock: 100);
            Product mouse = new Product(102, "Wireless Mouse", 250.0, stock: 40);

            storage.Customers.Add(mona);
            storage.Products.Add(usb);
            storage.Products.Add(mouse);

            Order order = new Order(1001, mona, "2026-10-06");
            storage.Orders.Add(order);

            try
            {
                order.AddLine(usb, 2);    
                order.AddLine(mouse, 1);  
                order.MarkPaid();         
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Business Rule Error: {ex.Message}");
            }

            
            order.PrintDetails();

            Console.WriteLine($"\nUpdated USB Stock: {usb.Stock}"); 
            Console.WriteLine($"Order Total Calculated: {order.CalculateTotal()}");
        }

    }
}
