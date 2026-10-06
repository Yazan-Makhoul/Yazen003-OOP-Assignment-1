using System;
using System.Collections.Generic;
using System.Text;

namespace Yazen003_OOP_Assignment_1.ConvertToC_
{
    public class Order
    {
        public int Id { get; }
        public Customer Customer { get; }
        public string Date { get; }
        public bool IsPaid { get; private set; }
        private readonly List<OrderLine> _lines = new();
        public IReadOnlyList<OrderLine> Lines => _lines;

        public Order(int id, Customer customer, string date)
        {
            Id = id;
            Customer = customer;
            Date = date;
            IsPaid = false;
        }

        public void AddLine(Product product, int quantity)
        {
            if (IsPaid)
                throw new InvalidOperationException("Cannot modify a paid order.");

            _lines.Add(new OrderLine(product, quantity));
        }

        public void MarkPaid()
        {
            if (_lines.Count == 0)
                throw new InvalidOperationException("Cannot pay an empty order.");

            IsPaid = true;
        }

        public double CalculateTotal()
        {
            double total = 0.0;
            foreach (var line in _lines)
            {
                total += line.LineTotal;
            }

            if (Customer.IsVip)
            {
                total *= 0.90;
            }

            return total;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"\n=== ORDER #{Id} ===");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"Customer: {Customer.Name} (#{Customer.Id})");
            Console.WriteLine($"Paid: {(IsPaid ? "yes" : "no")}");
            Console.WriteLine("Lines:");

            foreach (var line in _lines)
            {
                Console.WriteLine($"  - {line.Product.Name}  x{line.Quantity}  @{line.Product.Price:F2}  = {line.LineTotal:F2}");
            }

            Console.WriteLine($"TOTAL: {CalculateTotal():F2}");
        }
    }
}
