namespace MyWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "InvoiceNO", c => c.Int(nullable: false));
            DropColumn("dbo.Invoices", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "MyProperty", c => c.Int(nullable: false));
            DropColumn("dbo.Invoices", "InvoiceNO");
        }
    }
}
