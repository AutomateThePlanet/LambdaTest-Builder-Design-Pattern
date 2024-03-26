using RepositoryDesignPatternTests.Data.Factories;
using RepositoryDesignPatternTests.Data.Repositories;
using RepositoryDesignPatternTests.Models;
using RepositoryDesignPatternTests;

namespace BuilderDesignPatternTests.Data.Builders;
public class PersistentAlbumBuilder : IAlbumBuilder
{
    private Album _album;
    private AlbumRepository _albumRepository;

    public PersistentAlbumBuilder()
    {
        _album = new Album();
        _albumRepository = new AlbumRepository(Urls.BASE_API_URL);
    }

    public IAlbumBuilder WithDefaultConfiguration()
    {
        _album = AlbumFactory.GenerateAlbum();
        return this;
    }

    public IAlbumBuilder WithAlbumId(long albumId)
    {
        _album.AlbumId = albumId;
        return this;
    }

    public IAlbumBuilder WithTitle(string title)
    {
        _album.Title = title;
        return this;
    }

    public IAlbumBuilder WithArtistId(long artistId)
    {
        _album.ArtistId = artistId;
        return this;
    }

    public IAlbumBuilder WithArtist(Artist artist)
    {
        _album.Artist = artist;
        return this;
    }

    public IAlbumBuilder AddTrack(Track track)
    {
        _album.Tracks.Add(track);
        return this;
    }

    public IAlbumBuilder WithTracks(ICollection<Track> tracks)
    {
        _album.Tracks = tracks;
        return this;
    }

    public Album Build()
    {
        _albumRepository.Create(_album);
        return _album;
    }
}

