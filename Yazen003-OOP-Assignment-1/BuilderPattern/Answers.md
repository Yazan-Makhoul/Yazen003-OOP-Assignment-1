Q1-) Answer :
Extreme Risk of Silent Parameter-Swapping: 
When multiple parameters share the same data type—such as strings (BillingStreet vs. ShippingStreet) or decimals (SubTotal, DiscountAmount, TaxAmount)—swapping two adjacent arguments compiles without errors or warnings.

Fragility to Evolution & Breaking Changes:
The day a 21st property is added (even an optional one), every existing constructor call breaks unless overloads are introduced.

Call-Site Readability & Noise


Q2-) Single responsibility — what does each small builder own, and only own?

Answer:

AddressBuilder
Owns: Physical/mailing location data and its immediate domain rules.

OrderBuilder
Owns: Order execution metadata, timeframes, and financial balances.

InvoiceBuilder
Owns: Top-level record orchestration and customer identity.


Q3-) Independent validation — can AddressBuilder guarantee a complete address on its own, without the
parent object knowing anything about street/city/zip rules?

Answer : Yes, AddressBuilder can—and should—guarantee a complete, valid address entirely on its own.

The parent object (InvoiceBuilder) remains completely ignorant of street, city, or postal code rules because validation is enforced inside AddressBuilder at the boundary where the Address object is constructed.



Q4-) Reuse — the exact same AddressBuilder is used for both billing and shipping. What would you have had
to duplicate without it?

Answer : builder must duplicate every address field, setter method, and validation check for both billing and shipping locations.

Q5-)Readability at the call site — compare constructing the object with Task 3.2's single builder versus this
composed version

Answer : AddressBuilder: Owns physical location data and postal invariants (Street, City, State, ZipCode, Country). It validates address completeness independently and knows nothing about customers, orders, or tax math.

OrderBuilder: Owns order execution and financial balance calculations (SubTotal, TaxAmount, DiscountAmount, Currency, DueDate, PaymentMethod, IsPaid). It handles ledger validation (such as non-negative amounts) and knows nothing about recipient addresses.

InvoiceBuilder: Owns top-level record orchestration and customer identity (InvoiceId, InvoiceNumber, CustomerName, CustomerEmail, CustomerPhone). It binds together customer info, valid Address objects, and OrderInfo without doing any low-level field validation itself.