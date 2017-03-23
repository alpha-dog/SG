namespace KaraokeBar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class withDrinkTabs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Drinks", "Tab_TabID", "dbo.Tabs");
            DropForeignKey("dbo.Tabs", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Tabs", new[] { "CustomerID" });
            DropIndex("dbo.Drinks", new[] { "Tab_TabID" });
            RenameColumn(table: "dbo.Tabs", name: "CustomerID", newName: "Customer_CustomerID");
            CreateTable(
                "dbo.DrinkTabs",
                c => new
                    {
                        Drink_DrinkID = c.Int(nullable: false),
                        Tab_TabID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Drink_DrinkID, t.Tab_TabID })
                .ForeignKey("dbo.Drinks", t => t.Drink_DrinkID, cascadeDelete: true)
                .ForeignKey("dbo.Tabs", t => t.Tab_TabID, cascadeDelete: true)
                .Index(t => t.Drink_DrinkID)
                .Index(t => t.Tab_TabID);
            
            AlterColumn("dbo.Tabs", "Customer_CustomerID", c => c.Int());
            CreateIndex("dbo.Tabs", "Customer_CustomerID");
            AddForeignKey("dbo.Tabs", "Customer_CustomerID", "dbo.Customers", "CustomerID");
            DropColumn("dbo.Drinks", "Tab_TabID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drinks", "Tab_TabID", c => c.Int());
            DropForeignKey("dbo.Tabs", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.DrinkTabs", "Tab_TabID", "dbo.Tabs");
            DropForeignKey("dbo.DrinkTabs", "Drink_DrinkID", "dbo.Drinks");
            DropIndex("dbo.DrinkTabs", new[] { "Tab_TabID" });
            DropIndex("dbo.DrinkTabs", new[] { "Drink_DrinkID" });
            DropIndex("dbo.Tabs", new[] { "Customer_CustomerID" });
            AlterColumn("dbo.Tabs", "Customer_CustomerID", c => c.Int(nullable: false));
            DropTable("dbo.DrinkTabs");
            RenameColumn(table: "dbo.Tabs", name: "Customer_CustomerID", newName: "CustomerID");
            CreateIndex("dbo.Drinks", "Tab_TabID");
            CreateIndex("dbo.Tabs", "CustomerID");
            AddForeignKey("dbo.Tabs", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
            AddForeignKey("dbo.Drinks", "Tab_TabID", "dbo.Tabs", "TabID");
        }
    }
}
