using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManager.Data.Models
{
    public class Tag
    {
        public int TagId { get; set; }

        [Required]
        public string TagName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
