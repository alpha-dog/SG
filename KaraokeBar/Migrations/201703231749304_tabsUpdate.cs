namespace KaraokeBar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabsUpdate : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Tabs", "CustomerID");
            AddForeignKey("dbo.Tabs", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tabs", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Tabs", new[] { "CustomerID" });
        }
    }
}
