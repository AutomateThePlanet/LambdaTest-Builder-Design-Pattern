using RepositoryDesignPatternTests.Models;

namespace BuilderDesignPatternTests.Data.Builders.Contracts;
public interface ICustomerBuilder : IBuilder<ICustomerBuilder, Customer>
{
    ICustomerBuilder WithCustomerId(int customerId);
    ICustomerBuilder WithName(string firstName, string lastName);
    ICustomerBuilder WithContactInfo(string email, string phone);
    ICustomerBuilder WithAddress(string address, string city, string state, string postalCode, string country);
    ICustomerBuilder AddInvoice(Invoice invoice);
    ICustomerBuilder WithInvoices(IEnumerable<Invoice> invoices);
}
