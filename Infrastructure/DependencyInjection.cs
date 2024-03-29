using BasicGraphQL.Application.Repositories;
using BasicGraphQL.Application.UseCases.Books.GraphQL;
using BasicGraphQL.Infrastructure.Repositories;
using GraphQL;
using GraphQL.Types;

namespace BasicGraphQL.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IBookRepository, BookRepository>();
        services.AddSingleton<BookType>();
        services.AddSingleton<BookInputType>();
        services.AddSingleton<BookQuery>();
        services.AddSingleton<BookMutation>();
        services.AddSingleton<ISchema, BookSchema>();
        // services.AddSingleton<GraphQLQuery>();
        // services.AddSingleton<GraphQLMutation>();
        // services.AddSingleton<ISchema, GraphQLSchema>();

        services.AddGraphQL(builder => builder
            .AddAutoSchema<BookQuery>()
            .AddSystemTextJson());

        return services;
    }
}