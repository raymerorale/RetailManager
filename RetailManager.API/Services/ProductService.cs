using Microsoft.EntityFrameworkCore;
using RetailManager.Data;
using RetailManager.Data.Models;

namespace RetailManager.API.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<ProductService> _logger;

        public ProductService(AppDbContext appDbContext, ILogger<ProductService> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _appDbContext.Products.ToListAsync();
        }
    }

    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
    }
}
