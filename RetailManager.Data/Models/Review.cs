using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManager.Data.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        [Required]
        public string ReviewerName { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public int NumStars { get; set; }

        [Required]
        public DateTime ReviewDate { get; set; }

        public int ProductId { get; set; }
    }
}
