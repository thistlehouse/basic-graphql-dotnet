using GraphQL.Types;

namespace BasicGraphQL.Application.UseCases.Books.GraphQL;

public class BookSchema : Schema
{
    public BookSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<BookQuery>();
        Mutation = provider.GetRequiredService<BookMutation>();
    }
}