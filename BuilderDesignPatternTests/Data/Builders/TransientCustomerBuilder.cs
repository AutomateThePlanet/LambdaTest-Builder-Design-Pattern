using BuilderDesignPatternTests.Data.Builders.Contracts;
using RepositoryDesignPatternTests.Data.Factories;
using RepositoryDesignPatternTests.Models;

namespace BuilderDesignPatternTests.Data.Builders;
public class TransientCustomerBuilder : ICustomerBuilder
{
    private Customer _customer;

    public TransientCustomerBuilder()
    {
        _customer = new Customer();
    }

    public ICustomerBuilder WithDefaultConfiguration()
    {
        _customer = CustomerFactory.GenerateCustomer();
        return this;
    }

    public ICustomerBuilder WithCustomerId(int customerId)
    {
        _customer.CustomerId = customerId;
        return this;
    }

    public ICustomerBuilder WithName(string firstName, string lastName)
    {
        _customer.FirstName = firstName;
        _customer.LastName = lastName;
        return this;
    }

    public ICustomerBuilder WithContactInfo(string email, string phone)
    {
        _customer.Email = email;
        _customer.Phone = phone;
        return this;
    }

    public ICustomerBuilder WithAddress(string address, string city, string state, string postalCode, string country)
    {
        _customer.Address = address;
        _customer.City = city;
        _customer.State = state;
        _customer.PostalCode = postalCode;
        _customer.Country = country;
        return this;
    }

    public ICustomerBuilder AddInvoice(Invoice invoice)
    {
        _customer.Invoices.Add(invoice);
        return this;
    }

    public ICustomerBuilder WithInvoices(IEnumerable<Invoice> invoices)
    {
        _customer.Invoices = invoices.ToList();
        return this;
    }

    public Customer Build()
    {
        return _customer;
    }
}
