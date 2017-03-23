namespace KaraokeBar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingTabClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tabs",
                c => new
                    {
                        TabID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TabID);
            
            AddColumn("dbo.Drinks", "Tab_TabID", c => c.Int());
            AddColumn("dbo.Songs", "Tab_TabID", c => c.Int());
            CreateIndex("dbo.Drinks", "Tab_TabID");
            CreateIndex("dbo.Songs", "Tab_TabID");
            AddForeignKey("dbo.Drinks", "Tab_TabID", "dbo.Tabs", "TabID");
            AddForeignKey("dbo.Songs", "Tab_TabID", "dbo.Tabs", "TabID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "Tab_TabID", "dbo.Tabs");
            DropForeignKey("dbo.Drinks", "Tab_TabID", "dbo.Tabs");
            DropIndex("dbo.Songs", new[] { "Tab_TabID" });
            DropIndex("dbo.Drinks", new[] { "Tab_TabID" });
            DropColumn("dbo.Songs", "Tab_TabID");
            DropColumn("dbo.Drinks", "Tab_TabID");
            DropTable("dbo.Tabs");
        }
    }
}
