using CatalogApi.Apis;
using CatalogApi.Contracts;
using CatalogApi.DataContext;
using CatalogApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOutputCache();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddDbContext<CatalogDbContext>(x => x.UseInMemoryDatabase("test"));
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseOutputCache();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("os", () => {
    return Environment.OSVersion;
});
app.UseHttpsRedirection();
app.MapProducts();
app.Run();



