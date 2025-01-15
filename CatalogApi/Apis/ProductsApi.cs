using CatalogApi.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Query;

namespace CatalogApi.Apis;

public static class ProductsApi
{
    public static WebApplication MapProducts(this WebApplication app)
    {
        var productsGroup = app.MapGroup("products");
        //.RequireAuthorization();
        productsGroup.MapGet("", GetAllProducts);
        productsGroup.MapGet("{id}", GetProductById);
        productsGroup.MapPost("", CreateProduct);
        productsGroup.MapGet("TestTime", async () => {
            await Task.Delay(5000);
            return DateTime.Now;
        }).CacheOutput();
        //.AllowAnonymous();
        return app;
    }

    static async Task<Created<Product>> CreateProduct(Product product, IProductRepository repository)
    {
        var res = await repository.CreateProductAsync(product);
        return TypedResults.Created("/products/" + res.Id, res);
    }

    static async Task<Results<Ok<Product>, NotFound>> GetProductById(int id, IProductRepository repository)
    {
        var res = await repository.GetProductByIdAsync(id);
        if (res is null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(res);
    }
    static async Task<Ok<List<Product>>> GetAllProducts(IProductRepository repository)
    {
        var res = await repository.GetProductsAsync();
        return TypedResults.Ok(res);
    }

}
