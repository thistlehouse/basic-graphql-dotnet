using GraphQL.Types;

namespace BasicGraphQL.Application.UseCases.Books.GraphQL;

public class BookInputType : InputObjectGraphType
{
    public BookInputType()
    {
        Name = "BookInput";

        Field<NonNullGraphType<StringGraphType>>("title");
        Field<DateGraphType>("year");
    }
}