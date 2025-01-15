var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("products",  async (HttpClient client) => {
    var str = await client.GetStringAsync("http://catalogapi:8080/products");
    return str;
});

app.Run();

