var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("getValueFromConfig", (IConfiguration configuration) => {
    return configuration["testConf:inner:value"];
});

app.MapGet("products",  async (HttpClient client) => {
    var str = await client.GetStringAsync("http://catalogapi/products");
    return str;
});

app.Run();

