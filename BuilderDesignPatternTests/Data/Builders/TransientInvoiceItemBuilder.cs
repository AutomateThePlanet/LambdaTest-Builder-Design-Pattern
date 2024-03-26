using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderDesignPatternTests.Data.Builders.Contracts;
using BuilderDesignPatternTests.Data.Factories;
using RepositoryDesignPatternTests.Models;

namespace BuilderDesignPatternTests.Data.Builders;
public class TransientInvoiceItemBuilder : IInvoiceItemBuilder
{
    private InvoiceItem _invoiceItem;

    public TransientInvoiceItemBuilder()
    {
        _invoiceItem = new InvoiceItem();
    }

    public IInvoiceItemBuilder WithDefaultConfiguration()
    {
        _invoiceItem = InvoiceItemFactory.GenerateInvoiceItem();
        return this;
    }

    public IInvoiceItemBuilder WithInvoiceLineId(long invoiceLineId)
    {
        _invoiceItem.InvoiceLineId = invoiceLineId;
        return this;
    }

    public IInvoiceItemBuilder ForInvoice(Invoice invoice)
    {
        _invoiceItem.Invoice = invoice;
        _invoiceItem.InvoiceId = invoice.InvoiceId;
        return this;
    }

    public IInvoiceItemBuilder WithTrack(Track track)
    {
        _invoiceItem.Track = track;
        _invoiceItem.TrackId = track.TrackId;
        return this;
    }

    public IInvoiceItemBuilder WithUnitPrice(string unitPrice)
    {
        _invoiceItem.UnitPrice = unitPrice;
        return this;
    }

    public IInvoiceItemBuilder WithQuantity(long quantity)
    {
        _invoiceItem.Quantity = quantity;
        return this;
    }

    public InvoiceItem Build()
    {
        return _invoiceItem;
    }
}
