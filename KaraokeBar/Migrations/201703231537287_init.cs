namespace KaraokeBar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(maxLength:30),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Drinks",
                c => new
                    {
                        DrinkID = c.Int(nullable: false, identity: true),
                        DrinkName = c.String(maxLength:30),
                    })
                .PrimaryKey(t => t.DrinkID);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongID = c.Int(nullable: false, identity: true),
                        SongName = c.String(maxLength:30),
                        SongArtist = c.String(maxLength:30),
                    })
                .PrimaryKey(t => t.SongID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Songs");
            DropTable("dbo.Drinks");
            DropTable("dbo.Customers");
        }
    }
}
