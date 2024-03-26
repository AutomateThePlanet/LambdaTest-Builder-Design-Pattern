using BuilderDesignPatternTests.Data.Builders.Contracts;
using RepositoryDesignPatternTests.Models;

namespace BuilderDesignPatternTests;
public interface IArtistBuilder : IBuilder<IArtistBuilder, Artist>
{
    IArtistBuilder WithArtistId(long artistId);
    IArtistBuilder WithName(string name);
    IArtistBuilder AddAlbum(Album album);
    IArtistBuilder WithAlbums(IEnumerable<Album> albums);
}
