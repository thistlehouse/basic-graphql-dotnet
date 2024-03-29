using GraphQL;

namespace BasicGraphQL.Application.UseCases.Books;

public interface IBookUseCase
{
    Task<ExecutionResult> Execute(string query);
}