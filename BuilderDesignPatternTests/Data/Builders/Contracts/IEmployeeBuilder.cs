using RepositoryDesignPatternTests.Models;

namespace BuilderDesignPatternTests.Data.Builders.Contracts;
public interface IEmployeeBuilder : IBuilder<IEmployeeBuilder, Employee>
{
    IEmployeeBuilder WithEmployeeId(long employeeId);
    IEmployeeBuilder WithName(string firstName, string lastName);
    IEmployeeBuilder WithTitle(string title);
    IEmployeeBuilder ReportsTo(Employee manager);
    IEmployeeBuilder WithContactInfo(string email, string phone);
    IEmployeeBuilder WithAddress(string address, string city, string state, string postalCode, string country);
}
