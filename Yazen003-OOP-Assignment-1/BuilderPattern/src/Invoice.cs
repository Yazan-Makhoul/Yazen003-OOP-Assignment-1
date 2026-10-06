namespace Yazen003_OOP_Assignment_1.BuilderPattern.src
{
    public record Address(
        string Street,
        string City,
        string State,
        string ZipCode,
        string Country
    );

  
    public enum PaymentMethod
    {
        CreditCard,
        BankTransfer,
        PayPal,
        Crypto,
        Invoice
    }

    
    public class InvoiceRecord
    {
        public Guid InvoiceId { get; init; } = Guid.NewGuid();
        public string CustomerName { get; init; } = string.Empty;
        public string CustomerEmail { get; init; } = string.Empty;
        public string CustomerPhone { get; init; } = string.Empty;
        public DateTimeOffset OrderDate { get; init; } = DateTimeOffset.UtcNow;

       
        public Address BillingAddress { get; init; } = null!;
        public Address ShippingAddress { get; init; } = null!;

        public PaymentMethod PaymentMethod { get; init; }
        public string Currency { get; init; } = "USD";
        public decimal SubTotal { get; init; }
        public decimal DiscountAmount { get; init; }
        public decimal TaxAmount { get; init; }

        public decimal TotalAmount => Math.Max(0, SubTotal - DiscountAmount + TaxAmount);

        public string InvoiceNumber { get; init; } = string.Empty;
        public DateTimeOffset DueDate { get; init; }
        public bool IsPaid { get; init; }
        public string Notes { get; init; } = string.Empty;
    }
}
