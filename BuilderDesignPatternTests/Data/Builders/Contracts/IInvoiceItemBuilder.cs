using RepositoryDesignPatternTests.Models;

namespace BuilderDesignPatternTests.Data.Builders.Contracts;
public interface IInvoiceItemBuilder : IBuilder<IInvoiceItemBuilder, InvoiceItem>
{
    IInvoiceItemBuilder WithInvoiceLineId(long invoiceLineId);
    IInvoiceItemBuilder ForInvoice(Invoice invoice);
    IInvoiceItemBuilder WithTrack(Track track);
    IInvoiceItemBuilder WithUnitPrice(string unitPrice);
    IInvoiceItemBuilder WithQuantity(long quantity);
}
