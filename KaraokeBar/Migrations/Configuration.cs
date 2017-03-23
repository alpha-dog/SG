namespace KaraokeBar.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KaraokeBar.Models.KaraokeBarEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KaraokeBar.Models.KaraokeBarEntities context)
        {
            context.Customers.AddOrUpdate
                (
                c => c.CustomerName,
                new Customer { CustomerName = "TomJones" },
                new Customer { CustomerName = "MarySmith" },
                new Customer { CustomerName = "ZakStout" }
                );

            context.Drinks.AddOrUpdate
                (
                d => d.DrinkName,
                new Drink { DrinkName = "MaiThai" },
                new Drink { DrinkName = "Duff" },
                new Drink { DrinkName = "ShirlyTemple" }
                );

            context.Songs.AddOrUpdate
                (
                s => s.SongID,
                new Song() { SongID = 1, SongName = "Margarittaville", SongArtist = "Jimmy Buffet" },
                new Song() { SongID = 2, SongName = "Ghost Riders", SongArtist = "Johnny Cash" },
                new Song() { SongID = 3, SongName = "Piano Man", SongArtist = "Billy Joel" }
                );

            context.SaveChanges();


            var testTab = new Tab() { DrinkList = new List<Drink>(), SongList = new List<Song>() };

            var drinkOrder = context.Drinks.First(d => d.DrinkName == "Duff");
            var songOrder = context.Songs.First(s => s.SongName == "Piano Man");

            testTab.DrinkList.Add(drinkOrder);
            testTab.SongList.Add(songOrder);

            context.Tabs.AddOrUpdate(testTab);

            context.SaveChanges();

            //context.Tabs.AddOrUpdate
            //    (
            //    t => t.TabID,
            //    new Tab { TabID = 13,
            //        CustomerID = context.Customers.First(c => c.CustomerName == "ZakStout").CustomerID,
            //        DrinkList = context.Drinks.Add(new Drink() { DrinkName = "MaiThai" });   // d => d.DrinkList == "MaiThai, Duff" )
            //    }

            //    )
        }
    }
}
