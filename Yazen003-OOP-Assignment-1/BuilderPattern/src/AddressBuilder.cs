using System;
using System.Collections.Generic;
using System.Text;

namespace Yazen003_OOP_Assignment_1.BuilderPattern.src
{
    public class AddressBuilder
    {
        private string _street = string.Empty;
        private string _city = string.Empty;
        private string _state = string.Empty;
        private string _zipCode = string.Empty;
        private string _country = "USA";

        public static AddressBuilder Create() => new();

        public AddressBuilder WithStreet(string street)
        {
            _street = street;
            return this;
        }

        public AddressBuilder WithCityStateZip(string city, string state, string zipCode)
        {
            _city = city;
            _state = state;
            _zipCode = zipCode;
            return this;
        }

        public AddressBuilder WithCountry(string country)
        {
            _country = country;
            return this;
        }

        public Address Build()
        {
            if (string.IsNullOrWhiteSpace(_street))
                throw new InvalidOperationException("Address street is required.");
            if (string.IsNullOrWhiteSpace(_city))
                throw new InvalidOperationException("Address city is required.");
            if (string.IsNullOrWhiteSpace(_zipCode))
                throw new InvalidOperationException("Address zip code is required.");

            return new Address(_street, _city, _state, _zipCode, _country);
        }
    }

    public class OrderInfo
    {
        public DateTimeOffset OrderDate { get; init; }
        public DateTimeOffset DueDate { get; init; }
        public PaymentMethod PaymentMethod { get; init; }
        public string Currency { get; init; } = "USD";
        public decimal SubTotal { get; init; }
        public decimal DiscountAmount { get; init; }
        public decimal TaxAmount { get; init; }
        public bool IsPaid { get; init; }
        public string Notes { get; init; } = string.Empty;
    }

    public class OrderBuilder
    {
        private DateTimeOffset _orderDate = DateTimeOffset.UtcNow;
        private DateTimeOffset _dueDate = DateTimeOffset.UtcNow.AddDays(30);
        private PaymentMethod _paymentMethod = PaymentMethod.Invoice;
        private string _currency = "USD";
        private decimal _subTotal;
        private decimal _discountAmount;
        private decimal _taxAmount;
        private bool _isPaid;
        private string _notes = string.Empty;

        public static OrderBuilder Create() => new();

        public OrderBuilder IssuedOn(DateTimeOffset orderDate, DateTimeOffset? dueDate = null)
        {
            _orderDate = orderDate;
            _dueDate = dueDate ?? orderDate.AddDays(30);
            return this;
        }

        public OrderBuilder WithFinancials(decimal subTotal, decimal taxAmount = 0m, decimal discountAmount = 0m, string currency = "USD")
        {
            if (subTotal < 0)
                throw new ArgumentOutOfRangeException(nameof(subTotal), "SubTotal cannot be negative.");

            _subTotal = subTotal;
            _taxAmount = taxAmount;
            _discountAmount = discountAmount;
            _currency = currency;
            return this;
        }

        public OrderBuilder PaidWith(PaymentMethod method)
        {
            _paymentMethod = method;
            _isPaid = true;
            return this;
        }

        public OrderBuilder WithNotes(string notes)
        {
            _notes = notes ?? string.Empty;
            return this;
        }

        public OrderInfo Build() => new()
        {
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
