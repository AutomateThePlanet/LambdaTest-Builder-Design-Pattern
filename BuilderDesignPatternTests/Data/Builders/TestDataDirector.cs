using BuilderDesignPatternTests.Data.Builders.Contracts;
using RepositoryDesignPatternTests.Models;

namespace BuilderDesignPatternTests.Data.Builders;
public class TestDataDirector
{
    private readonly BuilderMode _mode;

    public TestDataDirector(BuilderMode mode = BuilderMode.Persistent)
    {
        _mode = mode;
    }

    public Artist CreateArtistWithDiscographyAndSales(string artistName, int albumCount, int trackCountPerAlbum, int customerCount)
    {
        // Start building the artist
        var artist = GetArtistBuilder()
            .WithName(artistName)
            .Build();

        for (int i = 0; i < albumCount; i++)
        {
            // Start building each album
            var album = GetAlbumBuilder()
                .WithTitle($"Album {i + 1}")
                .WithArtist(artist)
                .Build();

            for (int j = 0; j < trackCountPerAlbum; j++)
            {
                // Build and add each track to the album
                var track = GetTrackBuilder()
                    .WithName($"Track {j + 1}")
                    .WithDuration(200000) // Example duration
                    .WithAlbum(album)
                    .Build();

                for (int k = 0; k < customerCount; k++)
                {
                    // Build customer
                    var customer = GetCustomerBuilder()
                        .WithName($"Customer {k + 1}", "Lastname")
                        .WithContactInfo($"customer{k + 1}@example.com", "555-0100+i")
                        .Build();

                    // Build invoice for the customer
                    var invoice = GetInvoiceBuilder()
                        .ForCustomer(customer)
                        .WithInvoiceDate(DateTime.Now.ToString("yyyy-MM-dd"))
                        .Build();

                    // Add an invoice item for the track to the invoice
                    var invoiceItem = GetInvoiceItemBuilder()
                        .ForInvoice(invoice)
                        .WithTrack(track)
                        .WithUnitPrice("9.99") // Example unit price
                        .WithQuantity(1)
                        .Build();
                }
            }
        }

        return artist;
    }

    private IArtistBuilder GetArtistBuilder()
    {
        return _mode == BuilderMode.Persistent ? new PersistentArtistBuilder() : new TransientArtistBuilder();
    }

    private IAlbumBuilder GetAlbumBuilder()
    {
        return _mode == BuilderMode.Persistent ? new PersistentAlbumBuilder() : new TransientAlbumBuilder();
    }

    private ITrackBuilder GetTrackBuilder()
    {
        return _mode == BuilderMode.Persistent ? new PersistentTrackBuilder() : new TransientTrackBuilder();
    }

    private ICustomerBuilder GetCustomerBuilder()
    {
        return _mode == BuilderMode.Persistent ? new PersistentCustomerBuilder() : new TransientCustomerBuilder();
    }

    private IInvoiceBuilder GetInvoiceBuilder()
    {
        return _mode == BuilderMode.Persistent ? new PersistentInvoiceBuilder() : new TransientInvoiceBuilder();
    }

    private IInvoiceItemBuilder GetInvoiceItemBuilder()
    {
        return _mode == BuilderMode.Persistent ? new PersistentInvoiceItemBuilder() : new TransientInvoiceItemBuilder();
    }
}
