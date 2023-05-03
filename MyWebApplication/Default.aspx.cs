using MyWebApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

using Newtonsoft.Json;

namespace MyWebApplication
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e , String name)
        {
            if (IsPostBack)
            {

            

            }

        }

        [WebMethod]
        public static string LoadInvoices(String name)
        {

            var db = new InvoiceDBcontext();
            var inv = db.Invoices.ToList();
            string json = JsonConvert.SerializeObject(inv);


            return json;

        }
        [WebMethod]
        public static string InvoiceItems(int InvoiceID)
        {

            var db = new InvoiceDBcontext();

            var inv = db.Items.Where(itm=> itm.InvoiceId == InvoiceID).ToList();
            string json = JsonConvert.SerializeObject(inv);


            return json;

        }

        [WebMethod]
        public static string DeleteInvoice(String DataItems)
        {
            var db = new InvoiceDBcontext();
            var jsons = JsonConvert.DeserializeObject<int[]>(DataItems);



       


            if (jsons.Length==0)
            {

            
                return "No items is selected";
            }
            else
            {
                for (int i = 0; i < jsons.Length; i++)
                {
                    var num = Convert.ToInt32(jsons[i]);

                    var inv = db.Invoices.FirstOrDefault(itm => itm.InvoiceId == num);
                    db.Invoices.Remove(inv);
                    db.SaveChanges();
                  
                }

                return "Data is deleted successfuly";

            }

        }

        [WebMethod]
        public static string AddInvoice(String description, String Date , int invoiceNO, String clientName,String TheItems,int totalVAT)
        {


            if (TheItems !="")
            {
                var jsons = JsonConvert.DeserializeObject<List<Item>>(TheItems);

                var invoice = new Invoice
                {
                    Description = description,
                    date = Convert.ToDateTime(Date),
                    InvoiceNO = invoiceNO,
                    ClientName = clientName,
                    UploadedImages = "any src",
                    Items = jsons,
                    TotalVAT = totalVAT


                };
                var db = new InvoiceDBcontext();

                db.Invoices.Add(invoice);
                db.SaveChanges();
  
                    
                Console.Write("saved successfuly");
            }
         


            return "Data added";

        }
        [WebMethod]
        public static string EditInvoice(String description, String Date, int invoiceNO, String clientName, String TheItems, int totalVAT,int theinvoiceid)
        {


            if (TheItems != "")
            {
                var jsons = JsonConvert.DeserializeObject<List<Item>>(TheItems);


        
                var db = new InvoiceDBcontext();
                var items = db.Items.Where(itm => itm.InvoiceId == theinvoiceid).ToList();
                db.Items.RemoveRange(items);
                db.SaveChanges();

                if ( theinvoiceid != 0)
                {
                    var result = db.Invoices.FirstOrDefault(itm => itm.InvoiceId == theinvoiceid);
                   
                    result.Description = description;
                    result.date = Convert.ToDateTime(Date);
                    result.InvoiceNO = invoiceNO;
                    result.ClientName = clientName;
                    result.UploadedImages = "any src";


                    result.Items = jsons;
                    result.TotalVAT = totalVAT;

                   
                    db.SaveChanges();

                  
                }


                Console.Write("saved successfuly");
            }



            return "invoice edited Successfuly";

        }

    }
}