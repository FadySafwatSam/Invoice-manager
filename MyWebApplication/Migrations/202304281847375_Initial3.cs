namespace MyWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "date", c => c.DateTime());
            AlterColumn("dbo.Invoices", "InvoiceNO", c => c.Int());
            AlterColumn("dbo.Invoices", "TotalBeforeTax", c => c.Int());
            AlterColumn("dbo.Invoices", "TotalVAT", c => c.Int());
            AlterColumn("dbo.Invoices", "TotalAfterVAT", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "TotalAfterVAT", c => c.Int(nullable: false));
            AlterColumn("dbo.Invoices", "TotalVAT", c => c.Int(nullable: false));
            AlterColumn("dbo.Invoices", "TotalBeforeTax", c => c.Int(nullable: false));
            AlterColumn("dbo.Invoices", "InvoiceNO", c => c.Int(nullable: false));
            AlterColumn("dbo.Invoices", "date", c => c.DateTime(nullable: false));
        }
    }
}
