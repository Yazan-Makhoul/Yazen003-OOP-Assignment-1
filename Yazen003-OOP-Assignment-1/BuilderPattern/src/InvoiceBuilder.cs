namespace Yazen003_OOP_Assignment_1.BuilderPattern.src
{
    public class InvoiceBuilder
    {
        private string _invoiceNumber = string.Empty;
        private string _customerName = string.Empty;
        private string _customerEmail = string.Empty;
        private string _customerPhone = string.Empty;

        private Address? _billingAddress;
        private Address? _shippingAddress;

        private DateTimeOffset _orderDate = DateTimeOffset.UtcNow;
        private DateTimeOffset _dueDate = DateTimeOffset.UtcNow.AddDays(30);
        private PaymentMethod _paymentMethod = PaymentMethod.Invoice;
        private string _currency = "USD";
        private decimal _subTotal;
        private decimal _discountAmount;
        private decimal _taxAmount;
        private bool _isPaid;
        private string _notes = string.Empty;

        public static InvoiceBuilder Create() => new();

        public InvoiceBuilder WithInvoiceNumber(string invoiceNumber)
        {
            _invoiceNumber = invoiceNumber;
            return this;
        }

        public InvoiceBuilder ForCustomer(string name, string email, string phone = "")
        {
            _customerName = name;
            _customerEmail = email;
            _customerPhone = phone;
            return this;
        }

        public InvoiceBuilder WithBillingAddress(Address address)
        {
            _billingAddress = address;
            return this;
        }

        public InvoiceBuilder WithShippingAddress(Address address)
        {
            _shippingAddress = address;
            return this;
        }

        public InvoiceBuilder CopyBillingToShipping()
        {
            _shippingAddress = _billingAddress;
            return this;
        }

        public InvoiceBuilder IssuedOn(DateTimeOffset orderDate, DateTimeOffset? dueDate = null)
        {
            _orderDate = orderDate;
            _dueDate = dueDate ?? orderDate.AddDays(30);
            return this;
        }

        public InvoiceBuilder WithFinancials(decimal subTotal, decimal taxAmount = 0m, decimal discountAmount = 0m, string currency = "USD")
        {
            _subTotal = subTotal;
            _taxAmount = taxAmount;
            _discountAmount = discountAmount;
            _currency = currency;
            return this;
        }

        public InvoiceBuilder PaidWith(PaymentMethod method)
        {
            _paymentMethod = method;
            _isPaid = true;
            return this;
        }

        public InvoiceBuilder WithNotes(string notes)
        {
            _notes = notes;
            return this;
        }

        public InvoiceRecord Build()
        {
            if (string.IsNullOrWhiteSpace(_invoiceNumber))
                throw new InvalidOperationException("Cannot build InvoiceRecord: InvoiceNumber is required.");

            if (string.IsNullOrWhiteSpace(_customerName) || string.IsNullOrWhiteSpace(_customerEmail))
                throw new InvalidOperationException("Cannot build InvoiceRecord: Customer name and email are required.");

            if (_billingAddress == null)
                throw new InvalidOperationException("Cannot build InvoiceRecord: BillingAddress is required.");

            if (_shippingAddress == null)
                throw new InvalidOperationException("Cannot build InvoiceRecord: ShippingAddress is required.");

            return new InvoiceRecord
            {
                InvoiceId = Guid.NewGuid(),
                InvoiceNumber = _invoiceNumber,
                CustomerName = _customerName,
                CustomerEmail = _customerEmail,
                CustomerPhone = _customerPhone,
                BillingAddress = _billingAddress,
                ShippingAddress = _shippingAddress,
                OrderDate = _orderDate,
                DueDate = _dueDate,
                PaymentMethod = _paymentMethod,
                Currency = _currency,
                SubTotal = _subTotal,
                DiscountAmount = _discountAmount,
                TaxAmount = _taxAmount,
                IsPaid = _isPaid,
                Notes = _notes
            };
        }
    }
}
