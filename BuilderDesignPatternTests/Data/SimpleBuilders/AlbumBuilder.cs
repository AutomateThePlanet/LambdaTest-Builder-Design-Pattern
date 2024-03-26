using RepositoryDesignPatternTests.Models;

namespace BuilderDesignPatternTests.Data.SimpleBuilders;
public class AlbumBuilder
{
    private Album _album = new Album();

    public AlbumBuilder SetAlbumId(long albumId)
    {
        _album.AlbumId = albumId;
        return this;
    }

    public AlbumBuilder SetTitle(string title)
    {
        _album.Title = title;
        return this;
    }

    public AlbumBuilder SetArtistId(long artistId)
    {
        _album.ArtistId = artistId;
        return this;
    }

    public AlbumBuilder SetArtist(Artist artist)
    {
        _album.Artist = artist;
        return this;
    }

    public AlbumBuilder AddTrack(Track track)
    {
        _album.Tracks.Add(track);
        return this;
    }

    public Album Build()
    {
        return _album;
    }
}

