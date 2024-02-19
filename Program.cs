var builder = WebApplication.CreateBuilder(args);

// Setup our GraphQL server
// Adding a couple of services to the servie collection
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();


var app = builder.Build();

app.MapGraphQL();

app.Run();

// Root operation type
public class Query
{
    public string Hello(string name = "workd") => $"Hello, {name}!";
}
