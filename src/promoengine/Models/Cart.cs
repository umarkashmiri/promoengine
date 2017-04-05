using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeekWeb.Models
{
    public class Cart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }
        public User User { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
