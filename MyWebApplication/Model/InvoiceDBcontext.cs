using MyWebApplication.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyWebApplication
{
    public class InvoiceDBcontext : DbContext
    {


        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Item> Items { get; set; }

     
    }
}