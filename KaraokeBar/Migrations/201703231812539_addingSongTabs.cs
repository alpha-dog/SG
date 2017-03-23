namespace KaraokeBar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingSongTabs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Songs", "Tab_TabID", "dbo.Tabs");
            DropIndex("dbo.Songs", new[] { "Tab_TabID" });
            CreateTable(
                "dbo.SongTabs",
                c => new
                    {
                        Song_SongID = c.Int(nullable: false),
                        Tab_TabID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Song_SongID, t.Tab_TabID })
                .ForeignKey("dbo.Songs", t => t.Song_SongID, cascadeDelete: true)
                .ForeignKey("dbo.Tabs", t => t.Tab_TabID, cascadeDelete: true)
                .Index(t => t.Song_SongID)
                .Index(t => t.Tab_TabID);
            
            DropColumn("dbo.Songs", "Tab_TabID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "Tab_TabID", c => c.Int());
            DropForeignKey("dbo.SongTabs", "Tab_TabID", "dbo.Tabs");
            DropForeignKey("dbo.SongTabs", "Song_SongID", "dbo.Songs");
            DropIndex("dbo.SongTabs", new[] { "Tab_TabID" });
            DropIndex("dbo.SongTabs", new[] { "Song_SongID" });
            DropTable("dbo.SongTabs");
            CreateIndex("dbo.Songs", "Tab_TabID");
            AddForeignKey("dbo.Songs", "Tab_TabID", "dbo.Tabs", "TabID");
        }
    }
}
