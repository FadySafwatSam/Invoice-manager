using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApplication.Model
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public String Description { get; set; }
        public DateTime? date { get; set; }
        public String UploadedImages  { get; set; }
        public String ClientName  { get; set; }

        public int? InvoiceNO { get; set; }
        public int? TotalBeforeTax { get; set; }
        public int? TotalVAT  { get; set; }
        public int? TotalAfterVAT { get; set; }
        public List<Item> Items { get; set; }





    }
}