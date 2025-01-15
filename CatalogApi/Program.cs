using CatalogApi.Apis;
using CatalogApi.Contracts;
using CatalogApi.DataContext;
using CatalogApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOutputCache();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddDbContext<CatalogDbContext>(x =>
                    x.UseSqlServer(builder.Configuration.GetConnectionString("mycatalogDb")));

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
var db = app.Services.CreateScope().ServiceProvider.GetRequiredService<CatalogDbContext>();
db.Database.EnsureCreated();

app.UseOutputCache();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("os", () =>
{
    return Environment.OSVersion;
});

app.MapProducts();
app.Run();



