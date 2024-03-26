using RepositoryDesignPatternTests.Data.Factories;
using RepositoryDesignPatternTests.Models;

namespace BuilderDesignPatternTests.Data.Builders;
public class TransientAlbumBuilder : IAlbumBuilder
{
    private Album _album;

    public TransientAlbumBuilder()
    {
        _album = new Album();
    }

    public IAlbumBuilder WithDefaultConfiguration()
    {
        // Assume AlbumFactory.GenerateAlbum() provides a default Album instance
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
        return _album;
    }
}

