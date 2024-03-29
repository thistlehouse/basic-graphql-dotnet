using BasicGraphQL.Application.Repositories;
using GraphQL;
using GraphQL.Types;

namespace BasicGraphQL.Application.UseCases.Books.GraphQL;

public class BookQuery : ObjectGraphType, IGraphMutationMarker
{
    public readonly IBookRepository _bookRepository;

    public BookQuery(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;

        Name = "Query";

        // var bookArguments = new QueryArguments(
        //     new QueryArgument<StringGraphType>() { Name = "title" },
        //     new QueryArgument<StringGraphType>() { Name = "year" });

        Field<ListGraphType<BookType>>("books")
            .Resolve(context =>
            {
                // var filter = context.GetArgument<string>("title");
                // var arguments = context.GetArgument<Dictionary<string, object>>("arguments");
                // var title = arguments.ContainsKey("title") ? Convert.ToString(arguments["title"]) : "";

                return _bookRepository.GetAll();
            });

        Field<BookType>("book")
            .Arguments(new QueryArguments(
                new QueryArgument<IdGraphType> { Name = "id" }))
            .Resolve(context =>
            {
                var id = context.GetArgument<int>("id");

                return _bookRepository.GetById(id);
            });
    }
}