using BasicGraphQL.Application.Repositories;
using GraphQL.Types;

namespace BasicGraphQL.Infrastructure.GraphQL;

public class GraphQLMutation : ObjectGraphType<object>
{
    public GraphQLMutation(IEnumerable<IGraphMutationMarker> graphMutationMarker)
    {
        Name = "GraphQLMutation";

        graphMutationMarker.ToList().ForEach(f =>
        {
            var mutation = f as ObjectGraphType<object>;

            mutation?.Fields.ToList().ForEach(m => AddField(m));
        });
    }
}
