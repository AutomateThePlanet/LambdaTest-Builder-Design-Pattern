using RepositoryDesignPatternTests.Models;

namespace RepositoryDesignPatternTests.Data.Repositories;
public class EmployeeRepository : HttpRepository<Employee, List<Employee>>
{
    public EmployeeRepository(string baseUrl)
        : base(baseUrl, "employees")
    {
    }
}
