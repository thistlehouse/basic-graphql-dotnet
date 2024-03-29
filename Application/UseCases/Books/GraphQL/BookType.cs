using BasicGraphQL.Infrastructure.Entities;
using GraphQL.Types;

namespace BasicGraphQL.Application.UseCases.Books.GraphQL;

public class BookType : ObjectGraphType<Book>
{
    public BookType()
    {
        Name = "Book";
        Description = "An object with pages made of paper.";

        Field<IdGraphType>("id");
        Field(b => b.Title).Description("Book's title");
        Field(b => b.Year).Description("Year that the book was released.");
    }
}