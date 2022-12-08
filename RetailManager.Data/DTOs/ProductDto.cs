using RetailManager.Data.Models;
namespace RetailManager.Data.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime DateModified { get; set; }
        public ICollection<Review> Reviews { get; set; }

        public string ReviewStars { get; set; }

        public ICollection<string> Tags { get; set; }




    }
}
