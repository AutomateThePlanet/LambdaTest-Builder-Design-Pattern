using RepositoryDesignPatternTests.Models;

namespace BuilderDesignPatternTests.Data.Builders;
public class TransientArtistBuilder : IArtistBuilder
{
    private Artist _artist;

    public TransientArtistBuilder()
    {
        _artist = new Artist();
    }

    public IArtistBuilder WithDefaultConfiguration()
    {
        //_artist = ArtistFactory.GenerateArtist();
        return this;
    }

    public IArtistBuilder WithArtistId(long artistId)
    {
        _artist.ArtistId = artistId;
        return this;
    }

    public IArtistBuilder WithName(string name)
    {
        _artist.Name = name;
        return this;
    }

    public IArtistBuilder AddAlbum(Album album)
    {
        _artist.Albums.Add(album);
        return this;
    }

    public IArtistBuilder WithAlbums(ICollection<Album> albums)
    {
        _artist.Albums = albums;
        return this;
    }

    public Artist Build()
    {
        return _artist;
    }

    public IArtistBuilder WithAlbums(IEnumerable<Album> albums)
    {
        throw new NotImplementedException();
    }
}

