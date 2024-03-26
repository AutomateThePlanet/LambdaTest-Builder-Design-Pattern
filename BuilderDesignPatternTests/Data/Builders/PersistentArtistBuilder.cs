using RepositoryDesignPatternTests.Models;
using RepositoryDesignPatternTests;
using RepositoryDesignPatternTests.Data.Repositories;
using BuilderDesignPatternTests.Data.Factories;

namespace BuilderDesignPatternTests.Data.Builders;
public class PersistentArtistBuilder : IArtistBuilder
{
    private Artist _artist;
    private ArtistRepository _artistRepository;

    public PersistentArtistBuilder()
    {
        _artist = new Artist();
        _artistRepository = new ArtistRepository(Urls.BASE_API_URL);
    }

    public IArtistBuilder WithDefaultConfiguration()
    {
        _artist = ArtistFactory.GenerateArtist();
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
        _artistRepository.Create(_artist);
        return _artist;
    }

    public IArtistBuilder WithAlbums(IEnumerable<Album> albums)
    {
        throw new NotImplementedException();
    }
}

