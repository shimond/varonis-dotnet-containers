using CatalogApi.Contracts;
using CatalogApi.DataContext;
using Microsoft.EntityFrameworkCore;

namespace CatalogApi.Repositories;

public class ProductRepository(
    CatalogDbContext context) : IProductRepository
{

    public async Task<List<Product>> GetProductsAsync()
    {
        var res = await context.Products.ToListAsync();
        return res;
    }
    public async Task<Product?> GetProductByIdAsync(int id)
    {
        var res = await context.Products.FindAsync(id);
        return res;
    }
    public async Task<Product> CreateProductAsync(Product product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();
        return product;
    }
    public async Task UpdateProductAsync(Product product)
    {
        context.Entry(product).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }
    public async Task DeleteProductAsync(Product product)
    {
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }
}
