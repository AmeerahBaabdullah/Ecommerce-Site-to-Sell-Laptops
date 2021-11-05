using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sell_laptop.Models
{
    public class EUser
    {
        public string Fname { get; set; }
        public string Lname { get; set; }

        public string Email { get; set; }

        public string address { get; set; }

        public int phone { get; set; }
        public string password { get; set; }
        public string city { get; set; }

        public string country { get; set; }

    }
}