var builder = WebApplication.CreateBuilder(args);

// Setup our GraphQL server
// Adding a couple of services to the servie collection
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();


var app = builder.Build();

// Map the graphql transport
app.MapGraphQL();

app.Run();

// This class is going to represent our root operation type
// This class will be translated to a graphql type
// From C# type it is gonna be translated to an SDL type
public class Query
{
    // We call this in the graphql vocab a resolver (ite resolves our data)
    public string Hello(string name = "World") => $"Hello, {name}!";
    public IEnumerable<Book>GetBooks(){
        var author = new Author("Hamma da best author");
        yield return new Book("C# is da best", author);
        yield return new Book("C# is da best 2", author);
    }
}

public record Book(string Title, Author Author);
public record Author(string Name);
