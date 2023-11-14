using ApolloGraphQL.HotChocolate.Federation;
using HotChocolate.Language;
using HotChocolate.Resolvers;

namespace ReviewSubgraph;

[Key("id")]
public class Review
{
    public Guid Id { get; set; }
    public string Body { get; set; }
}

[Key("id")]
[Extends]
public class Product
{
    public Guid Id { get; set; }
 
    [External]
    public Guid ReviewId { get; set; }
    
    [ReferenceResolver]
    public static Product GetProduct(Guid id) => new() { Id = id };
    
    [Requires("reviewId")]
    public Review GetReview(IResolverContext context)
    {
        var reviewId = context.Variables!
            .GetVariable<ListValueNode>("representations")!
            .Items.Cast<ObjectValueNode>()
            .First(e => e.Fields.Any(f => f.Name.Value == "id" && ((StringValueNode)f.Value).Value == Id.ToString()))
            .Fields
            .First(e => e.Name.Value == "reviewId").Value as StringValueNode;
        
        return new Review
        {
            Id = ReviewId,
            Body = "This is a review"
        };
    }
}

public class Query
{
    public Review GetReview(Guid id)
    {
        return new Review
        {
            Id = id,
            Body = "This is a review"
        };
    }
}