using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeekWeb.Models
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal PriceReduce { get; set; }
        public int FreeAds { get; set; }
        public int MinQuantity { get; set; }
    }
}
