namespace CatalogApi.Contracts;
public interface IProductRepository
{
    Task<Product> CreateProductAsync(Product product);
    Task DeleteProductAsync(Product product);
    Task<Product?> GetProductByIdAsync(int id);
    Task<List<Product>> GetProductsAsync();
    Task UpdateProductAsync(Product product);
}
