namespace MyWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        date = c.DateTime(nullable: false),
                        UploadedImages = c.String(),
                        ClientName = c.String(),
                        MyProperty = c.Int(nullable: false),
                        TotalBeforeTax = c.Int(nullable: false),
                        TotalVAT = c.Int(nullable: false),
                        TotalAfterVAT = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Tax = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.Items", new[] { "InvoiceId" });
            DropTable("dbo.Items");
            DropTable("dbo.Invoices");
        }
    }
}
