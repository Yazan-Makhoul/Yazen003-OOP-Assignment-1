using System;
using System.Collections.Generic;
using System.Text;

namespace Yazen003_OOP_Assignment_1.ConvertToC_
{
    public class OrderSystem
    {
        public List<Customer> Customers { get; } = new();
        public List<Product> Products { get; } = new();
        public List<Order> Orders { get; } = new();

        public Customer? FindCustomerById(int id) => Customers.FirstOrDefault(c => c.Id == id);
        public Product? FindProductById(int id) => Products.FirstOrDefault(p => p.Id == id);
        public Order? FindOrderById(int id) => Orders.FirstOrDefault(o => o.Id == id);
    }
}