using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sell_laptop.Models
{
    public class product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public string color { get; set; }
        public int price { get; set; }
        public string decs { get; set; }
        public string stauts { get; set; }
        public string category { get; set; }
        public int  offer { get; set; }
        public string pic { get; set; }
        public int quantity { get; set; }

        public int SelectedPropertyType { get; set; }
        public List<SelectListItem> PropertyType { get; set; }

    }
}