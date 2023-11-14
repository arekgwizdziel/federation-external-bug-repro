using ApolloGraphQL.HotChocolate.Federation;

namespace ProductSubgraph;

[Key("id")]
public class Product
{
    public Guid Id { get; set; }
    
    public Guid ReviewId { get; set; }
}

public class Query
{
    public Product GetProduct(Guid id)
    {
        return new Product
        {
            Id = id,
            ReviewId = Guid.Parse("4bb67525-ca6a-4a7d-8cab-63e1175a8ad8")
        };
    }
}