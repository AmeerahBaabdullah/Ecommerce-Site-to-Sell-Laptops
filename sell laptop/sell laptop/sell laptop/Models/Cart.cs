using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sell_laptop.Models
{
    public class Cart
    {
        public string email { get; set; }
        public int lapId { get; set; }
        public int quantity { get; set; }
        public string desc { get; set; }
        public int price { get; set; }

    }


}