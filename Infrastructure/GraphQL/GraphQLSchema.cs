using GraphQL.Types;

namespace BasicGraphQL.Infrastructure.GraphQL;

public class GraphQLSchema : Schema
{
    public GraphQLSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<GraphQLQuery>();
        Mutation = provider.GetRequiredService<GraphQLMutation>();
    }
}
