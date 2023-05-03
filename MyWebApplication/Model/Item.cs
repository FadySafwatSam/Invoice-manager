using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApplication.Model
{
    public class Item
    {
        public int ItemId { get; set; }

        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Tax { get; set; }
        public int InvoiceId { get; set; }
        public Invoice invoice { get; set; }
    }
}