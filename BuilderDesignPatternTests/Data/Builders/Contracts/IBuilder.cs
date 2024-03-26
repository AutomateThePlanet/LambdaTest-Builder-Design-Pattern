namespace BuilderDesignPatternTests.Data.Builders.Contracts;
public interface IBuilder<TBuilder, TModel>
    where TModel : class
    where TBuilder : IBuilder<TBuilder, TModel>
{
    TBuilder WithDefaultConfiguration();
    TModel Build();
}
