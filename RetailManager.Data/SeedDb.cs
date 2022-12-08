using Microsoft.Extensions.Logging;
using RetailManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManager.Data
{
    public class SeedDb
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<AppDbContext> _logger;

        public SeedDb(AppDbContext dbContext, ILogger<AppDbContext> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task TrySeedAsync()
        {
            try
            {
                await SeedProducts();
                var productId = _dbContext.Products.First().ProductId;
                await SeedReviews(productId);
                await SeedTags();
                await AddTagsToProducts();

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred while seeding the database.");
            }
        }

        public async Task SeedProducts()
        {
            if (!_dbContext.Products.Any())
            {
                var products = new List<Product>
                    {
                        new Product
                        {
                            ProductName = "AMD Ryzen 5 5600G 4.4GHz Processor",
                            Quantity = 12,
                            Price = 5400,
                            DateModified = DateTime.Now,
                        },
                        new Product
                        {
                            ProductName = "Royal Kludge Rk84 Mechanical Keyboard",
                            Quantity = 18,
                            Price = 2399,
                            DateModified = DateTime.Now,
                        },
                        new Product
                        {
                            ProductName = "Asus ROG STRIX Gaming Laptop",
                            Quantity = 4,
                            Price = 64999,
                            DateModified = DateTime.Now,
                        }
                    };

                await _dbContext.AddRangeAsync(products);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task SeedReviews(int productId)
        {
            if (!_dbContext.Reviews.Any())
            {
                var reviews = new List<Review>
                    {
                        new Review
                        {
                            ReviewerName = "goldceera",
                            Comment = "sulit, What a cheap APU but a beast",
                            NumStars = 5,
                            ProductId = productId,
                        },
                        new Review
                        {
                            ReviewerName = "caleja24",
                            Comment = "The product is not damaged. It is well packed.",
                            NumStars = 4,
                            ProductId = productId,
                        },
                        new Review
                        {
                            ReviewerName = "myleszosa",
                            Comment = "The processor works as intended. Overall the item is working, with no issues. ",
                            NumStars = 4,
                            ProductId = productId,
                        },

                    };

                await _dbContext.AddRangeAsync(reviews);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task SeedTags()
        {
            if (!_dbContext.Tags.Any())
            {
                var tags = new List<Tag>
                {
                    new Tag { TagName = "Processor" },
                    new Tag { TagName = "Keyboard" },
                    new Tag { TagName = "Laptop" },

                };

                await _dbContext.AddRangeAsync(tags);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task AddTagsToProducts()
        {
            if (!_dbContext.ProductTags.Any())
            {
                var productTags = new List<ProductTag>
                {
                    new ProductTag { ProductId = 1, TagId = 1 },
                    new ProductTag { ProductId = 2, TagId = 2 },
                    new ProductTag { ProductId = 3, TagId = 3 },
                };

                await _dbContext.AddRangeAsync(productTags);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

