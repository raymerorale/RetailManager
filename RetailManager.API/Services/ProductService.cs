using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RetailManager.Data;
using RetailManager.Data.DTOs;
using RetailManager.Data.Models;

namespace RetailManager.API.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext appDbContext, ILogger<ProductService> logger, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var products = await _appDbContext.Products
                .Include(p => p.ProductTags)
                .ThenInclude(pt => pt.Tag)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync();


            return products;
        }
    }

    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAll();
    }
}
