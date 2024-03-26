using BuilderDesignPatternTests.Data.Builders.Contracts;
using RepositoryDesignPatternTests.Data.Factories;
using RepositoryDesignPatternTests.Models;

namespace BuilderDesignPatternTests.Data.Builders;
public class TransientInvoiceBuilder : IInvoiceBuilder
{
    private Invoice _invoice = new Invoice();

    public IInvoiceBuilder WithDefaultConfiguration()
    {
        _invoice = InvoiceFactory.GenerateInvoice();
        return this;
    }

    public IInvoiceBuilder WithInvoiceId(long invoiceId)
    {
        _invoice.InvoiceId = invoiceId;
        return this;
    }

    public IInvoiceBuilder ForCustomer(Customer customer)
    {
        _invoice.Customer = customer;
        _invoice.CustomerId = _invoice.Customer.CustomerId;
        return this;
    }

    public IInvoiceBuilder WithBillingAddress(string address, string city, string state, string postalCode, string country)
    {
        _invoice.BillingAddress = address;
        _invoice.BillingCity = city;
        _invoice.BillingState = state;
        _invoice.BillingPostalCode = postalCode;
        _invoice.BillingCountry = country;
        return this;
    }

    public IInvoiceBuilder WithInvoiceDate(string invoiceDate)
    {
        _invoice.InvoiceDate = invoiceDate;
        return this;
    }

    public IInvoiceBuilder AddInvoiceItem(InvoiceItem invoiceItem)
    {
        _invoice.InvoiceItems.Add(invoiceItem);
        return this;
    }

    public IInvoiceBuilder WithInvoiceItems(IEnumerable<InvoiceItem> invoiceItems)
    {
        _invoice.InvoiceItems = invoiceItems.ToHashSet();
        return this;
    }

    public Invoice Build()
    {
        return _invoice;
    }
}
