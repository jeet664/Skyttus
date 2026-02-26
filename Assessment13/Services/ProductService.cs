using Assessment13.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Assessment13.Services
{
    public class ProductService
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<ProductService> _logger;

        private static List<Product> _products = new()
        {
            new Product{ Id=1, Name="Laptop", Price=60000 },
            new Product{ Id=2, Name="Mobile", Price=20000 }
        };

        public ProductService(IMemoryCache cache,
            ILogger<ProductService> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public List<Product> GetProducts()
        {
            if (!_cache.TryGetValue("productList", out List<Product>? products))
            {
                _logger.LogInformation("Fetching from Database (Simulated)");

                products = _products;

                _cache.Set("productList", products,
                    TimeSpan.FromMinutes(5));
            }
            else
            {
                _logger.LogInformation("Fetching from Cache");
            }

            return products!;
        }
    }
}