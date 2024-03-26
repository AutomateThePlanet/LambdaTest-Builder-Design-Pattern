using BuilderDesignPatternTests.Data.Builders.Contracts;
using RepositoryDesignPatternTests.Models;

namespace BuilderDesignPatternTests;
public interface IAlbumBuilder : IBuilder<IAlbumBuilder, Album>
{
    IAlbumBuilder WithAlbumId(long albumId);
    IAlbumBuilder WithTitle(string title);
    IAlbumBuilder WithArtistId(long artistId);
    IAlbumBuilder WithArtist(Artist artist);
    IAlbumBuilder AddTrack(Track track);
    IAlbumBuilder WithTracks(ICollection<Track> tracks);
}
