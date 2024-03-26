using BuilderDesignPatternTests.Data.Builders.Contracts;
using BuilderDesignPatternTests.Data.Factories;
using RepositoryDesignPatternTests.Models;

namespace BuilderDesignPatternTests.Data.Builders;
public class TransientEmployeeBuilder : IEmployeeBuilder
{
    private Employee _employee = new Employee();

    public IEmployeeBuilder WithDefaultConfiguration()
    {
        _employee = EmployeeFactory.GenerateEmployee();
        return this;
    }

    public IEmployeeBuilder WithEmployeeId(long employeeId)
    {
        _employee.EmployeeId = employeeId;
        return this;
    }

    public IEmployeeBuilder WithName(string firstName, string lastName)
    {
        _employee.FirstName = firstName;
        _employee.LastName = lastName;
        return this;
    }

    public IEmployeeBuilder WithTitle(string title)
    {
        _employee.Title = title;
        return this;
    }

    public IEmployeeBuilder ReportsTo(Employee manager)
    {
        _employee.ReportsToNavigation = manager;
        _employee.ReportsTo = manager?.EmployeeId;
        return this;
    }

    public IEmployeeBuilder WithContactInfo(string email, string phone)
    {
        _employee.Email = email;
        _employee.Phone = phone;
        return this;
    }

    public IEmployeeBuilder WithAddress(string address, string city, string state, string postalCode, string country)
    {
        _employee.Address = address;
        _employee.City = city;
        _employee.State = state;
        _employee.PostalCode = postalCode;
        _employee.Country = country;
        return this;
    }

    public Employee Build()
    {
        return _employee;
    }
}
