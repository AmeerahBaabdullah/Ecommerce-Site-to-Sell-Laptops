using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sell_laptop.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string email{ get; set; }
        public string details { get; set; }
    }
}