using RepositoryDesignPatternTests.Models;

namespace RepositoryDesignPatternTests.Data.Repositories;
public class InvoiceItemRepository : HttpRepository<InvoiceItem>
{
    public InvoiceItemRepository(string baseUrl)
        : base(baseUrl, "invoiceitems")
    {
    }
}
