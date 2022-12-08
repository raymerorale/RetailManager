using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManager.Data.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string? Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime DateModified { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
