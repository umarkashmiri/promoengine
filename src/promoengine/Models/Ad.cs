using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeekWeb.Models
{
    public class Ad
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdId { get; set; }
        public string AdName { get; set; }
        public AdType AdType { get; set; }
        public decimal Rate { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public enum AdType { Classic, Standout, Premium }
}
