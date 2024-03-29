using BasicGraphQL.Api.UseCases.Books;
using BasicGraphQL.Application;
using BasicGraphQL.Infrastructure;
using GraphiQl;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseGraphQL<ISchema>("/graphql");

    app.UseGraphQLPlayground("/playground", new PlaygroundOptions
    {
        GraphQLEndPoint = "/graphql",
        SubscriptionsEndPoint = "/graphql",
    });

    app.UseGraphiQl("/graphiql");
    app.UseGraphQLAltair("/altair");

    app.UseHttpsRedirection();
    app.MapBookEndpoints();
    app.Run();
}