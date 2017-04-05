using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeekWeb.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
