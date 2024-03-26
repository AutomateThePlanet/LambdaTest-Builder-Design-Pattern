using RepositoryDesignPatternTests.Data.Factories;
using RepositoryDesignPatternTests.Models;

namespace BuilderDesignPatternTests;
public class TransientTrackBuilder : ITrackBuilder
{
    private Track _track;

    public TransientTrackBuilder()
    {
        _track = new Track();
    }

    public ITrackBuilder WithDefaultConfiguration()
    {
        _track = TrackFactory.GenerateTrack();
        return this;
    }

    public ITrackBuilder WithTrackId(long trackId)
    {
        _track.TrackId = trackId;
        return this;
    }

    public ITrackBuilder WithName(string name)
    {
        _track.Name = name;
        return this;
    }

    public ITrackBuilder WithAlbumId(long? albumId)
    {
        _track.AlbumId = albumId;
        return this;
    }

    public ITrackBuilder WithMediaTypeId(long mediaTypeId)
    {
        _track.MediaTypeId = mediaTypeId;
        return this;
    }

    public ITrackBuilder WithGenreId(long? genreId)
    {
        _track.GenreId = genreId;
        return this;
    }

    public ITrackBuilder WithComposer(string composer)
    {
        _track.Composer = composer;
        return this;
    }

    public ITrackBuilder WithDuration(int milliseconds)
    {
        _track.Milliseconds = milliseconds;
        return this;
    }

    public ITrackBuilder WithBytes(long? bytes)
    {
        _track.Bytes = bytes;
        return this;
    }

    public ITrackBuilder WithUnitPrice(string unitPrice)
    {
        _track.UnitPrice = unitPrice;
        return this;
    }

    public ITrackBuilder WithAlbum(Album album)
    {
        _track.Album = album;
        return this;
    }

    public ITrackBuilder WithGenre(Genre genre)
    {
        _track.Genre = genre;
        return this;
    }

    public ITrackBuilder WithMediaType(MediaType mediaType)
    {
        _track.MediaType = mediaType;
        return this;
    }

    public ITrackBuilder WithInvoiceItem(InvoiceItem invoiceItem)
    {
        _track.InvoiceItems.Add(invoiceItem);
        return this;
    }

    public ITrackBuilder WithPlaylistTrack(PlaylistTrack playlistTrack)
    {
        _track.PlaylistTrack.Add(playlistTrack);
        return this;
    }

    public ITrackBuilder WithInvoiceItems(ICollection<InvoiceItem> invoiceItems)
    {
        _track.InvoiceItems = invoiceItems;
        return this;
    }

    public ITrackBuilder WithPlaylistTracks(ICollection<PlaylistTrack> playlistTracks)
    {
        _track.PlaylistTrack = playlistTracks;
        return this;
    }

    public Track Build()
    {
        return _track;
    }
}
