using System;
using System.Collections.Generic;
using System.Text;

namespace Yazen003_OOP_Assignment_1.ConvertToC_
{
    public class OrderLine
    {
        public Product Product { get; }
        public int Quantity { get; }

        public OrderLine(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public double LineTotal => Product.Price * Quantity;
    }
}
