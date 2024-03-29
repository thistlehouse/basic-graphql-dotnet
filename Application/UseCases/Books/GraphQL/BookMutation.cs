using BasicGraphQL.Application.Repositories;
using BasicGraphQL.Infrastructure.Entities;
using GraphQL;
using GraphQL.Types;

namespace BasicGraphQL.Application.UseCases.Books.GraphQL;

public class BookMutation : ObjectGraphType, IGraphMutationMarker
{
    private readonly IBookRepository _bookRepository;

    public BookMutation(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;

        Name = "Mutation";

        var id = _bookRepository.GetAll().Count();

        Field<BookType>("createBook")
            .Argument<NonNullGraphType<BookInputType>>("book")
            .Resolve(context =>
            {
                var bookArg = context.GetArgument<Book>("book");
                var book = new Book(++id, bookArg.Title, bookArg.Year);

                _bookRepository.Add(book);

                return book;
            });
    }
}