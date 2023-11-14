using ProductSubgraph;

var builder = WebApplication.CreateBuilder();

builder.Services
    .AddGraphQLServer()
    .AddApolloFederationV2()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();

await app.RunAsync().ConfigureAwait(false);