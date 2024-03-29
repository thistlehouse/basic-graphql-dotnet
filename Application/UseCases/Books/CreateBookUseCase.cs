using BasicGraphQL.Application.Repositories;
using BasicGraphQL.Application.UseCases.Books.GraphQL;
using GraphQL;
using GraphQL.Types;

namespace BasicGraphQL.Application.UseCases.Books;

public class CreateBookUseCase(IBookRepository bookRepository) : IBookUseCase
{
    private readonly IBookRepository _bookRepository = bookRepository;

    public async Task<ExecutionResult> Execute(string query)
    {
        var schema = new Schema { Query = new BookQuery(_bookRepository) };

        var result = await new DocumentExecuter()
            .ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query;
            })
            .ConfigureAwait(false);

        return result;
    }
}
