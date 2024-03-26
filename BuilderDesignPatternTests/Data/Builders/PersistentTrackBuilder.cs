using RepositoryDesignPatternTests;
using RepositoryDesignPatternTests.Data.Factories;
using RepositoryDesignPatternTests.Data.Repositories;
using RepositoryDesignPatternTests.Models;

namespace BuilderDesignPatternTests;
public class PersistentTrackBuilder : ITrackBuilder
{
    private Track _track;
    private TrackRepository _trackRepository;
    private AlbumRepository _albumRepository;

    public PersistentTrackBuilder()
    {
        _track = new Track();
        _trackRepository = new TrackRepository(Urls.BASE_API_URL);
        _albumRepository = new AlbumRepository(Urls.BASE_API_URL);
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

    public ITrackBuilder WithDefaultAlbum()
    {
        var album = AlbumFactory.GenerateAlbum();
        return WithAlbum(album);
    }

    public ITrackBuilder WithAlbum(Album album)
    {
        _albumRepository.Create(album);
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
        _trackRepository.Create(_track);
        return _track;
    }
}
