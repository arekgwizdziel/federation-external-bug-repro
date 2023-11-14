using ReviewSubgraph;

var builder = WebApplication.CreateBuilder();

builder.Services
    .AddGraphQLServer()
    .AddApolloFederationV2()
    .AddQueryType<Query>()
    .AddType<Product>();

var app = builder.Build();

app.MapGraphQL();

await app.RunAsync().ConfigureAwait(false);