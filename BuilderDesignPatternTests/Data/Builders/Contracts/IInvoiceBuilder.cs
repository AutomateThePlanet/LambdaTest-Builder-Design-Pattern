using RepositoryDesignPatternTests.Models;

namespace BuilderDesignPatternTests.Data.Builders.Contracts;
public interface IInvoiceBuilder : IBuilder<IInvoiceBuilder, Invoice>
{
    IInvoiceBuilder WithInvoiceId(long invoiceId);
    IInvoiceBuilder ForCustomer(Customer customer);
    IInvoiceBuilder WithBillingAddress(string address, string city, string state, string postalCode, string country);
    IInvoiceBuilder WithInvoiceDate(string invoiceDate);
    IInvoiceBuilder AddInvoiceItem(InvoiceItem invoiceItem);
    IInvoiceBuilder WithInvoiceItems(IEnumerable<InvoiceItem> invoiceItems);
}
