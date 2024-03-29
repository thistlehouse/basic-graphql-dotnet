using BasicGraphQL.Application.UseCases.Books;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BasicGraphQL.Api.UseCases.Books;


public static class BookEndpoints
{
    public static void MapBookEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("books").WithTags("Books");

        group.MapPost(
            "create",
            async (
                [FromBody] string query,
                IBookUseCase bookCase) =>
                {
                    var result = await bookCase.Execute(query);

                    return Results.Ok(result);
                })
        .WithOpenApi();


        group.MapGet(
            "list",
            async (
                [FromBody] string query,
                IBookUseCase bookCase) =>
                {
                    var result = await bookCase.Execute(query);

                    return Results.Ok(result);
                })
        .WithOpenApi();
    }
}