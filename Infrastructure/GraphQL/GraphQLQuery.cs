using BasicGraphQL.Application.Repositories;
using GraphQL.Types;

namespace BasicGraphQL.Infrastructure.GraphQL;

public class GraphQLQuery : ObjectGraphType<object>
{
    public GraphQLQuery(IEnumerable<IGraphQueryMarker> graphQueryMarkers)
    {
        Name = "GraphQLQuery";

        graphQueryMarkers.ToList().ForEach(f =>
        {
            var query = f as ObjectGraphType<object>;

            query?.Fields.ToList().ForEach(q => AddField(q));
        });
    }
}