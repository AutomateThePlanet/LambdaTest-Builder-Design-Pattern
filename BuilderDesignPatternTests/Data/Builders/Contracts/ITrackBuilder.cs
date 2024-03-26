using BuilderDesignPatternTests.Data.Builders.Contracts;
using RepositoryDesignPatternTests.Models;

namespace BuilderDesignPatternTests;
public interface ITrackBuilder : IBuilder<ITrackBuilder, Track>
{
    ITrackBuilder WithTrackId(long trackId);
    ITrackBuilder WithName(string name);
    ITrackBuilder WithAlbumId(long? albumId);
    ITrackBuilder WithMediaTypeId(long mediaTypeId);
    ITrackBuilder WithGenreId(long? genreId);
    ITrackBuilder WithComposer(string composer);
    ITrackBuilder WithDuration(int milliseconds);
    ITrackBuilder WithBytes(long? bytes);
    ITrackBuilder WithUnitPrice(string unitPrice);
    ITrackBuilder WithAlbum(Album album);
    ITrackBuilder WithGenre(Genre genre);
    ITrackBuilder WithMediaType(MediaType mediaType);
    ITrackBuilder WithInvoiceItem(InvoiceItem invoiceItem);
    ITrackBuilder WithPlaylistTrack(PlaylistTrack playlistTrack);
    ITrackBuilder WithInvoiceItems(ICollection<InvoiceItem> invoiceItems);
    ITrackBuilder WithPlaylistTracks(ICollection<PlaylistTrack> playlistTracks);
}
