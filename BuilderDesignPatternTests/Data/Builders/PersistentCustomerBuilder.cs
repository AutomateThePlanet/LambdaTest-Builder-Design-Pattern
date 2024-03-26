using BuilderDesignPatternTests.Data.Builders.Contracts;
using RepositoryDesignPatternTests;
using RepositoryDesignPatternTests.Data.Factories;
using RepositoryDesignPatternTests.Data.Repositories;
using RepositoryDesignPatternTests.Models;

namespace BuilderDesignPatternTests.Data.Builders;
public class PersistentCustomerBuilder : ICustomerBuilder
{
    private Customer _customer;
    private readonly CustomerRepository _customerRepository;

    public PersistentCustomerBuilder()
    {
        _customer = new Customer();
        _customerRepository = new CustomerRepository(Urls.BASE_API_URL);
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
        return _customerRepository.Create(_customer);
    }
}
